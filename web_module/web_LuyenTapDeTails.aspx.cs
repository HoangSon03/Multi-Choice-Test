using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_web_LuyenTapDetails : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public int STT = 1;
    //public int STTTraLoi;
    public int count = 0;
    int question_id;
    public double seconds = 0.0;
    cls_Alert alert = new cls_Alert();
    private static int  _idUser;
    protected void Page_Load(object sender, EventArgs e)
    {
        //kiểm tra xem user nào đang truy cập
        if(!IsPostBack)
        {
            _idUser = Convert.ToInt32(RouteData.Values["user_id"]);
            if(_idUser != 0)
            {
                div_BtnNopBai.Visible = false;
                div_NhacNho.Visible = false;
            }
            else 
            {
                btnInDe.Visible = false;
                div_BaiTap.Visible = false;
            }
        }

        var getLinkVideo = (from blt in db.tbTracNghiem_BaiLuyenTaps
                            join td in db.tbTracNghiem_Tests on blt.luyentap_id equals td.luyentap_id
                            where td.test_id == Convert.ToInt32(RouteData.Values["id_test"])
                            select blt).Take(1);
            rpLinkVideo.DataSource = getLinkVideo;
            rpLinkVideo.DataBind();
            rpBaiTapTuaLuan.DataSource = getLinkVideo;
            rpBaiTapTuaLuan.DataBind();
        if (getLinkVideo.Single().luyentap_linkvideo == "")
        {
            div_LinkVideo.Visible = false;
        }

        var getDataDetails = from td in db.tbTracNghiem_TestDetails
                             join q in db.tbTracNghiem_Questions
                             on td.question_id equals q.question_id
                             where td.test_id == Convert.ToInt32(RouteData.Values["id_test"])
                             select new
                             {

                                 td.question_id,
                                 noidungcauhoi = q.question_content.Contains("style=") ? "<div class='content_image'>" + q.question_content + "'</div>" : q.question_content.Contains("jpg") ? "<img class='tracnghiem-answer__image' src='" + q.question_content + "'>" : q.question_content.Contains("png") ? "<img class='tracnghiem-answer__image' src='" + q.question_content + "'>" : q.question_content.Contains("mp3") ? " <audio controls> <source src = '" + q.question_content + "'> </audio>" : q.question_content
                             };
        rpCauHoiDetals.DataSource = getDataDetails;
        rpCauHoiDetals.DataBind();
        count = getDataDetails.Count();
    }

    protected void rpCauHoiDetals_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //STTTraLoi = 1;
        // int STTT = 1;
        Repeater rpCauTraLoi = e.Item.FindControl("rpCauTraLoi") as Repeater;
        question_id = int.Parse(DataBinder.Eval(e.Item.DataItem, "question_id").ToString());
        var getDataCauTraLoi = from t in db.tbTracNghiem_Answers
                               where t.question_id == question_id
                               select new
                               {
                                   //STTTraLoi = STTT+ 1,
                                   //kitu = STTTraLoi == 1 ? "A." : STTTraLoi == 2 ? "B." : STTTraLoi == 3 ? "C." : "D.",
                                   t.answer_id,
                                   t.answer_content,
                                   t.answer_true,
                                   t.question_id
                               };
        rpCauTraLoi.DataSource = getDataCauTraLoi;
        rpCauTraLoi.DataBind();
    }
    protected void btnNopBai_Click(object sender, EventArgs e)
    {
        try
        {
            //gán thời gian làm bài từ client về db
            string time;
            TimeSpan s = TimeSpan.FromSeconds(Convert.ToDouble(txtFinish.Value));
            time = s.ToString();

            //int _idKhoi = Convert.ToInt32(RouteData.Values["id_khoi"]);
            tbTracNghiem_ResultTest insert = new tbTracNghiem_ResultTest();
            insert.resulttest_result = txtSoCauDung.Value;
            insert.hocsinh_code = Request.Cookies["User_name"].Value;
            insert.resulttest_datetime = DateTime.Now;
            insert.test_id = Convert.ToInt32(RouteData.Values["id_test"]);
            insert.result_thoigianlambai = time;
            //result_type =1 là bài kiểm tra, = 2 là bài luyện tập
            insert.lop_id = Convert.ToInt32(RouteData.Values["id_khoi"]);
            insert.result_type = 2;
            db.tbTracNghiem_ResultTests.InsertOnSubmit(insert);
            db.SubmitChanges();

            //khai báo biến chứa ds ID câu tl được checked
            string listChecked = txtChecked.Value;
            string[] arrlistChecked = listChecked.Split(',');
            //khai báo biến chứa ds ID câu hỏi
            string listID = txtIDQuestion.Value;
            string[] arrID = listID.Split(',');
            for (int index = 0; index < arrID.Length; index++)
            {
                tbTracNghiem_ResultChiTiet insertDetail = new tbTracNghiem_ResultChiTiet();
                insertDetail.resulttest_id = insert.resulttest_id;
                insertDetail.question_id = Convert.ToInt32(arrID[index]);
                //var getDataCauTraLoi = (from t in db.tbTracNghiem_Answers
                //                        where t.question_id == Convert.ToInt32(arrID[index]) && t.answer_true == true
                //                        select t).FirstOrDefault();
                insertDetail.answer_true_id = (from t in db.tbTracNghiem_Answers
                                               where t.question_id == Convert.ToInt32(arrID[index]) && t.answer_true == true
                                               select t.answer_id).FirstOrDefault();
                if (arrlistChecked[index] == "")
                    insertDetail.answer_checked_id = 0;
                else
                    insertDetail.answer_checked_id = Convert.ToInt32(arrlistChecked[index]);
                db.tbTracNghiem_ResultChiTiets.InsertOnSubmit(insertDetail);
                db.SubmitChanges();
            }
            alert.alert_Success(Page, "Nộp bài thành công!", "");
        }
        catch (Exception)
        {
            alert.alert_Error(Page, "Đã xảy ra lỗi!", "Vui lòng liên hệ bộ phận hỗ trợ");
        }
    }

    protected void btnLamBai_Click(object sender, EventArgs e)
    {
        div_BaiTap.Visible = true;
    }
}