using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_web_KetQuaLuyenTap : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public int STT = 1;
    public int STTs = 1;
    public string date = "dfghj";
    protected void Page_Load(object sender, EventArgs e)
    {
        var getData = from bd in db.tbTracNghiem_ResultTests
                      join hs in db.tbHocSinhs on bd.hocsinh_code equals hs.hocsinh_code
                      join t in db.tbTracNghiem_Tests on bd.test_id equals t.test_id
                      join k in db.tbKhois on t.khoi_id equals k.khoi_id
                      join mh in db.tbMonHocs on t.monhoc_id equals mh.monhoc_id
                      join c in db.tbTracNghiem_BaiLuyenTaps on t.luyentap_id equals c.luyentap_id
                      where bd.hocsinh_code == Request.Cookies["User_name"].Value
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
        rpBangDiem.DataSource = getData;
        rpBangDiem.DataBind();
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
                                                      where ans.answer_id == ctkq.answer_true_id
                                                      select ans.answer_content).SingleOrDefault(),
                                 content_dapanchon = (from ans in db.tbTracNghiem_Answers
                                                      where ans.answer_id == ctkq.answer_checked_id
                                                      select ans.answer_content).SingleOrDefault()
                             };
        rpBangDiemDetails.DataSource = getDataDetails;
        rpBangDiemDetails.DataBind();
    }
}