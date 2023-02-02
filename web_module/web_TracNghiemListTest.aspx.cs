using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_web_TracNghiemListTest : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();

    protected void Page_Load(object sender, EventArgs e)
    {
        int _idChapter = Convert.ToInt32(RouteData.Values["chapter_id"]);
        // int _idMon = Convert.ToInt32(RouteData.Values["id_mon"]);
        var checkMon = (from ct in db.tbTracNghiem_Chapters
                        join mh in db.tbMonHocs on ct.monhoc_id equals mh.monhoc_id
                        where ct.chapter_id == _idChapter
                        select mh).FirstOrDefault();
        string hocsinh_code = Request.Cookies["User_name"].Value;
        if (checkMon.monhoc_name.Contains("B1"))
        {
            //var check = from rsct in db.tbTracNghiem_ResultChiTiets
            //            join rs in db.tbTracNghiem_ResultTests on rsct.resulttest_id equals rs.resulttest_id
            //            where rs.test_id == 166 && rsct.resultchitiet_point != null && rs.hocsinh_code == Request.Cookies["User_name"].Value
            //           select rsct;

            var getData = from t in db.tbTracNghiem_Tests
                          join c in db.tbTracNghiem_BaiThiCates
                          on t.baithicate_id equals c.baithicate_id
                          where t.lesson_id == _idChapter
                          && t.hidden == false
                          select new
                          {
                              c.baithicate_id,
                              c.baithicate_name,
                              t.test_show,
                              t.monhoc_id,
                              t.test_id,
                              // khoi_id = _idKhoi,
                              //kiểm tra xem đã làm chưa. nếu đã làm thì không cho làm tiếp
                              checktest = db.tbTracNghiem_ResultTests.Where(x => x.test_id == t.test_id && x.hocsinh_code == hocsinh_code && x.result_tinhtrang_chambai == "da cham bai").Count() > 0 ? "dalambai" : c.baithicate_name.ToLower().Contains("speaking") ? "" : db.tbTracNghiem_ResultTests.Any(x => x.test_id == t.test_id && x.hocsinh_code == hocsinh_code) ? "dalambai" : "",
                              test_link = c.baithicate_name.ToLower().Contains("reading") ? "/bai-kiem-tra-reading-" + t.khoi_id + "/bai-kiem-tra-chi-tiet/" + c.baithicate_name + "/" + t.test_id + ".html" : c.baithicate_name.ToLower().Contains("listening") ? "/bai-kiem-tra-listening-" + t.khoi_id + "/bai-kiem-tra-chi-tiet/" + c.baithicate_name + "/" + t.test_id + ".html" : c.baithicate_name.ToLower().Contains("speaking") ? "/bai-kiem-tra-speaking-" + t.khoi_id + "/bai-kiem-tra-chi-tiet/" + c.baithicate_name + "/" + t.test_id + ".html" : c.baithicate_name.ToLower().Contains("writing") ? "/bai-kiem-tra-writing-" + t.khoi_id + "/bai-kiem-tra-chi-tiet/" + c.baithicate_name + "/" + t.test_id + ".html" : "",
                          };
            //http://tracnghiem.vietnhatschool.edu.vn/bai-kiem-tra-reading-18/bai-kiem-tra-chi-tiet/Reading/166.html
            rpTracNghiemListTest.DataSource = getData;
            rpTracNghiemListTest.DataBind();
        }
        else if (checkMon.monhoc_name.Contains("A2"))
        {
            var getData = from t in db.tbTracNghiem_Tests
                          join c in db.tbTracNghiem_BaiThiCates
                          on t.baithicate_id equals c.baithicate_id
                          where t.lesson_id == _idChapter
                          && t.hidden == false
                          select new
                          {
                              c.baithicate_id,
                              c.baithicate_name,
                              t.test_show,
                              t.monhoc_id,
                              t.test_id,
                              // khoi_id = _idKhoi,
                              //kiểm tra xem đã làm chưa. nếu đã làm thì không cho làm tiếp
                              checktest = db.tbTracNghiem_ResultTests.Where(x => x.test_id == t.test_id && x.hocsinh_code == hocsinh_code && x.result_tinhtrang_chambai == "da cham bai").Count() > 0 ? "dalambai" : c.baithicate_name.ToLower().Contains("speaking") ? "" : db.tbTracNghiem_ResultTests.Any(x => x.test_id == t.test_id && x.hocsinh_code == hocsinh_code) ? "dalambai" : "",
                              test_link = c.baithicate_name.ToLower().Contains("reading") ? "kiem-tra-a2/bai-kiem-tra-reading-writing-" + t.khoi_id + "/" + t.test_id + ".html" : c.baithicate_name.ToLower().Contains("listening") ? "kiem-tra-a2/bai-kiem-tra-listening-" + t.khoi_id + "/" + t.test_id + ".html" : c.baithicate_name.ToLower().Contains("speaking") ? "kiem-tra-a2/bai-kiem-tra-speaking-" + t.khoi_id + "/" + t.test_id + ".html" : "",
                          };
            //http://tracnghiem.vietnhatschool.edu.vn/bai-kiem-tra-reading-18/bai-kiem-tra-chi-tiet/Reading/166.html
            rpTracNghiemListTest.DataSource = getData;
            rpTracNghiemListTest.DataBind();
        }



    }

}