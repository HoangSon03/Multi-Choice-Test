using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_Duyet_module_DuyetBaiHoc : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var khoi = from k in db.tbKhois
                       where k.khoi_id <= 12
                       select k;
            ddlKhoi.Items.Clear();
            ddlKhoi.AppendDataBoundItems = true;
            ddlKhoi.Items.Insert(0, "Chọn khối");
            ddlKhoi.DataValueField = "khoi_id";
            ddlKhoi.DataTextField = "khoi_name";
            ddlKhoi.DataSource = khoi;
            ddlKhoi.DataBind();
        }
        getAllData();
    }
    private void getAllData()
    {
        var getAll = from all in db.tbTracNghiem_Lessons
                     join kh in db.tbKhois on all.khoi_id equals kh.khoi_id
                     join mh in db.tbMonHocs on all.monhoc_id equals mh.monhoc_id
                     join ch in db.tbTracNghiem_Chapters on all.chapter_id equals ch.chapter_id
                     where all.hidden == false
                     select new
                     {
                         all.lesson_id,
                         all.lesson_name,
                         kh.khoi_name,
                         mh.monhoc_name,
                         ch.chapter_name,
                         hidden = all.hidden == false ? "Chưa duyệt" : "Đã duyệt"
                     };
        grvList.DataSource = getAll;
        grvList.DataBind();
    }
    protected void ddlKhoi_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlKhoi.SelectedValue != "Chọn khối")
        {

            var monhoc = from mhck in db.tbMonHocCuaKhois
                         join mh in db.tbMonHocs on mhck.monhoc_id equals mh.monhoc_id
                         where mhck.khoi_id == Convert.ToInt32(ddlKhoi.SelectedValue)
                         && mhck.hidden == true
                         select mh;
            ddlMon.Items.Clear();
            ddlChuong.Items.Clear();
            ddlMon.AppendDataBoundItems = true;
            ddlMon.Items.Insert(0, "Chọn môn");
            ddlChuong.Items.Insert(0, "Chọn chương");
            ddlMon.DataValueField = "monhoc_id";
            ddlMon.DataTextField = "monhoc_name";
            ddlMon.DataSource = monhoc;
            ddlMon.DataBind();
            var getTheo_khoi = from all in db.tbTracNghiem_Lessons
                               join kh in db.tbKhois on all.khoi_id equals kh.khoi_id
                               join mh in db.tbMonHocs on all.monhoc_id equals mh.monhoc_id
                               join ch in db.tbTracNghiem_Chapters on all.chapter_id equals ch.chapter_id
                               where all.hidden == false
                               && all.khoi_id == Convert.ToInt32(ddlKhoi.SelectedValue)
                               select new
                               {
                                   all.lesson_id,
                                   all.lesson_name,
                                   kh.khoi_name,
                                   mh.monhoc_name,
                                   ch.chapter_name,
                                   hidden = all.hidden == false ? "Chưa duyệt" : "Đã duyệt"
                               };
            grvList.DataSource = getTheo_khoi;
            grvList.DataBind();
        }
        else
        {
            getAllData();
            ddlMon.Items.Clear();
            ddlMon.AppendDataBoundItems = true;
            ddlMon.Items.Insert(0, "Chọn môn");
        }

    }
    protected void ddlMon_SelectedIndexChanged1(object sender, EventArgs e)
    {
        var chuong = from ch in db.tbTracNghiem_Chapters
                     where ch.monhoc_id == Convert.ToInt32(ddlMon.SelectedValue)
                     && ch.hidden == true
                     select ch;
        ddlChuong.Items.Clear();
        ddlChuong.AppendDataBoundItems = true;
        ddlChuong.Items.Insert(0, "Chọn chương");
        ddlChuong.DataValueField = "chapter_id";
        ddlChuong.DataTextField = "chapter_name";
        ddlChuong.DataSource = chuong;
        ddlChuong.DataBind();
        var getTheo_mon = from all in db.tbTracNghiem_Lessons
                          join kh in db.tbKhois on all.khoi_id equals kh.khoi_id
                          join mh in db.tbMonHocs on all.monhoc_id equals mh.monhoc_id
                          join ch in db.tbTracNghiem_Chapters on all.chapter_id equals ch.chapter_id
                          where all.hidden == false
                          && all.khoi_id == Convert.ToInt32(ddlKhoi.SelectedValue)
                          && all.monhoc_id == Convert.ToInt32(ddlMon.SelectedValue)
                          select new
                          {
                              all.lesson_id,
                              all.lesson_name,
                              kh.khoi_name,
                              mh.monhoc_name,
                              ch.chapter_name,
                              hidden = all.hidden == false ? "Chưa duyệt" : "Đã duyệt"
                          };
        grvList.DataSource = getTheo_mon;
        grvList.DataBind();
    }
    protected void ddlChuong_SelectedIndexChanged(object sender, EventArgs e)
    {
        var getBaiHoc = from bh in db.tbTracNghiem_Lessons
                        join kh in db.tbKhois on bh.khoi_id equals kh.khoi_id
                        join mh in db.tbMonHocs on bh.monhoc_id equals mh.monhoc_id
                        join ch in db.tbTracNghiem_Chapters on bh.chapter_id equals ch.chapter_id
                        where bh.khoi_id == Convert.ToInt32(ddlKhoi.SelectedValue)
                        && bh.monhoc_id == Convert.ToInt32(ddlMon.SelectedValue)
                        && bh.chapter_id == Convert.ToInt32(ddlChuong.SelectedValue)
                        && bh.hidden == false
                        select new
                        {
                            bh.lesson_id,
                            bh.lesson_name,
                            kh.khoi_name,
                            mh.monhoc_name,
                            ch.chapter_name,
                            hidden = bh.hidden == false ? "Chưa duyệt" : "Đã duyệt"
                        };
        grvList.DataSource = getBaiHoc;
        grvList.DataBind();
    }
    protected void btnDuyetChuong_Click(object sender, EventArgs e)
    {
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "lesson_id" });
        if (selectedKey.Count <= 0)
        {
            alert.alert_Warning(Page, "Bạn chưa chọn bài học để duyệt", "");
        }
        else
        {
            foreach (var item in selectedKey)
            {
                var getdata = (from bh in db.tbTracNghiem_Lessons
                               where bh.lesson_id == Convert.ToInt32(item)
                               select bh).SingleOrDefault();
                getdata.hidden = true;
                db.SubmitChanges();
            }
            alert.alert_Success(Page, "Duyệt bài học thành công", "");
            getAllData();
        }
    }

}