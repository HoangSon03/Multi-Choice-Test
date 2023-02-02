using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_Duyet_module_DuyetChuong : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var getKhoi = from k in db.tbKhois
                          where k.khoi_id <= 12
                          select k;
            ddlKhoi_M.Items.Clear();
            ddlKhoi_M.AppendDataBoundItems = true;
            ddlKhoi_M.Items.Insert(0, "Chọn khối");
            ddlKhoi_M.DataValueField = "khoi_id";
            ddlKhoi_M.DataTextField = "khoi_name";
            ddlKhoi_M.DataSource = getKhoi;
            ddlKhoi_M.DataBind();
        }
        getdataChuong();
    }
    private void getdataChuong()
    {
        if (ddlKhoi_M.SelectedValue == "Chọn khối")
        {
            var getdataChuong = from c in db.tbTracNghiem_Chapters
                                join mh in db.tbMonHocs on c.monhoc_id equals mh.monhoc_id
                                join k in db.tbKhois on c.khoi_id equals k.khoi_id
                                where c.hidden == false
                                select new
                                {
                                    c.chapter_id,
                                    k.khoi_name,
                                    mh.monhoc_name,
                                    c.chapter_name,
                                    hidden = c.hidden == false ? "Chưa duyệt" : "Đã duyệt"
                                };
            grvListCh.DataSource = getdataChuong;
            grvListCh.DataBind();
        }
        else
        {
            var getChuong = from c in db.tbTracNghiem_Chapters
                            join mh in db.tbMonHocs on c.monhoc_id equals mh.monhoc_id
                            join k in db.tbKhois on c.khoi_id equals k.khoi_id
                            where c.hidden == false && c.khoi_id == Convert.ToInt32(ddlKhoi_M.SelectedValue)
                            select new
                            {
                                c.chapter_id,
                                k.khoi_name,
                                mh.monhoc_name,
                                c.chapter_name,
                                hidden = c.hidden == false ? "Chưa duyệt" : "Đã duyệt"
                            };
            grvListCh.DataSource = getChuong;
            grvListCh.DataBind();
        }
    }
    protected void btnDuyetChuong_Click(object sender, EventArgs e)
    {
        List<object> selectedKey = grvListCh.GetSelectedFieldValues(new string[] { "chapter_id" });
        if (selectedKey.Count <= 0)
        {
            alert.alert_Warning(Page, "Bạn chưa chọn chương để duyệt", "");
        }
        else
        {
            foreach (var item in selectedKey)
            {
                var Duyet = (from ch in db.tbTracNghiem_Chapters
                             where ch.chapter_id == Convert.ToInt32(item)
                             select ch).SingleOrDefault();
                Duyet.hidden = true;
                db.SubmitChanges();
            }
            alert.alert_Success(Page, "Duyệt chương thành công", "");
            getdataChuong();
        }
    }


    protected void ddlMon_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (ddlMon.SelectedValue == "Chọn môn")
        {
            var getChuong_khoi = from ch in db.tbTracNghiem_Chapters
                                 join mh in db.tbMonHocs on ch.monhoc_id equals mh.monhoc_id
                                 join k in db.tbKhois on ch.khoi_id equals k.khoi_id
                                 where  ch.hidden == false
                                 && ch.khoi_id == Convert.ToInt32(ddlKhoi_M.SelectedValue)
                                 select new
                                 {
                                     ch.chapter_id,
                                     k.khoi_name,
                                     mh.monhoc_name,
                                     ch.chapter_name,
                                     hidden = ch.hidden == false ? "Chưa duyệt" : "Đã duyệt"
                                 };
            grvListCh.DataSource = getChuong_khoi;
            grvListCh.DataBind();
        }
        else
        {

            var getChuong_khoi = from ch in db.tbTracNghiem_Chapters
                                 join mh in db.tbMonHocs on ch.monhoc_id equals mh.monhoc_id
                                 join k in db.tbKhois on ch.khoi_id equals k.khoi_id
                                 where ch.monhoc_id == Convert.ToInt32(ddlMon.SelectedValue) && ch.hidden == false
                                 && ch.khoi_id == Convert.ToInt32(ddlKhoi_M.SelectedValue)
                                 select new
                                 {
                                     ch.chapter_id,
                                     k.khoi_name,
                                     mh.monhoc_name,
                                     ch.chapter_name,
                                     hidden = ch.hidden == false ? "Chưa duyệt" : "Đã duyệt"
                                 };
            grvListCh.DataSource = getChuong_khoi;
            grvListCh.DataBind();
        }
    }

    protected void ddlKhoi_M_SelectedIndexChanged1(object sender, EventArgs e)
    {
        var mon = from m in db.tbMonHocs
                  select m;
        ddlMon.Items.Clear();
        ddlMon.AppendDataBoundItems = true;
        ddlMon.Items.Insert(0, "Chọn môn");
        ddlMon.DataValueField = "monhoc_id";
        ddlMon.DataTextField = "monhoc_name";
        ddlMon.DataSource = mon;
        ddlMon.DataBind();
        getdataChuong();
    }
}