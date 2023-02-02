using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_TracNghiem_module_QuanLyChuong : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    private int _id;
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    Session["_id"] = 0;
        //    Session["_idKhoi"] = 0;
        //    Session["_idMon"] = 0;
        //    //Get Danh Sách Khối Lên DDL Khối
        //    var getListKhoi = from kh in db.tbKhois
        //                      select kh;
        //    ddlKhoi.Items.Clear();
        //    ddlKhoi.AppendDataBoundItems = true;
        //    ddlKhoi.Items.Insert(0, "--Chọn Khối--");
        //    ddlKhoi.DataValueField = "khoi_id";
        //    ddlKhoi.DataTextField = "khoi_name";
        //    ddlKhoi.DataSource = getListKhoi;
        //    ddlKhoi.DataBind();
        //    ddlMon.Visible = false;
        //}
        //getData();
    }
    protected void getData()
    {
        //var getData = from dt in db.tbTracNghiem_Chapters
        //                  //đây phải nối đến bảng khối thì mới lấy được tên khối ra
        //                  //nối là join bảng đó
        //              join k in db.tbKhois on dt.khoi_id equals k.khoi_id
        //              // nối đến bảng nào thì cứ join bt thôi
        //              //qtrong là nối cái khóa phụ cho đúng là được
        //              join mh in db.tbMonHocs on dt.monhoc_id equals mh.monhoc_id
        //              select new
        //              {
        //                  dt.chapter_id,
        //                  dt.chapter_name,
        //                  k.khoi_name, // lấy cái tên khối để hiện ra nè
        //                  mh.monhoc_name // lấy cái tên môn học
        //              };
        //grvList.DataSource = getData;
        //grvList.DataBind();

    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        //Session["_id"] = null;
        //txtTenChuong.Text = "";//đưa thẻ input về rỗng
        //ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Insert", "popupControl.Show();", true);
    }
    protected void btnChiTiet_Click(object sender, EventArgs e)
    {
        //_id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "chapter_id" }));
        //Session["_id"] = _id;
        //var getDetail = (from c in db.tbTracNghiem_Chapters
        //                 where c.chapter_id == _id
        //                 select c).SingleOrDefault();
        //txtTenChuong.Text = getDetail.chapter_name;
        //ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "popupControl.Show();", true);
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        //_id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "chapter_id" }));
        //var delete = (from c in db.tbTracNghiem_Chapters
        //              where c.chapter_id == _id
        //              select c).SingleOrDefault();
        //db.tbTracNghiem_Chapters.DeleteOnSubmit(delete);
        //db.SubmitChanges();
        //alert.alert_Success(Page, "Xóa thành công", "");
        //getData();

    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        tbTracNghiem_Chapter chuong = new tbTracNghiem_Chapter();
        chuong.monhoc_id = Convert.ToInt32(RouteData.Values["mon_id"]);
        chuong.khoi_id = Convert.ToInt32(RouteData.Values["khoi_id"]);
        chuong.chapter_name = txtTenChuong.Text;
        chuong.hidden = false;
        db.tbTracNghiem_Chapters.InsertOnSubmit(chuong);
        db.SubmitChanges();
        Response.Redirect("/admin-home");
        //int khoi_id = Convert.ToInt32(Session["_idKhoi"].ToString());
        //int mon_id = Convert.ToInt32(Session["_idMon"].ToString());
        //if (khoi_id == 0 && mon_id == 0)
        //{
        //    alert.alert_Error(Page, "Bạn chưa chọn khối - môn", "");
        //}
        //else
        //{
        //    //session bằng null là thêm mới
        //    if (Session["_id"] == null)
        //    {
        //        //trong bảng có bnhieu truong thì insert bấy nhiêu trường
        //        //trừ trường id khóa chính thôi 
        //        //oke chưa.
        //        tbTracNghiem_Chapter insert = new tbTracNghiem_Chapter();
        //        insert.monhoc_id = mon_id;
        //        insert.khoi_id = khoi_id;
        //        insert.chapter_name = txtTenChuong.Text;
        //        db.tbTracNghiem_Chapters.InsertOnSubmit(insert);
        //        db.SubmitChanges();
        //        alert.alert_Success(Page, "Thêm thành công", "");
        //    }
        //    else
        //    {
        //        tbTracNghiem_Chapter update = db.tbTracNghiem_Chapters.Where(x => x.chapter_id == Convert.ToInt32(Session["_id"].ToString())).SingleOrDefault();
        //        update.khoi_id = khoi_id;
        //        update.monhoc_id = mon_id;
        //        update.chapter_name = txtTenChuong.Text;
        //        db.SubmitChanges();
        //        alert.alert_Success(Page, "Cập nhật thành công", "");
        //    }
        //    popupControl.ShowOnPageLoad = false;
        //    getData();
        //}
    }

    protected void ddlKhoi_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlKhoi.SelectedValue != "--Chọn Khối--")
        //{
        //    int _idKhoi = Convert.ToInt32(ddlKhoi.SelectedValue);
        //    var loadData = from dt in db.tbTracNghiem_Chapters
        //                   join k in db.tbKhois on dt.khoi_id equals k.khoi_id
        //                   join mh in db.tbMonHocs on dt.monhoc_id equals mh.monhoc_id
        //                   where k.khoi_id == Convert.ToInt32(ddlKhoi.SelectedValue)
        //                   select new
        //                   {
        //                       dt.chapter_id,
        //                       dt.chapter_name,
        //                       k.khoi_name,
        //                       mh.monhoc_name
        //                   };
        //    grvList.DataSource = loadData;
        //    grvList.DataBind();
        //    //Get Danh Sách Khối lên DDL Môn
        //    var getListMon = from mhck in db.tbMonHocCuaKhois
        //                     join mh in db.tbMonHocs on mhck.monhoc_id equals mh.monhoc_id
        //                     where mhck.khoi_id == _idKhoi
        //                     select mh;
        //    if (getListMon.Count() > 0)
        //    {
        //        ddlMon.Items.Clear();
        //        ddlMon.AppendDataBoundItems = true;
        //        ddlMon.Items.Insert(0, "--Chọn Môn--");
        //        ddlMon.DataValueField = "monhoc_id";
        //        ddlMon.DataTextField = "monhoc_name";
        //        ddlMon.DataSource = getListMon;
        //        ddlMon.DataBind();
        //        Session["_idKhoi"] = _idKhoi;
        //        ddlMon.Visible = true;
        //    }
        //    else
        //        ddlMon.Visible = false;
        //}
    }

    protected void ddlMon_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlMon.SelectedValue != "--Chọn Môn--")
        //{
        //    int _idMon = Convert.ToInt32(ddlMon.SelectedValue);
        //    Session["_idMon"] = _idMon;
        //    var loadData = from dt in db.tbTracNghiem_Chapters
        //                   join k in db.tbKhois on dt.khoi_id equals k.khoi_id
        //                   join mh in db.tbMonHocs on dt.monhoc_id equals mh.monhoc_id
        //                   where k.khoi_id == Convert.ToInt32(ddlKhoi.SelectedValue)
        //                   && mh.monhoc_id == Convert.ToInt32(ddlMon.SelectedValue)
        //                   select new
        //                   {
        //                       dt.chapter_id,
        //                       dt.chapter_name,
        //                       k.khoi_name,
        //                       mh.monhoc_name
        //                   };
        //    grvList.DataSource = loadData;
        //    grvList.DataBind();
        //}
    }



}