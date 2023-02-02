using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_web_BangDiem : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public int STT = 1;
    public int STTs = 1;
    public string date = "dfghj";
    protected void Page_Load(object sender, EventArgs e)
    {

        //var lishs = from hs in dbhs.tbHocSinhs
        //            select new
        //            {
        //                hs.hocsinh_code,
        //                hs.hocsinh_name,
        //                hs.hocsinh_gioitinh,
        //            };
        //var listdiem = from d in db.tbTracNghiem_ResultTests
        //               select new
        //               {
        //                   d.hocsinh_code,
        //                   d.resulttest_result,
        //               };
        //var reuslt = from hs in lishs
        //             join rs in listdiem on hs.hocsinh_code equals rs.hocsinh_code
        //             select new
        //             {
        //                 hs.hocsinh_code,
        //                 hs.hocsinh_name,
        //                 hs.hocsinh_gioitinh,
        //                 rs.resulttest_result
        //             };
        //rpList.DataSource = lishs;
        //rpList.DataBind();


        var getData = from bd in db.tbTracNghiem_ResultTests
                          //join ct in db.tbTracNghiem_ResultChiTiets on bd.resulttest_id equals ct.resulttest_id
                      join hs in db.tbHocSinhs on bd.hocsinh_code equals hs.hocsinh_code
                      join t in db.tbTracNghiem_Tests on bd.test_id equals t.test_id
                      join c in db.tbTracNghiem_BaiThiCates on t.baithicate_id equals c.baithicate_id
                      join k in db.tbKhois on t.khoi_id equals k.khoi_id
                      join mh in db.tbMonHocs on t.monhoc_id equals mh.monhoc_id
                      where bd.hocsinh_code == Request.Cookies["User_name"].Value
                      && bd.result_type == 1
                      select new
                      {
                          bd.hocsinh_code,
                          hs.hocsinh_name,
                          bd.resulttest_result,
                          bd.resulttest_datetime,
                          bd.resulttest_id,
                          c.baithicate_name,
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
        //STTs = 1;
        Repeater rpBangDiemDetails = e.Item.FindControl("rpBangDiemDetails") as Repeater;
        int listChecked = int.Parse(DataBinder.Eval(e.Item.DataItem, "resulttest_id").ToString());
        var checkMon = (from rt in db.tbTracNghiem_ResultTests
                        join t in db.tbTracNghiem_Tests on rt.test_id equals t.test_id
                        where rt.resulttest_id == listChecked
                        select t).FirstOrDefault().monhoc_id;

        if (checkMon == 74)
        {
            var checkDangBai = (from rt in db.tbTracNghiem_ResultTests
                                join t in db.tbTracNghiem_Tests on rt.test_id equals t.test_id
                                join cate in db.tbTracNghiem_BaiThiCates on t.baithicate_id equals cate.baithicate_id
                                where rt.resulttest_id == listChecked
                                select cate).FirstOrDefault();

            if (checkDangBai.baithicate_name.ToLower().Contains("reading") || checkDangBai.baithicate_name.ToLower().Contains("writing"))
            {
                //get trac nghiem
                var getPart1 = (from ctkq in db.tbTracNghiem_ResultChiTiets
                                join ch in db.tbTracNghiem_EnglishQuestions on ctkq.question_id equals ch.englishquestion_id
                                where ctkq.resulttest_id == listChecked && ctkq.answer_true_id != null
                                select new
                                {
                                    result_id = ctkq.resultchitiet_id,
                                    noidungcauhoi = ch.englishquestion_content.Contains("style=") ? "<div class='content_image'>" + ch.englishquestion_content + "</div>" : ch.englishquestion_content.Contains(".jpg") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains(".png") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains(".mp3") ? " <audio controls> <source src = '" + ch.englishquestion_content + "'> </audio>" : ch.englishquestion_content,
                                    content_dapandung = (from ans in db.tbTracNghiem_Answers
                                                         where ans.answer_id == Convert.ToInt32(ctkq.answer_true_id)
                                                         select ans.answer_content).SingleOrDefault(),
                                    content_dapanchon = (from ans in db.tbTracNghiem_Answers
                                                         where Convert.ToString(ans.answer_id) == ctkq.answer_checked_id
                                                         select ans.answer_content).SingleOrDefault(),
                                    ctkq.result_part,
                                });
                //get tự luận
                var getPart2 = from rs in db.tbTracNghiem_ResultChiTiets
                               where rs.resulttest_id == listChecked && rs.question_id == null
                               select new
                               {
                                   result_id = rs.resultchitiet_id,
                                   noidungcauhoi = "",
                                   content_dapandung = rs.answer_true_id,
                                   content_dapanchon = rs.answer_checked_id,
                                   rs.result_part,
                               };
                var getPart3 = (from ctkq in db.tbTracNghiem_ResultChiTiets
                                join ch in db.tbTracNghiem_EnglishQuestions on ctkq.question_id equals ch.englishquestion_id
                                where ctkq.resulttest_id == listChecked && ctkq.answer_true_id == null
                                select new
                                {
                                    result_id = ctkq.resultchitiet_id,
                                    noidungcauhoi = ch.englishquestion_content,
                                    content_dapandung = "",
                                    content_dapanchon = ctkq.answer_checked_id,
                                    ctkq.result_part,
                                });
                var result = getPart1.Union(getPart2);
                var result1 = result.Union(getPart3);
                rpBangDiemDetails.DataSource = result1.OrderBy(x => x.result_part);
                rpBangDiemDetails.DataBind();
            }
            else if (checkDangBai.baithicate_name.ToLower().Contains("listening"))
            {
                //get trac nghiem
                var getPart1 = (from ctkq in db.tbTracNghiem_ResultChiTiets
                                join ch in db.tbTracNghiem_EnglishQuestions on ctkq.question_id equals ch.englishquestion_id
                                where ctkq.resulttest_id == listChecked && ctkq.answer_true_id != null
                                select new
                                {
                                    result_id = ctkq.resultchitiet_id,
                                    noidungcauhoi = ch.englishquestion_content.Contains("style=") ? "<div class='content_image'>" + ch.englishquestion_content + "</div>" : ch.englishquestion_content.Contains(".jpg") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains(".png") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains(".mp3") ? " <audio controls> <source src = '" + ch.englishquestion_content + "'> </audio>" : ch.englishquestion_content,
                                    content_dapandung = (from ans in db.tbTracNghiem_Answers
                                                         where ans.answer_id == Convert.ToInt32(ctkq.answer_true_id)
                                                         select ans.answer_content).SingleOrDefault(),
                                    content_dapanchon = (from ans in db.tbTracNghiem_Answers
                                                         where Convert.ToString(ans.answer_id) == ctkq.answer_checked_id
                                                         select ans.answer_content).SingleOrDefault(),
                                    ctkq.result_part,
                                });
                //get tự luận
                var getPart2 = from rs in db.tbTracNghiem_ResultChiTiets
                               where rs.resulttest_id == listChecked && rs.question_id == null
                               select new
                               {
                                   result_id = rs.resultchitiet_id,
                                   noidungcauhoi = "",
                                   content_dapandung = rs.answer_true_id,
                                   content_dapanchon = rs.answer_checked_id,
                                   rs.result_part,
                               };
                var result = getPart1.Union(getPart2);
                rpBangDiemDetails.DataSource = result.OrderBy(x => x.result_part);
                rpBangDiemDetails.DataBind();
            }
            else //speaking
            {
                var getDataDetails = from ctkq in db.tbTracNghiem_ResultChiTiets
                                     join ch in db.tbTracNghiem_EnglishQuestions on ctkq.question_id equals ch.englishquestion_id
                                     where ctkq.resulttest_id == listChecked
                                     select new
                                     {
                                         STTs = STTs + 1,
                                         noidungcauhoi = ch.englishquestion_content.Contains("style=") ? "<div class='content_image'>" + ch.englishquestion_content + "</div>" : ch.englishquestion_content.Contains(".jpg") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains(".png") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains(".mp3") ? " <audio controls> <source src = '" + ch.englishquestion_content + "'> </audio>" : ch.englishquestion_content,
                                         content_dapandung = (from ans in db.tbTracNghiem_Answers
                                                              where ans.answer_id == Convert.ToInt32(ctkq.answer_true_id)
                                                              select ans.answer_content).SingleOrDefault(),
                                         content_dapanchon = " <audio controls> <source src = '" + ctkq.answer_checked_id + "'> </audio>"
                                     };
                rpBangDiemDetails.DataSource = getDataDetails;
                rpBangDiemDetails.DataBind();
            }


        }
        else if (checkMon == 72)
        {
            //kiểm tra phần bài làm đó là phần nào
            var checkDangBai = (from rt in db.tbTracNghiem_ResultTests
                                join t in db.tbTracNghiem_Tests on rt.test_id equals t.test_id
                                join cate in db.tbTracNghiem_BaiThiCates on t.baithicate_id equals cate.baithicate_id
                                where rt.resulttest_id == listChecked
                                select cate).FirstOrDefault();

            if (checkDangBai.baithicate_name.ToLower().Contains("writing"))
            {
                var getDataDetails = from ctkq in db.tbTracNghiem_ResultChiTiets
                                     join ch in db.tbTracNghiem_EnglishQuestions on ctkq.question_id equals ch.englishquestion_id
                                     where ctkq.resulttest_id == listChecked
                                     select new
                                     {
                                         STTs = STTs + 1,
                                         noidungcauhoi = ch.englishquestion_content.Contains("style=") ? "<div class='content_image'>" + ch.englishquestion_content + "</div>" : ch.englishquestion_content.Contains(".jpg") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains(".png") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains(".mp3") ? " <audio controls> <source src = '" + ch.englishquestion_content + "'> </audio>" : ch.englishquestion_content,
                                         content_dapandung = (from ans in db.tbTracNghiem_Answers
                                                              where ans.answer_id == Convert.ToInt32(ctkq.answer_true_id)
                                                              select ans.answer_content).SingleOrDefault(),
                                         content_dapanchon = ctkq.answer_checked_id
                                     };
                rpBangDiemDetails.DataSource = getDataDetails;
                rpBangDiemDetails.DataBind();
            }
            else if (checkDangBai.baithicate_name.ToLower().Contains("speaking"))
            {
                var getDataDetails = from ctkq in db.tbTracNghiem_ResultChiTiets
                                     join ch in db.tbTracNghiem_EnglishQuestions on ctkq.question_id equals ch.englishquestion_id
                                     where ctkq.resulttest_id == listChecked
                                     select new
                                     {
                                         STTs = STTs + 1,
                                         noidungcauhoi = ch.englishquestion_content.Contains("style=") ? "<div class='content_image'>" + ch.englishquestion_content + "</div>" : ch.englishquestion_content.Contains(".jpg") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains(".png") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains(".mp3") ? " <audio controls> <source src = '" + ch.englishquestion_content + "'> </audio>" : ch.englishquestion_content,
                                         content_dapandung = (from ans in db.tbTracNghiem_Answers
                                                              where ans.answer_id == Convert.ToInt32(ctkq.answer_true_id)
                                                              select ans.answer_content).SingleOrDefault(),
                                         content_dapanchon = " <audio controls> <source src = '" + ctkq.answer_checked_id + "'> </audio>"
                                     };
                rpBangDiemDetails.DataSource = getDataDetails;
                rpBangDiemDetails.DataBind();
            }
            else if (checkDangBai.baithicate_name.ToLower().Contains("reading")|| checkDangBai.baithicate_name.ToLower().Contains("listening"))
            {
                //get trac nghiem
                var getPart1 = (from ctkq in db.tbTracNghiem_ResultChiTiets
                                join ch in db.tbTracNghiem_EnglishQuestions on ctkq.question_id equals ch.englishquestion_id
                                where ctkq.resulttest_id == listChecked && ctkq.question_id > 0
                                select new
                                {
                                    result_id = ctkq.resultchitiet_id,
                                    noidungcauhoi = ch.englishquestion_content.Contains("style=") ? "<div class='content_image'>" + ch.englishquestion_content + "</div>" : ch.englishquestion_content.Contains(".jpg") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains(".png") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains(".mp3") ? " <audio controls> <source src = '" + ch.englishquestion_content + "'> </audio>" : ch.englishquestion_content,
                                    content_dapandung = (from ans in db.tbTracNghiem_Answers
                                                         where ans.answer_id == Convert.ToInt32(ctkq.answer_true_id)
                                                         select ans.answer_content).SingleOrDefault(),
                                    content_dapanchon = (from ans in db.tbTracNghiem_Answers
                                                         where ans.answer_id == Convert.ToInt32(ctkq.answer_checked_id)
                                                         select ans.answer_content).SingleOrDefault(),
                                    ctkq.result_part,
                                });
                //get tự luận
                var getPart2 = from rs in db.tbTracNghiem_ResultChiTiets
                               where rs.resulttest_id == listChecked && rs.question_id == null
                               select new
                               {
                                   result_id = rs.resultchitiet_id,
                                   noidungcauhoi = "",
                                   content_dapandung = rs.answer_true_id,
                                   content_dapanchon = rs.answer_checked_id,
                                   rs.result_part,
                               };
                //var getPart3= (from ctkq in db.tbTracNghiem_ResultChiTiets
                //               join ch in db.tbTracNghiem_EnglishQuestions on ctkq.question_id equals ch.englishquestion_id
                //               where ctkq.resulttest_id == listChecked
                //               select new
                //               {
                //                   //STTs = STTs + 1,
                //                   result_id = ctkq.resultchitiet_id,
                //                   noidungcauhoi = ch.englishquestion_content.Contains("style=") ? "<div class='content_image'>" + ch.englishquestion_content + "</div>" : ch.englishquestion_content.Contains(".jpg") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains(".png") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains(".mp3") ? " <audio controls> <source src = '" + ch.englishquestion_content + "'> </audio>" : ch.englishquestion_content,
                //                   content_dapandung = (from ans in db.tbTracNghiem_Answers
                //                                        where ans.answer_id == Convert.ToInt32(ctkq.answer_true_id)
                //                                        select ans.answer_content).SingleOrDefault(),
                //                   content_dapanchon = (from ans in db.tbTracNghiem_Answers
                //                                        where ans.answer_id == Convert.ToInt32(ctkq.answer_checked_id)
                //                                        select ans.answer_content).SingleOrDefault()
                //               }).Skip(5).Take(5);
                var result = getPart1.Union(getPart2); //.Union(getPart2)
                //var getDataDetails = from ctkq in db.tbTracNghiem_ResultChiTiets
                //                     join ch in db.tbTracNghiem_EnglishQuestions on ctkq.question_id equals ch.englishquestion_id
                //                     where ctkq.resulttest_id == listChecked
                //                     select new
                //                     {
                //                         STTs = STTs + 1,
                //                         noidungcauhoi = ch.englishquestion_content.Contains("style=") ? "<div class='content_image'>" + ch.englishquestion_content + "</div>" : ch.englishquestion_content.Contains(".jpg") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains(".png") ? "<img class='tracnghiem-answer__image' src='" + ch.englishquestion_content + "'>" : ch.englishquestion_content.Contains(".mp3") ? " <audio controls> <source src = '" + ch.englishquestion_content + "'> </audio>" : ch.englishquestion_content,
                //                         content_dapandung = (from ans in db.tbTracNghiem_Answers
                //                                              where ans.answer_id == Convert.ToInt32(ctkq.answer_true_id)
                //                                              select ans.answer_content).SingleOrDefault(),
                //                         content_dapanchon = (from ans in db.tbTracNghiem_Answers
                //                                              where ans.answer_id == Convert.ToInt32(ctkq.answer_checked_id)
                //                                              select ans.answer_content).SingleOrDefault()
                //                     };
                rpBangDiemDetails.DataSource = result.OrderBy(x => x.result_part);
                rpBangDiemDetails.DataBind();
            }
            else
            {

            }
        }
    }
}