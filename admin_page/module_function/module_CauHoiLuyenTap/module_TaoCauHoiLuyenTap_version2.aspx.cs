using DevExpress.Web.ASPxHtmlEditor;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_CauHoiLuyenTap_module_TaoCauHoiLuyenTap_version2 : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();

    private static int _idKhoi;
    private static int _idMonHoc;
    protected void Page_Load(object sender, EventArgs e)
    {
        var checkTaiKhoan = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).FirstOrDefault();
        if (!IsPostBack)
        {
            var getkhoi = from ldt in db.tbKhois
                          join gvdk in db.tbGiaoVienDayKhois on ldt.khoi_id equals gvdk.khoi_id
                          where gvdk.username_id == checkTaiKhoan.username_id
                          select ldt;
            ddlKhoi.DataValueField = "khoi_id";
            ddlKhoi.DataTextField = "khoi_name";
            ddlKhoi.DataSource = getkhoi;
            ddlKhoi.DataBind();
            var listMon = from gvdm in db.tbGiaoVienDayMons
                          join m in db.tbMonHocs on gvdm.monhoc_id equals m.monhoc_id
                          where gvdm.username_id == checkTaiKhoan.username_id
                          select m;
            ddlMon.DataSource = listMon;
            ddlMon.DataTextField = "monhoc_name";
            ddlMon.DataValueField = "monhoc_id";
            ddlMon.DataBind();
            var listChuDe = from c in db.tbTracNghiem_Chapters
                            where c.khoi_id == Convert.ToInt16(ddlKhoi.SelectedValue) && c.monhoc_id == Convert.ToInt16(ddlMon.SelectedValue)
                            select c;
            ddlChuong.DataSource = listChuDe;
            ddlChuong.DataTextField = "chapter_name";
            ddlChuong.DataValueField = "chapter_id";
            ddlChuong.DataBind();
            
        }
    }

    protected void ddlKhoi_SelectedIndexChanged(object sender, EventArgs e)
    {
        var listChuDe = from c in db.tbTracNghiem_Chapters
                        where c.khoi_id == Convert.ToInt16(ddlKhoi.SelectedValue) && c.monhoc_id == Convert.ToInt16(ddlMon.SelectedValue)
                        select c;
        ddlChuong.DataSource = listChuDe;
        ddlChuong.DataTextField = "chapter_name";
        ddlChuong.DataValueField = "chapter_id";
        ddlChuong.DataBind();
    }

    protected void ddlMon_SelectedIndexChanged(object sender, EventArgs e)
    {
        var listChuDe = from c in db.tbTracNghiem_Chapters
                        where c.khoi_id == Convert.ToInt16(ddlKhoi.SelectedValue) && c.monhoc_id == Convert.ToInt16(ddlMon.SelectedValue)
                        select c;
        ddlChuong.DataSource = listChuDe;
        ddlChuong.DataTextField = "chapter_name";
        ddlChuong.DataValueField = "chapter_id";
        ddlChuong.DataBind();
        _idMonHoc = Convert.ToInt32(ddlMon.SelectedValue);
        // ManageDivTracNghiem();
    }

    protected void ManageDivTracNghiem()
    {
        var getMon = (from mh in db.tbMonHocs
                      join mhck in db.tbMonHocCuaKhois on mh.monhoc_id equals mhck.monhoc_id
                      where mhck.khoi_id == _idKhoi
                      && mh.monhoc_id == _idMonHoc
                      select mh).First().monhoc_name;
    }

    protected void btnLuu_Click(object sender, EventArgs e)
    {
        if (txtHinhThucThi.Value == "1")
        {
            //Bước 1: Mục đích lấy id các câu hỏi đưa về 1 danh sách để chạy cho hàm Lưu kết quả
            getChuoiCauHoiTheoTiLeTracNghiem();
            // Bước 2: Sau khi lấy được danh sách id câu hỏi thì lưu về 3 bảng :
            // bảng luyện tâp để hiển thị lên website cho học sinh biết tên bài
            // bảng test để lưu ds câu hỏi ở bước 1
            // bảng chi tiết các câu hỏi được lưu vào bảng details
            LuuKetQuaTracNghiem();
        }
        if (txtHinhThucThi.Value == "2")
            getChuoiCauHoiTheoTiLeTuLuan();
        if (txtHinhThucThi.Value == "3")
            getChuoiCauHoiTheoTiLeTuLuanVaTracNghiem();
    }
    //protected void checkTiLeTracNghiem()
    //{
    //    // tỉ lệ ví dụ là NB4: TH4:VD2
    //    // Bước 1: lưu vào bảng luyện tập
    //    var checkuserid = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).First();
    //    tbTracNghiem_BaiLuyenTap insert = new tbTracNghiem_BaiLuyenTap();
    //    insert.luyentap_name = txtTenBai.Value;
    //    //insert.luyentap_linkvideo = str_first + str_code;
    //    insert.luyentap_status = 1;
    //    insert.username_id = checkuserid.username_id;
    //    db.tbTracNghiem_BaiLuyenTaps.InsertOnSubmit(insert);
    //    db.SubmitChanges();
    //    // Bước 2 : Lưu vào bảng test
    //    tbTracNghiem_Test test = new tbTracNghiem_Test();
    //    // các câu hỏi được lưu theo mảng chuỗi, để chạy được mảng chuỗi này phải tạo ra đoạn code tỉ lệ.
    //    //test.question_id = String.Join(",", i);
    //    test.test_createdate = DateTime.Now;
    //    test.username_id = checkuserid.username_id;
    //    test.khoi_id = Convert.ToInt32(ddlKhoi.SelectedValue);
    //    test.monhoc_id = Convert.ToInt32(ddlMon.SelectedValue);
    //    test.luyentap_id = insert.luyentap_id;
    //    test.hidden = false;
    //    db.tbTracNghiem_Tests.InsertOnSubmit(test);
    //    db.SubmitChanges();
    //    test.test_link = "bai-luyen-tap-chi-tiet-" + Convert.ToInt32(ddlKhoi.SelectedValue) + "/" + cls_ToAscii.ToAscii(txtTenBai.Value) + "-" + test.test_id;
    //    db.SubmitChanges();
    //}
    protected void getChuoiCauHoiTheoTiLeTracNghiem()
    {
        //Nếu chỉ có trắc nghiệm
        string chuoiCauHoi = "";
        int socauNhanBiet = 0; int socauThongHieu = 0; int socauVanDung = 0; int socauVanDungCao = 0;
        Random rnd = new Random();
        int seed = rnd.Next();
        var getDuLieu= (from gdtCH in db.tbTracNghiem_Questions
                        join c in db.tbTracNghiem_Lessons on gdtCH.lesson_id equals c.lesson_id
                        join ch in db.tbTracNghiem_Chapters on gdtCH.chapter_id equals ch.chapter_id
                        where ch.chapter_id == Convert.ToInt32(ddlChuong.SelectedValue) && gdtCH.hidden == false
                        select new
                        {
                            gdtCH.question_id,
                            gdtCH.question_dangcauhoi
                        });
        if (txtTracNghiem_NhanBiet.Value != "")
        {
            socauNhanBiet = Convert.ToInt16(txtTracNghiem_NhanBiet.Value) * Convert.ToInt16(ddlDiem.SelectedValue);
            var checkDuLieuNhanBiet = (getDuLieu.Where(x => x.question_dangcauhoi == "Nhận biết")).OrderBy(x => (~(x.question_id & seed)) & (x.question_id | seed)).Take(socauNhanBiet);
            foreach (var item in checkDuLieuNhanBiet)
            {
                chuoiCauHoi = chuoiCauHoi + "," + item.question_id;
            }
        }
        if (txtTracNghiem_ThongHieu.Value != "")
        {
            socauThongHieu = Convert.ToInt16(txtTracNghiem_ThongHieu.Value) * Convert.ToInt16(ddlDiem.SelectedValue);
            var checkDuLieuThongHieu = (getDuLieu.Where(x => x.question_dangcauhoi == "Thông hiểu")).OrderBy(x => (~(x.question_id & seed)) & (x.question_id | seed)).Take(socauThongHieu);
            foreach (var item in checkDuLieuThongHieu)
            {
                chuoiCauHoi = chuoiCauHoi + "," + item.question_id;
            }
        }
        if (txtTracNghiem_VanDung.Value != "")
        {
            socauVanDung = Convert.ToInt16(txtTracNghiem_VanDung.Value) * Convert.ToInt16(ddlDiem.SelectedValue);
            var checkDuLieuVanDung = (getDuLieu.Where(x => x.question_dangcauhoi == "Vận dụng")).OrderBy(x => (~(x.question_id & seed)) & (x.question_id | seed)).Take(socauVanDung);
            foreach (var item in checkDuLieuVanDung)
            {
                chuoiCauHoi = chuoiCauHoi + "," + item.question_id;
            }
        }
        if (txtTracNghiem_VanDungCao.Value != "")
        {
            socauVanDungCao = Convert.ToInt16(txtTracNghiem_VanDungCao.Value) * Convert.ToInt16(ddlDiem.SelectedValue);
            var checkDuLieuVanDungCao = (getDuLieu.Where(x => x.question_dangcauhoi == "Vận dụng cao")).OrderBy(x => (~(x.question_id & seed)) & (x.question_id | seed)).Take(socauVanDungCao);
            foreach (var item in checkDuLieuVanDungCao)
            {
                chuoiCauHoi = chuoiCauHoi + "," + item.question_id;
            }
        }
        chuoiCauHoi = chuoiCauHoi.Substring(1);
        Session["chuoiCauHoi"] = chuoiCauHoi;
    }
    protected void getChuoiCauHoiTheoTiLeTuLuan()
    {
        //Nếu chỉ có tự luận
        string chuoiCauHoi = "";
        int socauNhanBiet = 0; int socauThongHieu = 0; int socauVanDung = 0; int socauVanDungCao = 0;

        double diemmoicau = Convert.ToDouble(txtTuLuan_Diem_NhanBiet.Value, CultureInfo.InvariantCulture);
        socauNhanBiet = (int)(Convert.ToDouble(txtTuLuan_NhanBiet.Value)/diemmoicau);


        if (txtTuLuan_NhanBiet.Value != "")
            socauNhanBiet = Convert.ToInt16(txtTuLuan_NhanBiet.Value);
        if (txtTuLuan_ThongHieu.Value != "")
            socauThongHieu = Convert.ToInt16(txtTuLuan_ThongHieu.Value);
        if (txtTuLuan_VanDung.Value != "")
            socauVanDung = Convert.ToInt16(txtTuLuan_VanDung.Value);
        if (txtTuLuan_VanDungCao.Value != "")
            socauVanDungCao = Convert.ToInt16(txtTuLuan_VanDungCao.Value);
        if (txtTuLuan_NhanBiet.Value != "")
        {
            Random rnd = new Random();
            int seed = rnd.Next();

            var checkDuLieuNhanBiet = (from gdtCH in db.tbTracNghiem_Questions
                                       join c in db.tbTracNghiem_Lessons on gdtCH.lesson_id equals c.lesson_id
                                       join ch in db.tbTracNghiem_Chapters on gdtCH.chapter_id equals ch.chapter_id
                                       where ch.chapter_id == Convert.ToInt32(ddlChuong.SelectedValue)
                                       && gdtCH.hidden == false && gdtCH.question_dangcauhoi == "Nhận biết"
                                       select new
                                       {
                                           gdtCH.question_id
                                       });
            checkDuLieuNhanBiet = checkDuLieuNhanBiet.OrderBy(x => (~(x.question_id & seed)) & (x.question_id | seed)).Take(socauNhanBiet);
            foreach (var item in checkDuLieuNhanBiet)
            {
                chuoiCauHoi = chuoiCauHoi + "," + item.question_id;
            }
        }
        if (txtTuLuan_ThongHieu.Value != "")
        {
            Random rnd = new Random();
            int seed = rnd.Next();
            var checkDuLieuThongHieu = (from gdtCH in db.tbTracNghiem_Questions
                                        join c in db.tbTracNghiem_Lessons on gdtCH.lesson_id equals c.lesson_id
                                        join ch in db.tbTracNghiem_Chapters on gdtCH.chapter_id equals ch.chapter_id
                                        where ch.chapter_id == Convert.ToInt32(ddlChuong.SelectedValue)
                                        && gdtCH.hidden == false && gdtCH.question_dangcauhoi == "Thông hiểu"
                                        select new
                                        {
                                            gdtCH.question_id
                                        });
            checkDuLieuThongHieu = checkDuLieuThongHieu.OrderBy(x => (~(x.question_id & seed)) & (x.question_id | seed)).Take(socauThongHieu);

            foreach (var item in checkDuLieuThongHieu)
            {
                chuoiCauHoi = chuoiCauHoi + "," + item.question_id;
            }
        }
        if (txtTuLuan_VanDung.Value != "")
        {
            Random rnd = new Random();
            int seed = rnd.Next();
            var checkDuLieuVanDung = (from gdtCH in db.tbTracNghiem_Questions
                                      join c in db.tbTracNghiem_Lessons on gdtCH.lesson_id equals c.lesson_id
                                      join ch in db.tbTracNghiem_Chapters on gdtCH.chapter_id equals ch.chapter_id
                                      where ch.chapter_id == Convert.ToInt32(ddlChuong.SelectedValue)
                                      && gdtCH.hidden == false && gdtCH.question_dangcauhoi == "Vận dụng"
                                      select new
                                      {
                                          gdtCH.question_id
                                      });
            checkDuLieuVanDung = checkDuLieuVanDung.OrderBy(x => (~(x.question_id & seed)) & (x.question_id | seed)).Take(socauVanDung);

            foreach (var item in checkDuLieuVanDung)
            {
                chuoiCauHoi = chuoiCauHoi + "," + item.question_id;
            }
        }
        if (txtTuLuan_VanDungCao.Value != "")
        {
            Random rnd = new Random();
            int seed = rnd.Next();
            var checkDuLieuVanDungCao = (from gdtCH in db.tbTracNghiem_Questions
                                         join c in db.tbTracNghiem_Lessons on gdtCH.lesson_id equals c.lesson_id
                                         join ch in db.tbTracNghiem_Chapters on gdtCH.chapter_id equals ch.chapter_id
                                         where ch.chapter_id == Convert.ToInt32(ddlChuong.SelectedValue)
                                         && gdtCH.hidden == false && gdtCH.question_dangcauhoi == "Vận dụng cao"
                                         select new
                                         {
                                             gdtCH.question_id
                                         });
            checkDuLieuVanDungCao = checkDuLieuVanDungCao.OrderBy(x => (~(x.question_id & seed)) & (x.question_id | seed)).Take(socauVanDungCao);

            foreach (var item in checkDuLieuVanDungCao)
            {
                chuoiCauHoi = chuoiCauHoi + "," + item.question_id;
            }
        }
        chuoiCauHoi = chuoiCauHoi.Substring(1);
        Session["chuoiCauHoi"] = chuoiCauHoi;
    }
    protected void getChuoiCauHoiTheoTiLeTuLuanVaTracNghiem()
    {
        //    // Điểm tự luận đã có
        //    // Lấy điểm tự luận trừ đi tỉ lệ điểm trắc nghiệm là sẽ có được số điểm còn lại của trắc nghiêm

        //    string chuoiCauHoi = "";
        //    int socauNhanBiet = 0; int socauThongHieu = 0; int socauVanDung = 0; int socauVanDungCao = 0;
        //    int hieu_NhanBiet = 0; int hieu_ThongHieu = 0; int hieu_vanDung = 0; int hieu_VanDungCao = 0;
        //    if (txtTuLuan_Cau_NhanBiet.Value != "" && txtTracNghiem_NhanBiet.Value != "")
        //    {
        //        hieu_NhanBiet = Convert.ToInt16(txtTracNghiem_NhanBiet.Value) - Convert.ToInt16(txtTuLuan_Diem_NhanBiet.Value);
        //        if (txtTracNghiem_NhanBiet.Value != "")
        //        {
        //            if (txtTracNghiem_Diem.Value == "0.25")
        //                socauNhanBiet = hieu_NhanBiet * 4;
        //            if (txtTracNghiem_Diem.Value == "0.5")
        //                socauNhanBiet = hieu_NhanBiet * 2;
        //            if (txtTracNghiem_Diem.Value == "1")
        //                socauNhanBiet = hieu_NhanBiet;
        //        }
        //        Random rnd = new Random();
        //        int seed = rnd.Next();

        //        var checkDuLieuNhanBiet = (from gdtCH in db.tbTracNghiem_Questions
        //                                   join c in db.tbTracNghiem_Lessons on gdtCH.lesson_id equals c.lesson_id
        //                                   join ch in db.tbTracNghiem_Chapters on gdtCH.chapter_id equals ch.chapter_id
        //                                   where ch.chapter_id == Convert.ToInt32(ddlChuong.SelectedValue)
        //                                   && gdtCH.hidden == false && gdtCH.question_dangcauhoi == "Nhận biết"
        //                                   select new
        //                                   {
        //                                       gdtCH.question_id
        //                                   });
        //        checkDuLieuNhanBiet = checkDuLieuNhanBiet.OrderBy(x => (~(x.question_id & seed)) & (x.question_id | seed)).Take(socauNhanBiet);
        //        foreach (var item in checkDuLieuNhanBiet)
        //        {
        //            chuoiCauHoi = chuoiCauHoi + "," + item.question_id;
        //        }
        //    }
        //    if (txtTuLuan_Cau_ThongHieu.Value != "" && txtTracNghiem_ThongHieu.Value != "")
        //    {
        //        hieu_ThongHieu = Convert.ToInt16(txtTracNghiem_ThongHieu.Value) - Convert.ToInt16(txtTuLuan_Diem_ThongHieu.Value);
        //        if (txtTracNghiem_ThongHieu.Value != "")
        //        {
        //            if (txtTracNghiem_Diem.Value == "0.25")
        //                socauThongHieu = hieu_ThongHieu * 4;
        //            if (txtTracNghiem_Diem.Value == "0.5")
        //                socauThongHieu = hieu_ThongHieu * 2;
        //            if (txtTracNghiem_Diem.Value == "1")
        //                socauThongHieu = hieu_ThongHieu;
        //        }
        //        Random rnd = new Random();
        //        int seed = rnd.Next();
        //        var checkDuLieuThongHieu = (from gdtCH in db.tbTracNghiem_Questions
        //                                    join c in db.tbTracNghiem_Lessons on gdtCH.lesson_id equals c.lesson_id
        //                                    join ch in db.tbTracNghiem_Chapters on gdtCH.chapter_id equals ch.chapter_id
        //                                    where ch.chapter_id == Convert.ToInt32(ddlChuong.SelectedValue)
        //                                    && gdtCH.hidden == false && gdtCH.question_dangcauhoi == "Thông hiểu"
        //                                    select new
        //                                    {
        //                                        gdtCH.question_id
        //                                    });
        //        checkDuLieuThongHieu = checkDuLieuThongHieu.OrderBy(x => (~(x.question_id & seed)) & (x.question_id | seed)).Take(socauThongHieu);

        //        foreach (var item in checkDuLieuThongHieu)
        //        {
        //            chuoiCauHoi = chuoiCauHoi + "," + item.question_id;
        //        }
        //    }
        //    if (txtTuLuan_Cau_VanDung.Value != "" && txtTracNghiem_VanDung.Value != "")
        //    {
        //        hieu_vanDung = Convert.ToInt16(txtTracNghiem_VanDung.Value) - Convert.ToInt16(txtTuLuan_Diem_VanDung.Value);
        //        if (txtTracNghiem_VanDung.Value != "")
        //        {
        //            if (txtTracNghiem_Diem.Value == "0.25")
        //                socauVanDung = hieu_vanDung * 4;
        //            if (txtTracNghiem_Diem.Value == "0.5")
        //                socauVanDung = hieu_vanDung * 2;
        //            if (txtTracNghiem_Diem.Value == "1")
        //                socauVanDung = hieu_vanDung;
        //        }
        //        Random rnd = new Random();
        //        int seed = rnd.Next();
        //        var checkDuLieuVanDung = (from gdtCH in db.tbTracNghiem_Questions
        //                                  join c in db.tbTracNghiem_Lessons on gdtCH.lesson_id equals c.lesson_id
        //                                  join ch in db.tbTracNghiem_Chapters on gdtCH.chapter_id equals ch.chapter_id
        //                                  where ch.chapter_id == Convert.ToInt32(ddlChuong.SelectedValue)
        //                                  && gdtCH.hidden == false && gdtCH.question_dangcauhoi == "Vận dụng"
        //                                  select new
        //                                  {
        //                                      gdtCH.question_id
        //                                  });
        //        checkDuLieuVanDung = checkDuLieuVanDung.OrderBy(x => (~(x.question_id & seed)) & (x.question_id | seed)).Take(socauVanDung);

        //        foreach (var item in checkDuLieuVanDung)
        //        {
        //            chuoiCauHoi = chuoiCauHoi + "," + item.question_id;
        //        }
        //    }
        //    if (txtTuLuan_Cau_VanDungCao.Value != "" && txtTracNghiem_VanDungCao.Value != "")
        //    {
        //        hieu_VanDungCao = Convert.ToInt16(txtTracNghiem_VanDungCao.Value) - Convert.ToInt16(txtTuLuan_Diem_VanDungCao.Value);
        //        if (txtTracNghiem_VanDungCao.Value != "")
        //        {
        //            if (txtTracNghiem_Diem.Value == "0.25")
        //                socauVanDungCao = hieu_VanDungCao * 4;
        //            if (txtTracNghiem_Diem.Value == "0.5")
        //                socauVanDungCao = hieu_VanDungCao * 2;
        //            if (txtTracNghiem_Diem.Value == "1")
        //                socauVanDungCao = hieu_VanDungCao;
        //        }
        //        Random rnd = new Random();
        //        int seed = rnd.Next();
        //        var checkDuLieuVanDungCao = (from gdtCH in db.tbTracNghiem_Questions
        //                                     join c in db.tbTracNghiem_Lessons on gdtCH.lesson_id equals c.lesson_id
        //                                     join ch in db.tbTracNghiem_Chapters on gdtCH.chapter_id equals ch.chapter_id
        //                                     where ch.chapter_id == Convert.ToInt32(ddlChuong.SelectedValue)
        //                                     && gdtCH.hidden == false && gdtCH.question_dangcauhoi == "Vận dụng cao"
        //                                     select new
        //                                     {
        //                                         gdtCH.question_id
        //                                     });
        //        checkDuLieuVanDungCao = checkDuLieuVanDungCao.OrderBy(x => (~(x.question_id & seed)) & (x.question_id | seed)).Take(socauVanDungCao);

        //        foreach (var item in checkDuLieuVanDungCao)
        //        {
        //            chuoiCauHoi = chuoiCauHoi + "," + item.question_id;
        //        }

        //    }
        //    chuoiCauHoi = chuoiCauHoi.Substring(1);
        //    Session["chuoiCauHoi"] = chuoiCauHoi;

    }
    protected void LuuKetQuaTracNghiem()
    {
        string[] arrList = new string[100];
        string str_code = "";
        string str_first = "";
        bool is_link = true;
        if (txtLink.Value != "")
        {
            arrList = txtLink.Value.Split('=');
            try
            {
                string str_init = arrList[0];
                str_code = arrList[1];
                str_first = "https://www.youtube.com/embed/";
                if ((str_init != "https://www.youtube.com/watch?v") || (str_code.Length != 11))
                    is_link = false;
            }
            catch
            {
                is_link = false;
            }

        }
        var checkuserid = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).First();
        tbTracNghiem_BaiLuyenTap insert = new tbTracNghiem_BaiLuyenTap();
        insert.luyentap_name = txtTenBai.Value;
        insert.luyentap_linkvideo = str_first + str_code;
        insert.luyentap_status = 1;
        insert.username_id = checkuserid.username_id;
        db.tbTracNghiem_BaiLuyenTaps.InsertOnSubmit(insert);
        db.SubmitChanges();
        if (txtTracNghiem_NhanBiet.Value != "")
        {
            for (int i = 1; i <= Convert.ToInt16(txtTracNghiem_NhanBiet.Value); i++)
            {
                tbTracNghiem_Test test = new tbTracNghiem_Test();
                test.question_id = Session["chuoiCauHoi"].ToString();
                test.test_createdate = DateTime.Now;
                test.username_id = checkuserid.username_id;
                test.khoi_id = Convert.ToInt32(ddlKhoi.SelectedValue);
                test.monhoc_id = Convert.ToInt32(ddlMon.SelectedValue);
                test.luyentap_id = insert.luyentap_id;
                test.hidden = false;
                db.tbTracNghiem_Tests.InsertOnSubmit(test);
                db.SubmitChanges();
                test.test_link = "bai-luyen-tap-chi-tiet-" + Convert.ToInt32(ddlKhoi.SelectedValue) + "/" + cls_ToAscii.ToAscii(txtTenBai.Value) + "-" + test.test_id;
                db.SubmitChanges();

                // Chưa hiểu ý đồ đoạn code này
                string[] arrCauHoi = test.question_id.Split(',');
                foreach (string item in arrCauHoi)
                {
                    tbTracNghiem_TestDetail cttest = new tbTracNghiem_TestDetail();
                    cttest.test_id = test.test_id;
                    cttest.question_id = Convert.ToInt32(item);
                    cttest.hidden = false;
                    db.tbTracNghiem_TestDetails.InsertOnSubmit(cttest);
                    db.SubmitChanges();
                }
                alert.alert_Success(Page, "Đã tạo đề thành công!", "");

            }
        }
    }
}