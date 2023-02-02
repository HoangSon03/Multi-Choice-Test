using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_web_MaTranDeThi_Detail_Version2 : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public int STT = 1;
    public int STT1 = 1;
    //public int STTTraLoi;
    public int count = 0;
    public int sum_count_NB_TN = 0;
    public int sum_count_NB_TL = 0;
    public int sum_count_TH_TN = 0;
    public int sum_count_TH_TL = 0;
    public int sum_count_VD_TN = 0;
    public int sum_count_VD_TL = 0;
    public int sum_count_VDC_TN = 0;
    public int sum_count_VDC_TL = 0;
    public double tileNhanBiet = 0;
    public double tileThongHieu = 0;
    public double tileVanDung = 0;
    public double tileVanDungCao = 0;
    //public double TiLeChung1 = 0;
    //public double TiLeChung2 = 0;
    int question_id;
    public double seconds = 0.0;
    cls_Alert alert = new cls_Alert();
    private static int _idUser;
    // Roudata 281
    int id_test = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        id_test = Convert.ToInt32(RouteData.Values["id_test"]);
        //kiểm tra xem user nào đang truy cập
        if (!IsPostBack)
        {
            // _idUser = Convert.ToInt32(RouteData.Values["user_id"]);
            _idUser = 51;
            if (_idUser != 0)
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
        Random rnd = new Random();
        int seed = rnd.Next();
        var getDataDetails = from td in db.tbTracNghiem_TestDetails
                             join q in db.tbTracNghiem_Questions on td.question_id equals q.question_id
                             where td.test_id == id_test
                             select new
                             {
                                 td.question_id,
                                 noidungcauhoi = q.question_content.Contains("style=") ? "<div class='content_image'>" + q.question_content + "'</div>" : q.question_content.Contains("jpg") ? "<img class='tracnghiem-answer__image' src='" + q.question_content + "'>" : q.question_content.Contains("png") ? "<img class='tracnghiem-answer__image' src='" + q.question_content + "'>" : q.question_content.Contains("mp3") ? " <audio controls> <source src = '" + q.question_content + "'> </audio>" : q.question_content,
                             };
        getDataDetails = getDataDetails.OrderBy(x => (~(x.question_id & seed)) & (x.question_id | seed));
        rpCauHoiDetals.DataSource = getDataDetails;
        rpCauHoiDetals.DataBind();

        var getMaTran = from mt in db.tbTracNghiem_MaTraDeThis
                        join lt in db.tbTracNghiem_BaiLuyenTaps on mt.matrade_id equals lt.matrande_id
                        join t in db.tbTracNghiem_Tests on lt.luyentap_id equals t.luyentap_id
                        where t.test_id == id_test
                        select mt;
        //int sum_count_NB_TN = 0;
        // nội dung kiến thức sẽ có nhiều bài được chọn

        var listDanhSachBai = from ls in db.tbTracNghiem_Lessons
                              where ls.lesson_name == ""
                              select ls;

        string[] arrListLesson = getMaTran.FirstOrDefault().tracnghiem_noidung_kienthuc.Split(',');
        // duyệt từng bài để lấy ra câu hỏi
        foreach (string item in arrListLesson)
        {
            var getTungBai = from ls in db.tbTracNghiem_Lessons
                             where ls.lesson_id == Convert.ToInt16(item)
                             select ls;
            // add các bài vào trong 1 list
            listDanhSachBai = listDanhSachBai.Union(getTungBai);
            //listDanhSachBai.Except(getTungBai);
        }
        var list = from le in listDanhSachBai
                   join ch in db.tbTracNghiem_Chapters on le.chapter_id equals ch.chapter_id
                 
                   select new
                   {
                       
                       le.lesson_id,
                       le.lesson_name,
                       ch.chapter_name,
                   };
        //}
        rpMaTranDeThi.DataSource = list;
        rpMaTranDeThi.DataBind();

        tileNhanBiet = (double)(((getMaTran.FirstOrDefault().tracnghiem_nhanbiet ?? 0) + (getMaTran.FirstOrDefault().tuluan_nhanbiet ?? 0)) * 10);
        tileThongHieu = (double)(((getMaTran.FirstOrDefault().tracnghiem_thonghieu ?? 0) + (getMaTran.FirstOrDefault().tuluan_thonghieu ?? 0)) * 10);
        tileVanDung = (double)(((getMaTran.FirstOrDefault().tracnghiem_vandung ?? 0) + (getMaTran.FirstOrDefault().tuluan_vandung ?? 0)) * 10);
        tileVanDungCao = (double)(((getMaTran.FirstOrDefault().tracnghiem_vandungcao ?? 0) + (getMaTran.FirstOrDefault().tuluan_vandungcao ?? 0)) * 10);
        // Đặc tả ma trận
        // Kiểm tra số câu hỏi có trong bài để get ra nội dung đăc tả bài đó
        // Sau đó add vào list
        //id_test = Convert.ToInt32(RouteData.Values["id_test"]);
        var listDacTa = from testdt in db.tbTracNghiem_TestDetails
                        join q in db.tbTracNghiem_Questions on testdt.question_id equals q.question_id
                        join dt in db.tbTracNghiem_DacTas on Convert.ToInt32(q.question_dacta) equals dt.dacta_id
                        where testdt.test_id == id_test
                        group dt by dt.dacta_id into g
                        select new
                        {
                            dacta_id = g.Key,
                            lesson_id = (from c in db.tbTracNghiem_Lessons
                                         join dt in db.tbTracNghiem_DacTas on c.lesson_id equals dt.lession_id
                                         where dt.dacta_id == g.Key
                                         select c.lesson_id).FirstOrDefault(),
                            chapter_name = (from c in db.tbTracNghiem_Chapters
                                            join dt in db.tbTracNghiem_DacTas on c.chapter_id equals dt.chapter_id
                                            where dt.dacta_id == g.Key
                                            select c.chapter_name).FirstOrDefault(),
                            //chapter_count = 17,
                            lesson_name = (from c in db.tbTracNghiem_Lessons
                                           join dt in db.tbTracNghiem_DacTas on c.lesson_id equals dt.lession_id
                                           where dt.dacta_id == g.Key
                                           select c.lesson_name).FirstOrDefault(),
                            dacta_content = (from dt in db.tbTracNghiem_DacTas where dt.dacta_id == g.Key select dt.dacta_content).SingleOrDefault(),
                           
                        };
        rpDacTa.DataSource = listDacTa;
        rpDacTa.DataBind();
    }

    protected void rpCauHoiDetals_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //STTTraLoi = 1;
        // int STTT = 1;
        Random rnd = new Random();
        int seed = rnd.Next();
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
        getDataCauTraLoi = getDataCauTraLoi.OrderBy(x => (~(x.answer_id & seed)) & (x.answer_id | seed));
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
                //insertDetail.answer_true_id = (from t in db.tbTracNghiem_Answers
                //                               where t.question_id == Convert.ToInt32(arrID[index]) && t.answer_true == true
                //                               select t.answer_id).FirstOrDefault();
                //if (arrlistChecked[index] == "")
                //    insertDetail.answer_checked_id = 0;
                //else
                //    insertDetail.answer_checked_id = Convert.ToInt32(arrlistChecked[index]);
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

    protected void rpMaTranDeThi_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        id_test = Convert.ToInt32(RouteData.Values["id_test"]);
        Repeater rpMaTranChiTiet = e.Item.FindControl("rpMaTranChiTiet") as Repeater;
        int lesson_id = int.Parse(DataBinder.Eval(e.Item.DataItem, "lesson_id").ToString());
        rpMaTranChiTiet.DataSource = from ct in db.tbTracNghiem_MaTranChiTiets
                                     where ct.lession_id == lesson_id && ct.test_id == id_test
                                     select ct;
        rpMaTranChiTiet.DataBind();
    }

    protected void rpDacTa_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
       
        //id_test = Convert.ToInt32(RouteData.Values["id_test"]);
        //Repeater rpDetailDangCauHoi = e.Item.FindControl("rpDetailDangCauHoi") as Repeater;
        //int lesson_id = int.Parse(DataBinder.Eval(e.Item.DataItem, "lesson_id").ToString());
        //    var getChuong = from c in db.tbTracNghiem_TestDetails
        //                    join q in db.tbTracNghiem_Questions on c.question_id equals q.question_id
        //                    join l in db.tbTracNghiem_Lessons on q.lesson_id equals l.lesson_id
        //                    where l.lesson_id == lesson_id && c.test_id == id_test
        //                    select new
        //                    {
        //                        question_nhanbiet = 
                                
        //                    };
        //    rpDetailDangCauHoi.DataSource = getChuong;
        //    rpDetailDangCauHoi.DataBind();
         
        


    }

  

}