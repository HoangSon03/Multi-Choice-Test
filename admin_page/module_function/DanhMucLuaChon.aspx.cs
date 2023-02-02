using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_DanhMucLuaChon : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    public int id_user;
    public int id_khoi;
    public int id_mon;
    public int id_chude;
    protected void Page_Load(object sender, EventArgs e)
    {

        var checkTaiKhoan = (from u in db.admin_Users
                             where u.username_username == Request.Cookies["UserName"].Value
                             select u).FirstOrDefault();
        id_user = checkTaiKhoan.username_id;
        if (!IsPostBack)
        {
            ddlKhoi.Enabled = true;
            ddlBai.Enabled = false;
            ddlMon.Enabled = false;
            ddlChuDe.Enabled = false;
            // đổ khối
            var listKhoi = from gvdk in db.tbGiaoVienDayKhois
                           join k in db.tbKhois on gvdk.khoi_id equals k.khoi_id
                           where gvdk.username_id == checkTaiKhoan.username_id
                           orderby k.khoi_name ascending
                           select k;
            //var listNV = from nv in db.tbNhanViens select nv;
            if (listKhoi.Count() != 0)
            {
                ddlKhoi.Items.Clear();
                ddlKhoi.Items.Insert(0, "Chọn khối");
                ddlKhoi.AppendDataBoundItems = true;
                ddlKhoi.DataTextField = "khoi_name";
                ddlKhoi.DataValueField = "khoi_id";
                ddlKhoi.DataSource = listKhoi;
                ddlKhoi.DataBind();
                //đổ môn



            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showError()", true);
            }


            //var listMon = from gvdm in db.tbGiaoVienDayMons
            //              join m in db.tbMonHocs on gvdm.monhoc_id equals m.monhoc_id
            //              where gvdm.username_id == checkTaiKhoan.username_id
            //              select m;
            //ddlMon.DataSource = listMon;
            //ddlMon.DataTextField = "monhoc_name";
            //ddlMon.DataValueField = "monhoc_id";
            //ddlMon.DataBind();

            //var listChuDe = from c in db.tbTracNghiem_Chapters
            //                where c.khoi_id == Convert.ToInt16(ddlKhoi.SelectedValue)
            //                && c.monhoc_id == Convert.ToInt16(ddlMon.SelectedValue)
            //                select c;
            //ddlChuDe.DataSource = listChuDe;
            //ddlChuDe.DataTextField = "chapter_name";
            //ddlChuDe.DataValueField = "chapter_id";
            ////ddlChuDe.DataBind();

            //var listBai = from l in db.tbTracNghiem_Lessons
            //              where l.khoi_id == Convert.ToInt16(ddlKhoi.SelectedValue)
            //              && l.monhoc_id == Convert.ToInt16(ddlMon.SelectedValue)
            //              && l.chapter_id == Convert.ToInt16(ddlChuDe.SelectedValue)
            //              select l;
            //ddlBai.Items.Clear();
            //ddlBai.Items.Insert(0, "Chọn bài");
            //ddlBai.AppendDataBoundItems = true;
            //ddlBai.DataSource = listBai;
            //ddlBai.DataTextField = "lesson_name";
            //ddlBai.DataValueField = "lesson_id";
            //ddlBai.DataBind();
        }
    }

    protected void ddlKhoi_SelectedIndexChanged(object sender, EventArgs e)
    {

        id_khoi = Convert.ToInt32(ddlKhoi.SelectedValue);
        // đổ lại ds môn
        var listMon = from gvdm in db.tbGiaoVienDayMons
                      join m in db.tbMonHocs on gvdm.monhoc_id equals m.monhoc_id
                      where gvdm.username_id == id_user
                      select m;
        if (listMon.Count() != 0)
        {
            ddlMon.Items.Clear();
            ddlMon.Items.Insert(0, "Chọn môn");
            ddlMon.AppendDataBoundItems = true;
            ddlMon.DataSource = listMon;
            ddlMon.DataTextField = "monhoc_name";
            ddlMon.DataValueField = "monhoc_id";
            ddlMon.DataBind();
            ddlMon.Enabled = true;
        }
        else
        {
            ddlKhoi.Items.Clear();
            ddlKhoi.Items.Insert(0, "Không có dữ liệu");
            ddlKhoi.AppendDataBoundItems = true;
            ddlMon.DataSource = listMon;
            ddlMon.DataBind();

        }
        //var listChuDe = from c in db.tbTracNghiem_Chapters
        //                where c.khoi_id == Convert.ToInt16(ddlKhoi.SelectedValue)
        //                && c.monhoc_id == Convert.ToInt16(ddlMon.SelectedValue)
        //                select c;
        //ddlChuDe.DataSource = listChuDe;
        //ddlChuDe.DataTextField = "chapter_name";
        //ddlChuDe.DataValueField = "chapter_id";
        //ddlChuDe.DataBind();

        //var listBai = from l in db.tbTracNghiem_Lessons
        //              where l.khoi_id == Convert.ToInt16(ddlKhoi.SelectedValue)
        //              && l.monhoc_id == Convert.ToInt16(ddlMon.SelectedValue)
        //              && l.chapter_id == Convert.ToInt16(ddlChuDe.SelectedValue)
        //              select l;
        //ddlBai.DataSource = listBai;
        //ddlBai.DataTextField = "lesson_name";
        //ddlBai.DataValueField = "lesson_id";
        //ddlBai.DataBind();
    }

    protected void ddlMon_SelectedIndexChanged(object sender, EventArgs e)
    {
        id_mon = Convert.ToInt32(ddlMon.SelectedValue);
        id_khoi = Convert.ToInt32(ddlKhoi.SelectedValue);
        var listChuDe = from c in db.tbTracNghiem_Chapters
                        where c.khoi_id == id_khoi && c.monhoc_id == id_mon
                        select c;
        if (listChuDe.Count() > 0)
        {
            ddlChuDe.Items.Clear();
            ddlChuDe.Items.Insert(0, "Chọn chủ đề");
            ddlChuDe.AppendDataBoundItems = true;
            ddlChuDe.DataSource = listChuDe;
            ddlChuDe.DataTextField = "chapter_name";
            ddlChuDe.DataValueField = "chapter_id";
            ddlChuDe.DataBind();
            ddlChuDe.Enabled = true;
        }
        else
        {
            ddlChuDe.Items.Clear();
            ddlChuDe.Items.Insert(0, "Không có dữ liệu");
            ddlChuDe.AppendDataBoundItems = true;
            ddlChuDe.DataSource = listChuDe;
            ddlChuDe.DataBind();
        }
    }
    protected void ddlChuDe_SelectedIndexChanged(object sender, EventArgs e)
    {
        //id_mon = Convert.ToInt32(ddlMon.SelectedValue);
        //id_khoi = Convert.ToInt32(ddlKhoi.SelectedValue);
        //id_chude = Convert.ToInt32(ddlChuDe.SelectedValue);
        id_mon = Convert.ToInt32(ddlMon.SelectedValue);
        id_khoi = Convert.ToInt32(ddlKhoi.SelectedValue);
        var listBai = from l in db.tbTracNghiem_Lessons
                      where l.khoi_id == Convert.ToInt16(ddlKhoi.SelectedValue)
                      && l.monhoc_id == Convert.ToInt16(ddlMon.SelectedValue)
                      && l.chapter_id == Convert.ToInt16(ddlChuDe.SelectedValue)
                      select l;
        if (listBai.Count() > 0)
        {
            ddlBai.Items.Clear();
            ddlBai.Items.Insert(0, "Chọn bài");
            ddlBai.AppendDataBoundItems = true;
            ddlBai.DataSource = listBai;
            ddlBai.DataTextField = "lesson_name";
            ddlBai.DataValueField = "lesson_id";
            ddlBai.DataBind();
            ddlBai.Enabled = true;
        }
        else
        {
            ddlBai.Items.Clear();
            ddlBai.Items.Insert(0, "Không có dữ liệu");
            ddlBai.AppendDataBoundItems = true;
            ddlChuDe.DataSource = listBai;
            ddlBai.DataBind();
        }

    }
    protected void btnThemCauHoiTracNghiem_ServerClick(object sender, EventArgs e)
    {
        int ID_khoi = Convert.ToInt16(ddlKhoi.SelectedValue);
        int ID_Mon = Convert.ToInt16(ddlMon.SelectedValue);
        int ID_Chuong = Convert.ToInt16(ddlChuDe.SelectedValue);
        int ID_Bai = Convert.ToInt16(ddlBai.SelectedValue);
        Response.Redirect("admin-quan-ly-cau-hoi-trac-nghiem-" + ID_khoi + "-" + ID_Mon + "-" + ID_Chuong + "-" + ID_Bai);
    }

    protected void btnThemCauHoiTuLuan_ServerClick(object sender, EventArgs e)
    {
        int ID_khoi = Convert.ToInt16(ddlKhoi.SelectedValue);
        int ID_Mon = Convert.ToInt16(ddlMon.SelectedValue);
        int ID_Chuong = Convert.ToInt16(ddlChuDe.SelectedValue);
        int ID_Bai = Convert.ToInt16(ddlBai.SelectedValue);
        Response.Redirect("admin-quan-ly-cau-hoi-tu-luan-" + ID_khoi + "-" + ID_Mon + "-" + ID_Chuong + "-" + ID_Bai);
    }

    protected void btnThemChuDe_ServerClick(object sender, EventArgs e)
    {
        //alert.alert_Success(Page, "dsf", " ");
        if (ddlKhoi.SelectedValue != "Chọn khối")
        {
            if (ddlMon.SelectedValue != "Chọn môn")
            {
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Insert", "popupControl.Show();", true);
                //if (txtTenChuDe.Text != "")
                //{
                //    tbTracNghiem_Chapter insert = new tbTracNghiem_Chapter();
                //    insert.chapter_name = txtTenChuDe.Text;
                //    insert.khoi_id = Convert.ToInt32(ddlKhoi.SelectedValue);
                //}
            }
            else
            {
                alert.alert_Error(Page, "Vui lòng chọn môn", " ");

            }
        }
        else
        {
            alert.alert_Error(Page, "Vui lòng chọn khối", " ");

        }
    }

    protected void btnLuu_Click(object sender, EventArgs e)
    {
        tbTracNghiem_Chapter insert = new tbTracNghiem_Chapter();
        insert.chapter_name = txtTenChuDe.Text;
        insert.khoi_id = Convert.ToInt32(ddlKhoi.SelectedValue);
        insert.monhoc_id = Convert.ToInt32(ddlMon.SelectedValue);
        db.tbTracNghiem_Chapters.InsertOnSubmit(insert);
        db.SubmitChanges();
        alert.alert_Success(Page, "Thêm thành công", "");
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Insert", "popupControl.Hide();", true);
    }

    protected void btnLuuBai_Click(object sender, EventArgs e)
    {
        tbTracNghiem_Lesson insertBai = new tbTracNghiem_Lesson();
        insertBai.chapter_id = Convert.ToInt32(ddlChuDe.SelectedValue);
        insertBai.lesson_name = txtTenBai.Text;
        insertBai.khoi_id = Convert.ToInt32(ddlKhoi.SelectedValue);
        insertBai.monhoc_id = Convert.ToInt32(ddlMon.SelectedValue);
        db.tbTracNghiem_Lessons.InsertOnSubmit(insertBai);
        db.SubmitChanges();
        alert.alert_Success(Page, "Thêm thành công", "");
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Insert", "popupThemBai.Hide();", true);
    }

    protected void btnThemBai_Click(object sender, EventArgs e)
    {
        if (ddlKhoi.SelectedValue != "Chọn khối")
        {
            if (ddlMon.SelectedValue != "Chọn môn")
            {
                if (ddlChuDe.SelectedValue != "Chọn chủ đề")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Insert", "popupThemBai.Show();", true);
                }
                else
                {
                    alert.alert_Error(Page, "Vui lòng chọn chủ đề", " ");

                }
            }
            else
            {
                alert.alert_Error(Page, "Vui lòng chọn môn", " ");

            }
        }
        else
        {
            alert.alert_Error(Page, "Vui lòng chọn khối", " ");

        }
    }

    protected void ddlBai_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}