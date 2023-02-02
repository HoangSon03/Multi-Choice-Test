using DevExpress.Web.ASPxHtmlEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_DacTa : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private int _id;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Cookies["UserName"].Value != "")
        {
          
           
            if (!IsPostBack)
            {
                Session["_id"] = 0;
            }
            loadData();

        }
        else
        {
            Response.Redirect("/admin-login");
        }
    }
    private void loadData()
    {
        var getData = from dc in db.tbTracNghiem_DacTas
                      join l in db.tbTracNghiem_Lessons on dc.lession_id equals l.lesson_id
                      join c in db.tbTracNghiem_Chapters on l.chapter_id equals c.chapter_id
                      join k in db.tbKhois on c.khoi_id equals k.khoi_id
                      join m in db.tbMonHocs on dc.mon_id equals m.monhoc_id
                      select new
                      {
                          k.khoi_name,
                          dc.dacta_loai,
                          dc.dacta_id,
                          dc.dacta_content,
                          m.monhoc_name,
                          l.lesson_name,
                          c.chapter_name
                      };

        grvList.DataSource = getData;
        grvList.DataBind();
        ddlKhoi.DataSource = from gvdk in db.tbGiaoVienDayKhois
                             join u in db.admin_Users on gvdk.username_id equals u.username_id
                             join k in db.tbKhois on gvdk.khoi_id equals k.khoi_id
                             where u.username_username == Request.Cookies["UserName"].Value
                             orderby k.khoi_name ascending
                             select k;
        ddlKhoi.DataBind();
        ddlMon.DataSource = from n in db.tbMonHocs
                            join gvdm in db.tbGiaoVienDayMons on n.monhoc_id equals gvdm.monhoc_id
                            join gv in db.admin_Users on gvdm.username_id equals gv.username_id
                            where gv.username_username == Request.Cookies["UserName"].Value
                            select n;
        ddlMon.DataBind();
        ddlChuong.DataSource = from c in db.tbTracNghiem_Chapters
                               where c.khoi_id == Convert.ToInt16(ddlKhoi.Value) && c.monhoc_id == Convert.ToInt16(ddlMon.Value)
                               select c;
        ddlChuong.DataBind();
        ddlLesson.DataSource = from l in db.tbTracNghiem_Lessons
                      where l.khoi_id == Convert.ToInt16(ddlKhoi.Value)
                      && l.monhoc_id == Convert.ToInt16(ddlMon.Value)
                      && l.chapter_id == Convert.ToInt16(ddlChuong.Value)
                      select l;
        ddlLesson.DataBind();

    }
    private void setNULL()
    {
        txtNoiDung.Text = "";
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        Session["_id"] = 0;
        setNULL();
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Insert", "popupControl.Show();", true);
    }
    protected void btnChiTiet_Click(object sender, EventArgs e)
    {
        _id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "dacta_id" }));
        Session["_id"] = _id;
        var getData = (from dc in db.tbTracNghiem_DacTas
                       join l in db.tbTracNghiem_Lessons on dc.lession_id equals l.lesson_id
                       join c in db.tbTracNghiem_Chapters on l.chapter_id equals c.chapter_id
                       join k in db.tbKhois on c.khoi_id equals k.khoi_id
                       join m in db.tbMonHocs on dc.mon_id equals m.monhoc_id
                       where dc.dacta_id == _id
                       select new
                       {
                           dc.dacta_id,
                           dc.dacta_content,
                           dc.dacta_loai,
                           k.khoi_name,
                           m.monhoc_name,
                           l.lesson_name,
                           c.chapter_name
                         }).Single();
        ddlKhoi.Text = getData.khoi_name;
        ddlMon.Text = getData.monhoc_name;
        ddlChuong.Text = getData.chapter_name;
        ddlLesson.Text = getData.lesson_name;
        txtNoiDung.Text = getData.dacta_content;
        ddlLoai.Text = getData.dacta_loai;
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "popupControl.Show();", true);
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        cls_DacTa cls;
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "dacta_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                cls = new cls_DacTa();
                if (cls.Linq_Xoa(Convert.ToInt32(item)))
                    alert.alert_Success(Page, "Xóa thành công", "");
                else
                    alert.alert_Error(Page, "Xóa thất bại", "");
            }
        }
        else
            alert.alert_Warning(Page, "Bạn chưa chọn dữ liệu", "");
    }

    public bool checknull()
    {
        if (txtNoiDung.Text != "")
            return true;
        else return false;
    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        var getUser = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).SingleOrDefault();
        cls_DacTa cls = new cls_DacTa();
        if (checknull() == false)
            alert.alert_Warning(Page, "Vui lòng nhập đầy đủ thông tin!", "");
        else
        {
            
            if (Session["_id"].ToString() == "0")
            {
                if (cls.Linq_Them(txtNoiDung.Text,Convert.ToInt16(getUser.username_id), Convert.ToInt16(ddlKhoi.Value), Convert.ToInt16(ddlMon.Value), Convert.ToInt16(ddlChuong.Value), Convert.ToInt16(ddlLesson.Value), ddlLoai.Text))
                    alert.alert_Success(Page, "Thêm thành công", "");
                else alert.alert_Error(Page, "Thêm thất bại", "");
            }
            else
            {
                if (cls.Linq_Sua(Convert.ToInt32(Session["_id"].ToString()), txtNoiDung.Text, Convert.ToInt16(getUser.username_id), Convert.ToInt16(ddlKhoi.Value), Convert.ToInt16(ddlMon.Value), Convert.ToInt16(ddlChuong.Value), Convert.ToInt16(ddlLesson.Value), ddlLoai.Text))
                    alert.alert_Success(Page, "Cập nhật thành công", "");
                else alert.alert_Error(Page, "Cập nhật thất bại", "");
            }
        }
    }

    protected void ddlKhoi_SelectedIndexChanged(object sender, EventArgs e)
    {
        var getUser = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).SingleOrDefault();
        // đổ lại ds môn
        var listMon = from gvdm in db.tbGiaoVienDayMons
                      join m in db.tbMonHocs on gvdm.monhoc_id equals m.monhoc_id
                      where gvdm.username_id == getUser.username_id
                      select m;
        ddlMon.DataSource = listMon;
        ddlMon.DataBind();

    }

    protected void ddlMon_SelectedIndexChanged(object sender, EventArgs e)
    {
       int id_mon = Convert.ToInt32(ddlMon.Value);
       int id_khoi = Convert.ToInt32(ddlKhoi.Value);
        var listChuDe = from c in db.tbTracNghiem_Chapters
                        where c.khoi_id == id_khoi && c.monhoc_id == id_mon
                        select c;
        ddlChuong.DataSource = listChuDe;
        ddlChuong.DataBind();
    }

    protected void ddlChuong_SelectedIndexChanged(object sender, EventArgs e)
    {
        var listBai = from l in db.tbTracNghiem_Lessons
                      where l.khoi_id == Convert.ToInt16(ddlKhoi.Value)
                      && l.monhoc_id == Convert.ToInt16(ddlMon.Value)
                      && l.chapter_id == Convert.ToInt16(ddlChuong.Value)
                      select l;
        ddlLesson.DataSource = listBai;
        ddlLesson.DataBind();
    }
}