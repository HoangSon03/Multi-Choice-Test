using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_ThongKe_admin_ThongKeTong : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public int STT = 1;
    public int STT2 = 1;
    public int STT3 = 1;
    public int STT4 = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Load Khói
            var listKhoi = from k in db.tbKhois select k;
            ddlKhoi.Items.Clear();
            ddlKhoi.Items.Insert(0, "Chọn khối");
            ddlKhoi.AppendDataBoundItems = true;
            ddlKhoi.DataTextField = "khoi_name";
            ddlKhoi.DataValueField = "khoi_id";
            ddlKhoi.DataSource = listKhoi;
            ddlKhoi.DataBind();
            div_TuNgayToiNgay1.Visible = false;
            div_SoLanLamBai.Visible = false;
            div_BangDiemChiTietCuaHocSinh.Visible = false;
            div_BangDiemChiTietCuaTungBaiTapHocSinh.Visible = false;
        }
    }
    protected void ddlKhoi_SelectedIndexChanged(object sender, EventArgs e)
    {
        var listLop = from l in db.tbLops
                      where l.khoi_id == Convert.ToInt32(ddlKhoi.SelectedValue)
                      select new
                      {
                          l.lop_id,
                          l.lop_name,
                          tongsoluong_hocsinhlambai = (from hstl in db.tbHocSinhTrongLops
                                                       where hstl.lop_id == l.lop_id && hstl.namhoc_id == 1
                                                       select hstl).Count(),
                          // tính số lượng học sinh làm bài trong lớp đó
                          soluong_hocsinhlambai = (from d in db.tbTracNghiem_ResultTests
                                                   where d.lop_id == l.lop_id
                                                   group d.hocsinh_code by d.hocsinh_code into g
                                                   select g.Key).Count()

                      };
        rpLop.DataSource = listLop;
        rpLop.DataBind();
        div_TuNgayToiNgay1.Visible = true;
        div_SoLanLamBai.Visible = true;
    }

    protected void btnShowKetQuaHocSinhTrongLop_ServerClick(object sender, EventArgs e)
    {
        //var getDiem_HocSinh = (from d in db.tbTracNghiem_ResultTests
        //                   where d.lop_id == 1
        //                   group d.hocsinh_code by d.hocsinh_code into g
        //                   select g.Key);

        var listHocSinh = from hs in db.tbHocSinhs
                          join d in db.tbTracNghiem_ResultTests on hs.hocsinh_code equals d.hocsinh_code
                          where d.lop_id == Convert.ToInt16(txtLop.Value)
                          group d by d.hocsinh_code into g
                          select new
                          {
                              resulttest_id = 1,
                              hocsinh_code = g.Key,
                              hocsinh_name = (from hs in db.tbHocSinhs where hs.hocsinh_code == g.Key select hs).First().hocsinh_name,
                              hocsinh_solanlambai = (from dct in db.tbTracNghiem_ResultTests where dct.hocsinh_code == g.Key select dct).Count()
                          };
        rpSoLanLamBai.DataSource = listHocSinh;
        rpSoLanLamBai.DataBind();
        //div_BangDiemChiTietCuaHocSinh.Visible = true;
    }

    protected void btnShowKetQuaLamBaitapHocSinh_ServerClick(object sender, EventArgs e)
    {
        div_BangDiemChiTietCuaHocSinh.Visible = true;
        div_BangDiemChiTietCuaTungBaiTapHocSinh.Visible = false;
        var listBangDiemChiTietHocSinh = from t in db.tbTracNghiem_Tests 
                                         join lt in db.tbTracNghiem_BaiLuyenTaps on t.luyentap_id equals lt.luyentap_id
                                         join kq in db.tbTracNghiem_ResultTests on t.test_id equals kq.test_id
                                         where kq.hocsinh_code == txtMaHocSinh.Value
                                         group t by t.test_id into g
                                         select new
                                         {
                                             test_id= g.Key,
                                             hocsinh_name = (from hs in db.tbHocSinhs
                                                             join kq in db.tbTracNghiem_ResultTests on hs.hocsinh_code equals kq.hocsinh_code
                                                             where kq.test_id == g.Key && kq.hocsinh_code==txtMaHocSinh.Value select hs).First().hocsinh_name,
                                             luyentap_name = (from lt in db.tbTracNghiem_BaiLuyenTaps 
                                                             join t in db.tbTracNghiem_Tests on lt.luyentap_id equals t.luyentap_id
                                                             where t.test_id == g.Key select lt).First().luyentap_name,
                                             hocsinh_solanlambai = (from dct in db.tbTracNghiem_ResultTests where dct.test_id == g.Key && dct.hocsinh_code==txtMaHocSinh.Value select dct).Count(),
                                             luyentap_tinhtrang = "Tốt",
                                             hocsinh_code = txtMaHocSinh.Value,
                                         };
        rpBangDiemChiTietCuaHocSinh.DataSource = listBangDiemChiTietHocSinh;
        rpBangDiemChiTietCuaHocSinh.DataBind();
    }

    protected void btnShowketQuaDiemBaiTapCuaTungHocSinh_ServerClick(object sender, EventArgs e)
    {
        div_BangDiemChiTietCuaTungBaiTapHocSinh.Visible = true;
        var listBangDiemChiTietBaiTapcuaTungHocSinh = from t in db.tbTracNghiem_Tests
                                                      join lt in db.tbTracNghiem_BaiLuyenTaps on t.luyentap_id equals lt.luyentap_id
                                                      join kq in db.tbTracNghiem_ResultTests on t.test_id equals kq.test_id
                                                      join hs in db.tbHocSinhs on kq.hocsinh_code equals hs.hocsinh_code
                                                      where kq.test_id == Convert.ToInt32(txtTest.Value) && kq.lop_id == Convert.ToInt16(txtLop.Value) && kq.hocsinh_code==txtMaHocSinh.Value
                                                      select new
                                                      {
                                                          hs.hocsinh_name,
                                                          lt.luyentap_name,
                                                          kq.resulttest_id,
                                                          kq.resulttest_result,
                                                          kq.resulttest_datetime,
                                                          kq.result_thoigianlambai
                                                      };
        rpBangDiemChiTietCuaTungBaiTapHocSinh.DataSource = listBangDiemChiTietBaiTapcuaTungHocSinh;
        rpBangDiemChiTietCuaTungBaiTapHocSinh.DataBind();
        // show popup
        var getData = from bd in db.tbTracNghiem_ResultTests
                      join hs in db.tbHocSinhs on bd.hocsinh_code equals hs.hocsinh_code
                      join t in db.tbTracNghiem_Tests on bd.test_id equals t.test_id
                      join k in db.tbKhois on t.khoi_id equals k.khoi_id
                      join mh in db.tbMonHocs on t.monhoc_id equals mh.monhoc_id
                      join c in db.tbTracNghiem_BaiLuyenTaps on t.username_id equals c.username_id
                      where bd.hocsinh_code == txtMaHocSinh.Value
                      // type = 2 kết quả luyện tập
                      && bd.result_type == 2
                      orderby bd.resulttest_id descending
                      select new
                      {
                          bd.hocsinh_code,
                          hs.hocsinh_name,
                          bd.resulttest_result,
                          bd.resulttest_datetime,
                          bd.resulttest_id,
                          c.luyentap_name,
                          k.khoi_name,
                          mh.monhoc_name,
                      };
        rpPopupChiTiet.DataSource = getData;
        rpPopupChiTiet.DataBind();
    }
    protected void rpPopupChiTiet_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rpBangDiemDetails = e.Item.FindControl("rpBangDiemDetails") as Repeater;
        int listChecked = int.Parse(DataBinder.Eval(e.Item.DataItem, "resulttest_id").ToString());
        var getDataDetails = from ctkq in db.tbTracNghiem_ResultChiTiets
                             join kq in db.tbTracNghiem_ResultTests on ctkq.resulttest_id equals kq.resulttest_id
                             //join asd in db.tbTracNghiem_Answers on ctkq.answer_true_id equals asd.answer_id
                             join ch in db.tbTracNghiem_Questions on ctkq.question_id equals ch.question_id
                             where kq.resulttest_id == listChecked
                             select new
                             {
                                 noidungcauhoi = ch.question_content.Contains("style=") ? "<div class='content_image'>" + ch.question_content + "</div>" : ch.question_content.Contains(".jpg") ? "<img class='tracnghiem-answer__image' src='" + ch.question_content + "'>" : ch.question_content.Contains(".png") ? "<img class='tracnghiem-answer__image' src='" + ch.question_content + "'>" : ch.question_content.Contains(".mp3") ? " <audio controls> <source src = '" + ch.question_content + "'> </audio>" : ch.question_content,
                                 content_dapandung = (from ans in db.tbTracNghiem_Answers
                                                      where ans.answer_id.ToString() == ctkq.answer_true_id
                                                      select ans.answer_content).SingleOrDefault(),
                                 content_dapanchon = (from ans in db.tbTracNghiem_Answers
                                                      where ans.answer_id.ToString() == ctkq.answer_checked_id
                                                      select ans.answer_content).SingleOrDefault()
                             };
        rpBangDiemDetails.DataSource = getDataDetails;
        rpBangDiemDetails.DataBind();
    }
    protected void btnShowBieuDo_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("admin-thong-ke-bieu-do-"+txtMaHocSinh.Value);
    }
}