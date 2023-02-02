using DevExpress.Web.ASPxHtmlEditor;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_CauHoiLuyenTap_module_TaoBaiThi_Version2 : System.Web.UI.Page
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
                            where c.khoi_id == Convert.ToInt16(ddlKhoi.SelectedValue)
                            && c.monhoc_id == Convert.ToInt16(ddlMon.SelectedValue)
                            select c;

            lkChuong.DataSource = listChuDe;
            lkChuong.DataBind();

        }
        if (lkChuong.Text != "")
        {
            string _id = lkChuong.Text;
            string[] arrListStr = _id.Split(',');
            var list = from le in db.tbTracNghiem_Lessons
                       join ch in db.tbTracNghiem_Chapters on le.chapter_id equals ch.chapter_id
                       where ch.chapter_name == ""
                       && ch.khoi_id == Convert.ToInt16(ddlKhoi.SelectedValue)
                       && ch.monhoc_id == Convert.ToInt16(ddlMon.SelectedValue)
                       //&& ch.hidden == false
                       select new
                       {
                           le.lesson_name,
                           le.lesson_id,
                           ch.chapter_id
                       };
            foreach (string item in arrListStr)
            {
                var list1 = from le in db.tbTracNghiem_Lessons
                            join ch in db.tbTracNghiem_Chapters on le.chapter_id equals ch.chapter_id
                            where ch.chapter_name == item.ToString().Trim()
                             && ch.khoi_id == Convert.ToInt16(ddlKhoi.SelectedValue)
                           && ch.monhoc_id == Convert.ToInt16(ddlMon.SelectedValue)
                            orderby le.lesson_id ascending
                            //&& ch.hidden == false
                            select new
                            {
                                le.lesson_name,
                                le.lesson_id,
                                ch.chapter_id
                            };
                list = list.Union(list1);
                lkBai.DataSource = list;
                lkBai.DataBind();
            }
        }
    }

    protected void ddlKhoi_SelectedIndexChanged(object sender, EventArgs e)
    {
        var listChuDe = from c in db.tbTracNghiem_Chapters
                        where c.khoi_id == Convert.ToInt16(ddlKhoi.SelectedValue) 
                        && c.monhoc_id == Convert.ToInt16(ddlMon.SelectedValue)
                        select c;
        lkChuong.DataSource = listChuDe;
        lkChuong.DataBind();

        //ddlChuong.DataSource = listChuDe;
        //ddlChuong.DataTextField = "chapter_name";
        //ddlChuong.DataValueField = "chapter_id";
        //ddlChuong.DataBind();
    }
    protected void ddlMon_SelectedIndexChanged(object sender, EventArgs e)
    {
        var listChuDe = from c in db.tbTracNghiem_Chapters
                        where c.khoi_id == Convert.ToInt16(ddlKhoi.SelectedValue) && c.monhoc_id == Convert.ToInt16(ddlMon.SelectedValue)
                        select c;
        lkChuong.DataSource = listChuDe;
        lkChuong.DataBind();

        //ddlChuong.DataSource = listChuDe;
        //ddlChuong.DataTextField = "chapter_name";
        //ddlChuong.DataValueField = "chapter_id";
        //ddlChuong.DataBind();
        _idMonHoc = Convert.ToInt32(ddlMon.SelectedValue);
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
        {
            getChuoiCauHoiTheoTiLeTuLuan();
            LuuKetQuaTracNghiem();
        }

        if (txtHinhThucThi.Value == "3")
        {
            getChuoiCauHoiTheoTiLeTuLuan();
            getChuoiCauHoiTheoTiLeTuLuanVaTracNghiem();
            LuuKetQuaTracNghiem();
        }
    }
    protected void getChuoiCauHoiTheoTiLeTracNghiem()
    {
        //Nếu chỉ có trắc nghiệm
        string listBai = lkBai.Text;
        string[] arrListStr = listBai.Split(',');
        string chuoiCauHoi = "";
        int socauNhanBiet = 0; int socauThongHieu = 0; int socauVanDung = 0; int socauVanDungCao = 0;
        Random rnd = new Random();
        int seed = rnd.Next();

        var  getDuLieu = from gdtCH in db.tbTracNghiem_Questions
                              join c in db.tbTracNghiem_Lessons on gdtCH.lesson_id equals c.lesson_id
                              where c.lesson_name == ""
                              select new
                              {
                                  gdtCH.question_id,
                                  gdtCH.question_dangcauhoi
                              };
        foreach (string item in arrListStr)
        {
            var getDuLieuFR = from gdtCH in db.tbTracNghiem_Questions
                            join c in db.tbTracNghiem_Lessons on gdtCH.lesson_id equals c.lesson_id
                            join ch in db.tbTracNghiem_Chapters on gdtCH.chapter_id equals ch.chapter_id
                            where c.lesson_name == item.ToString().Trim()
                            && ch.khoi_id == Convert.ToInt16(ddlKhoi.SelectedValue)
                            && ch.monhoc_id == Convert.ToInt16(ddlMon.SelectedValue)
                            && gdtCH.hidden == false && gdtCH.question_type == "Trắc nghiệm"
                            select new
                            {
                                gdtCH.question_id,
                                gdtCH.question_dangcauhoi
                            };
            getDuLieu = getDuLieu.Union(getDuLieuFR);
        }
       tbTracNghiem_MaTraDeThi insert = new tbTracNghiem_MaTraDeThi();
        if (txtTracNghiem_NhanBiet.Value != "")
        {
            socauNhanBiet = Convert.ToInt16(txtTracNghiem_NhanBiet.Value) * Convert.ToInt16(ddlDiem.SelectedValue);
            insert.tracnghiem_nhanbiet = Convert.ToDouble(txtTracNghiem_NhanBiet.Value, CultureInfo.InvariantCulture);
            var checkDuLieuNhanBiet = (getDuLieu.Where(x => x.question_dangcauhoi == "Nhận biết")).OrderBy(x => (~(x.question_id & seed)) & (x.question_id | seed)).Take(socauNhanBiet);
            foreach (var item in checkDuLieuNhanBiet)
            {
                chuoiCauHoi = chuoiCauHoi + "," + item.question_id;
            }
        }
        if (txtTracNghiem_ThongHieu.Value != "")
        {
            socauThongHieu = Convert.ToInt16(txtTracNghiem_ThongHieu.Value) * Convert.ToInt16(ddlDiem.SelectedValue);
            insert.tracnghiem_thonghieu = Convert.ToDouble(txtTracNghiem_ThongHieu.Value, CultureInfo.InvariantCulture);
            var checkDuLieuThongHieu = (getDuLieu.Where(x => x.question_dangcauhoi == "Thông hiểu")).OrderBy(x => (~(x.question_id & seed)) & (x.question_id | seed)).Take(socauThongHieu);
            foreach (var item in checkDuLieuThongHieu)
            {
                chuoiCauHoi = chuoiCauHoi + "," + item.question_id;
            }
        }
        if (txtTracNghiem_VanDung.Value != "")
        {
            socauVanDung = Convert.ToInt16(txtTracNghiem_VanDung.Value) * Convert.ToInt16(ddlDiem.SelectedValue);
            insert.tracnghiem_vandung = Convert.ToDouble(txtTracNghiem_VanDung.Value, CultureInfo.InvariantCulture);
            var checkDuLieuVanDung = (getDuLieu.Where(x => x.question_dangcauhoi == "Vận dụng")).OrderBy(x => (~(x.question_id & seed)) & (x.question_id | seed)).Take(socauVanDung);
            foreach (var item in checkDuLieuVanDung)
            {
                chuoiCauHoi = chuoiCauHoi + "," + item.question_id;
            }
        }
        if (txtTracNghiem_VanDungCao.Value != "")
        {
            socauVanDungCao = Convert.ToInt16(txtTracNghiem_VanDungCao.Value) * Convert.ToInt16(ddlDiem.SelectedValue);
            insert.tracnghiem_vandungcao = Convert.ToDouble(txtTracNghiem_VanDungCao.Value, CultureInfo.InvariantCulture);
            var checkDuLieuVanDungCao = (getDuLieu.Where(x => x.question_dangcauhoi == "Vận dụng cao")).OrderBy(x => (~(x.question_id & seed)) & (x.question_id | seed)).Take(socauVanDungCao);
            foreach (var item in checkDuLieuVanDungCao)
            {
                chuoiCauHoi = chuoiCauHoi + "," + item.question_id;
            }
        }
        db.tbTracNghiem_MaTraDeThis.InsertOnSubmit(insert);
        db.SubmitChanges();

        chuoiCauHoi = chuoiCauHoi.Substring(1);
        Session["chuoiCauHoi"] = chuoiCauHoi;
        Session["MaTranDe_id"] = insert.matrade_id;
    }
    protected void getChuoiCauHoiTheoTiLeTuLuan()
    {
        //Nếu chỉ có tự luận
        string chuoiCauHoi = "";
        int socauNhanBiet = 0; int socauThongHieu = 0; int socauVanDung = 0; int socauVanDungCao = 0;

        Random rnd = new Random();
        int seed = rnd.Next();
        string listBai = lkBai.Text;
        string[] arrListStr = listBai.Split(',');
        var checkDuLieu = from gdtCH in db.tbTracNghiem_Questions
                        join c in db.tbTracNghiem_Lessons on gdtCH.lesson_id equals c.lesson_id
                        where c.lesson_name == ""
                        select new
                        {
                            gdtCH.question_id,
                            gdtCH.question_dangcauhoi
                        };
        foreach (string item in arrListStr)
        {
            var checkDuLieuFR = from gdtCH in db.tbTracNghiem_Questions
                              join c in db.tbTracNghiem_Lessons on gdtCH.lesson_id equals c.lesson_id
                              join ch in db.tbTracNghiem_Chapters on gdtCH.chapter_id equals ch.chapter_id
                              where c.lesson_name == item.ToString().Trim()
                              && ch.khoi_id == Convert.ToInt16(ddlKhoi.SelectedValue)
                              && ch.monhoc_id == Convert.ToInt16(ddlMon.SelectedValue)
                              && gdtCH.hidden == false && gdtCH.question_type == "Tự luận"
                              select new
                              {
                                  gdtCH.question_id,
                                  gdtCH.question_dangcauhoi
                              };
            checkDuLieu = checkDuLieu.Union(checkDuLieuFR);
        }
        tbTracNghiem_MaTraDeThi insert = new tbTracNghiem_MaTraDeThi();
        if (txtTuLuan_NhanBiet.Value != "")
        {
            socauNhanBiet = (int)(Convert.ToDouble(txtTuLuan_NhanBiet.Value, CultureInfo.InvariantCulture) / (Convert.ToDouble(txtTuLuan_Diem_NhanBiet.Value, CultureInfo.InvariantCulture)));
            insert.tuluan_nhanbiet = Convert.ToDouble(txtTuLuan_NhanBiet.Value, CultureInfo.InvariantCulture);
            var checkDuLieuNhanBiet = (checkDuLieu.Where(x => x.question_dangcauhoi == "Nhận biết")).OrderBy(x => (~(x.question_id & seed)) & (x.question_id | seed)).Take(socauNhanBiet);
            foreach (var item in checkDuLieuNhanBiet)
            {
                chuoiCauHoi = chuoiCauHoi + "," + item.question_id;
            }
        }
        if (txtTuLuan_ThongHieu.Value != "")
        {
            socauThongHieu = (int)(Convert.ToDouble(txtTuLuan_ThongHieu.Value, CultureInfo.InvariantCulture) / (Convert.ToDouble(txtTuLuan_Diem_ThongHieu.Value, CultureInfo.InvariantCulture)));
            insert.tuluan_thonghieu = Convert.ToDouble(txtTuLuan_ThongHieu.Value, CultureInfo.InvariantCulture);

            var checkDuLieuThongHieu = (checkDuLieu.Where(x => x.question_dangcauhoi == "Thông hiểu")).OrderBy(x => (~(x.question_id & seed)) & (x.question_id | seed)).Take(socauThongHieu);
            foreach (var item in checkDuLieuThongHieu)
            {
                chuoiCauHoi = chuoiCauHoi + "," + item.question_id;
            }
        }
        if (txtTuLuan_VanDung.Value != "")
        {
            socauVanDung = (int)(Convert.ToDouble(txtTuLuan_VanDung.Value, CultureInfo.InvariantCulture) / (Convert.ToDouble(txtTuLuan_Diem_VanDung.Value, CultureInfo.InvariantCulture)));
            insert.tuluan_vandung = Convert.ToDouble(txtTuLuan_VanDung.Value, CultureInfo.InvariantCulture);
            var checkDuLieuVanDung = (checkDuLieu.Where(x => x.question_dangcauhoi == "Vận dụng")).OrderBy(x => (~(x.question_id & seed)) & (x.question_id | seed)).Take(socauVanDung);
            foreach (var item in checkDuLieuVanDung)
            {
                chuoiCauHoi = chuoiCauHoi + "," + item.question_id;
            }
        }
        if (txtTuLuan_VanDungCao.Value != "")
        {
            socauVanDungCao = (int)(Convert.ToDouble(txtTuLuan_VanDungCao.Value, CultureInfo.InvariantCulture) / (Convert.ToDouble(txtTuLuan_Diem_VanDungCao.Value, CultureInfo.InvariantCulture)));
            insert.tuluan_vandungcao = Convert.ToDouble(txtTuLuan_VanDungCao.Value, CultureInfo.InvariantCulture);

            var checkDuLieuVanDungCao = (checkDuLieu.Where(x => x.question_dangcauhoi == "Vận dụng cao")).OrderBy(x => (~(x.question_id & seed)) & (x.question_id | seed)).Take(socauVanDungCao);
            foreach (var item in checkDuLieuVanDungCao)
            {
                chuoiCauHoi = chuoiCauHoi + "," + item.question_id;
            }
        }
        db.tbTracNghiem_MaTraDeThis.InsertOnSubmit(insert);
        db.SubmitChanges();
        chuoiCauHoi = chuoiCauHoi.Substring(1);
        Session["chuoiCauHoi"] = chuoiCauHoi;
        Session["MaTranDe_id"] = insert.matrade_id;
    }
    protected void getChuoiCauHoiTheoTiLeTuLuanVaTracNghiem()
    {
        if (txtTuLuan_NhanBiet.Value == "")
        {
            txtTuLuan_NhanBiet.Value = 0+"";
        }
        if (txtTuLuan_ThongHieu.Value == "")
        {
            txtTuLuan_ThongHieu.Value = 0 + "";
        }
        if (txtTuLuan_VanDung.Value == "")
        {
            txtTuLuan_VanDung.Value = 0 + "";
        }
        if (txtTuLuan_VanDungCao.Value == "")
        {
            txtTuLuan_VanDungCao.Value = 0 + "";
        }
        // Điểm tự luận đã có
        // Để đảm bảo đúng tỉ lệ ma trận, phải lấy tỉ lệ ma trận đề trừ đi điểm tự luận sẽ có được số điểm còn lại của trắc nghiêm

        string chuoiCauHoi = Session["chuoiCauHoi"].ToString();
        int socauNhanBiet = 0; int socauThongHieu = 0; int socauVanDung = 0; int socauVanDungCao = 0;
        double hieu_NhanBiet = 0; double hieu_ThongHieu = 0; double hieu_vanDung = 0; double hieu_VanDungCao = 0;
        Random rnd = new Random();
        int seed = rnd.Next();

        string listBai = lkBai.Text;
        string[] arrListStr = listBai.Split(',');
        var getDuLieu = from gdtCH in db.tbTracNghiem_Questions
                        join c in db.tbTracNghiem_Lessons on gdtCH.lesson_id equals c.lesson_id
                        where c.lesson_name == ""
                        select new
                        {
                            gdtCH.question_id,
                            gdtCH.question_dangcauhoi
                        };
        foreach (string item in arrListStr)
        {
            var getDuLieuFR = from gdtCH in db.tbTracNghiem_Questions
                              join c in db.tbTracNghiem_Lessons on gdtCH.lesson_id equals c.lesson_id
                              join ch in db.tbTracNghiem_Chapters on gdtCH.chapter_id equals ch.chapter_id
                              where c.lesson_name == item.ToString().Trim()
                              && ch.khoi_id == Convert.ToInt16(ddlKhoi.SelectedValue)
                              && ch.monhoc_id == Convert.ToInt16(ddlMon.SelectedValue)
                              && gdtCH.hidden == false && gdtCH.question_type == "Trắc nghiệm"
                              select new
                              {
                                  gdtCH.question_id,
                                  gdtCH.question_dangcauhoi
                              };
            getDuLieu = getDuLieu.Union(getDuLieuFR);
        }
        var update = (from ud in db.tbTracNghiem_MaTraDeThis
                      where ud.matrade_id == Convert.ToInt32(Session["MaTranDe_id"].ToString())
                      select ud).Single();
        if (txtTuLuan_NhanBiet.Value != "" && txtTracNghiem_NhanBiet.Value != "")
        {
            hieu_NhanBiet = Convert.ToDouble(txtTracNghiem_NhanBiet.Value, CultureInfo.InvariantCulture) - Convert.ToDouble(txtTuLuan_NhanBiet.Value, CultureInfo.InvariantCulture);
            update.tracnghiem_nhanbiet = hieu_NhanBiet;
            socauNhanBiet = (int)(hieu_NhanBiet * Convert.ToDouble(ddlDiem.SelectedValue, CultureInfo.InvariantCulture));
            var checkDuLieuNhanBiet = (getDuLieu.Where(x => x.question_dangcauhoi == "Nhận biết")).OrderBy(x => (~(x.question_id & seed)) & (x.question_id | seed)).Take(socauNhanBiet);
            foreach (var item in checkDuLieuNhanBiet)
            {
                chuoiCauHoi = chuoiCauHoi + "," + item.question_id;
            }
        }
        if (txtTuLuan_ThongHieu.Value != "" && txtTracNghiem_ThongHieu.Value != "")
        {
            hieu_ThongHieu = Convert.ToDouble(txtTracNghiem_ThongHieu.Value, CultureInfo.InvariantCulture) - Convert.ToDouble(txtTuLuan_ThongHieu.Value, CultureInfo.InvariantCulture);
            update.tracnghiem_thonghieu = hieu_ThongHieu;
            socauThongHieu = (int)(hieu_ThongHieu * Convert.ToDouble(ddlDiem.SelectedValue, CultureInfo.InvariantCulture));
            var checkDuLieuThongHieu = (getDuLieu.Where(x => x.question_dangcauhoi == "Thông hiểu")).OrderBy(x => (~(x.question_id & seed)) & (x.question_id | seed)).Take(socauThongHieu);
            foreach (var item in checkDuLieuThongHieu)
            {
                chuoiCauHoi = chuoiCauHoi + "," + item.question_id;
            }
        }
        if (txtTuLuan_VanDung.Value != "" && txtTracNghiem_VanDung.Value != "")
        {
            hieu_vanDung = Convert.ToDouble(txtTracNghiem_VanDung.Value, CultureInfo.InvariantCulture) - Convert.ToDouble(txtTuLuan_VanDung.Value, CultureInfo.InvariantCulture);
            update.tracnghiem_vandung = hieu_vanDung;
            socauVanDung = (int)(hieu_vanDung * Convert.ToDouble(ddlDiem.SelectedValue, CultureInfo.InvariantCulture));
            var checkDuLieuVanDung = (getDuLieu.Where(x => x.question_dangcauhoi == "Vận dụng")).OrderBy(x => (~(x.question_id & seed)) & (x.question_id | seed)).Take(socauVanDung);
            foreach (var item in checkDuLieuVanDung)
            {
                chuoiCauHoi = chuoiCauHoi + "," + item.question_id;
            }
        }
        if (txtTuLuan_VanDungCao.Value != "" && txtTracNghiem_VanDungCao.Value != "")
        {
            hieu_VanDungCao = Convert.ToDouble(txtTracNghiem_VanDungCao.Value, CultureInfo.InvariantCulture) - Convert.ToDouble(txtTuLuan_VanDungCao.Value, CultureInfo.InvariantCulture);
            update.tracnghiem_vandungcao = hieu_VanDungCao;
            socauVanDungCao = (int)(hieu_VanDungCao * Convert.ToDouble(ddlDiem.SelectedValue, CultureInfo.InvariantCulture));
            var checkDuLieuVanDungCao = (getDuLieu.Where(x => x.question_dangcauhoi == "Vận dụng cao")).OrderBy(x => (~(x.question_id & seed)) & (x.question_id | seed)).Take(socauVanDungCao);
            foreach (var item in checkDuLieuVanDungCao)
            {
                chuoiCauHoi = chuoiCauHoi + "," + item.question_id;
            }
        }
        db.SubmitChanges();
        Session["chuoiCauHoi"] = chuoiCauHoi;

    }
    protected void LuuKetQuaTracNghiem()
    {
        string[] arrList = new string[100];
        var update = (from ud in db.tbTracNghiem_MaTraDeThis
                      where ud.matrade_id == Convert.ToInt32(Session["MaTranDe_id"].ToString())
                      select ud).Single();
        update.tracnghiem_chuong_chude = lkChuong.Text;
        update.tracnghiem_noidung_kienthuc = lkBai.Text;
        db.SubmitChanges();

        var checkuserid = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).First();
        tbTracNghiem_BaiLuyenTap insert = new tbTracNghiem_BaiLuyenTap();
        insert.luyentap_name = txtTenBai.Value;
        // tạo bài luyện tập luyentap_status =1, tạo bài thi luyentap_status = 2
        insert.luyentap_status = 2;
        insert.username_id = checkuserid.username_id;
        insert.matrande_id = update.matrade_id;
        db.tbTracNghiem_BaiLuyenTaps.InsertOnSubmit(insert);
        db.SubmitChanges();

        tbTracNghiem_Test test = new tbTracNghiem_Test();
        test.question_id = Session["chuoiCauHoi"].ToString();
        test.test_createdate = DateTime.Now;
        test.username_id = checkuserid.username_id;
        test.khoi_id = Convert.ToInt32(ddlKhoi.SelectedValue);
        test.monhoc_id = Convert.ToInt32(ddlMon.SelectedValue);
        test.luyentap_id = insert.luyentap_id;
        test.hidden = false;
        test.test_link = "bai-luyen-tap-chi-tiet-" + Convert.ToInt32(ddlKhoi.SelectedValue) + "/" + cls_ToAscii.ToAscii(txtTenBai.Value) + "-" + test.test_id;
        db.tbTracNghiem_Tests.InsertOnSubmit(test);
        db.SubmitChanges();

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