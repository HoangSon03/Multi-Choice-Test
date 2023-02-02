using DevExpress.Web.ASPxHtmlEditor;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_CauHoiLuyenTap_module_TaoDeLuyenTap_Version2 : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    int question_id;
    public int STT = 1;
    public int STTT = 1;
    public int user_id;
    private static int _idKhoi;
    private static int _idMonHoc;
    protected void Page_Load(object sender, EventArgs e)
    {
        var checkTaiKhoan = (from u in db.admin_Users 
                             where u.username_username == Request.Cookies["UserName"].Value
                             select u).FirstOrDefault();
        user_id = checkTaiKhoan.username_id;
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
                            //  orderby le.lesson_id ascending
                            //&& ch.hidden == false
                            select new
                            {
                                le.lesson_name,
                                le.lesson_id,
                                ch.chapter_id
                            };
                list = list.Union(list1);
                lkBai.DataSource = list.OrderBy(x => x.lesson_id);
                lkBai.DataBind();
            }
        }
        var getDe = from te in db.tbTracNghiem_Tests
                    join m in db.tbMonHocs on te.monhoc_id equals m.monhoc_id
                    join k in db.tbKhois on te.khoi_id equals k.khoi_id
                    join u in db.admin_Users on te.username_id equals u.username_id
                    //where te.username_id == checkTaiKhoan.username_id
                    orderby te.test_id descending
                    select new { 
                    te.test_id,
                    te.test_createdate,
                    m.monhoc_name,
                    k.khoi_name,
                    te.test_link,
                    u.username_fullname,
                    
                    };
        grvDeLuyenTap.DataSource = getDe;
        grvDeLuyenTap.DataBind();
    }
    protected void ddlKhoi_SelectedIndexChanged(object sender, EventArgs e)
    {
        var listChuDe = from c in db.tbTracNghiem_Chapters
                        where c.khoi_id == Convert.ToInt16(ddlKhoi.SelectedValue)
                        && c.monhoc_id == Convert.ToInt16(ddlMon.SelectedValue)
                        select c;
        lkChuong.DataSource = listChuDe;
        lkChuong.DataBind();
    }
    protected void ddlMon_SelectedIndexChanged(object sender, EventArgs e)
    {
        var listChuDe = from c in db.tbTracNghiem_Chapters
                        where c.khoi_id == Convert.ToInt16(ddlKhoi.SelectedValue) && c.monhoc_id == Convert.ToInt16(ddlMon.SelectedValue)
                        select c;
        lkChuong.DataSource = listChuDe;
        lkChuong.DataBind();
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

        tbTracNghiem_MaTranChiTiet insert_MT_detail = new tbTracNghiem_MaTranChiTiet();
        var getDuLieu = from gdtCH in db.tbTracNghiem_Questions
                        join c in db.tbTracNghiem_Lessons on gdtCH.lesson_id equals c.lesson_id
                        where c.lesson_id == 0
                        select new
                        {
                            gdtCH.question_id,
                            gdtCH.question_dangcauhoi
                        };
        foreach (string item in arrListStr)
        {
            insert_MT_detail.lession_id = Convert.ToInt32(item);
            var getDuLieuFR = from gdtCH in db.tbTracNghiem_Questions
                              join c in db.tbTracNghiem_Lessons on gdtCH.lesson_id equals c.lesson_id
                              join ch in db.tbTracNghiem_Chapters on gdtCH.chapter_id equals ch.chapter_id
                              where c.lesson_id == Convert.ToInt32(item)
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
        insert.tracnghiem_diem = Convert.ToDouble(ddlDiem.SelectedItem.Text, CultureInfo.InvariantCulture);
        if (txtTracNghiem_NhanBiet.Value != "")
        {
            socauNhanBiet = Convert.ToInt16(txtTracNghiem_NhanBiet.Value) * Convert.ToInt16(ddlDiem.SelectedValue);
            insert.tracnghiem_nhanbiet = Convert.ToDouble(txtTracNghiem_NhanBiet.Value, CultureInfo.InvariantCulture);
            insert.tracnghiem_nhanbiet_socau = socauNhanBiet;
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
            insert.tracnghiem_thonghieu_socau = socauThongHieu;
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
            insert.tracnghiem_vandung_socau = socauVanDung;
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
            insert.tracnghiem_vandungcao_socau = socauVanDungCao;
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
                          where c.lesson_id == 0
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
                                where c.lesson_id == Convert.ToInt32(item)
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
            insert.tuluan_nhanbiet_socau = socauNhanBiet;
            insert.tuluan_nhanbiet_diem = Convert.ToDouble(txtTuLuan_Diem_NhanBiet.Value, CultureInfo.InvariantCulture);
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
            insert.tuluan_thonghieu_socau = socauThongHieu;
            insert.tuluan_thonghieu_diem = Convert.ToDouble(txtTuLuan_Diem_ThongHieu.Value, CultureInfo.InvariantCulture);

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
            insert.tuluan_vandung_socau = socauVanDung;
            insert.tuluan_vandung_diem = Convert.ToDouble(txtTuLuan_Diem_VanDung.Value, CultureInfo.InvariantCulture);

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
            insert.tuluan_vandungcao_socau = socauVanDungCao;
            insert.tuluan_vandungcao_diem = Convert.ToDouble(txtTuLuan_Diem_VanDungCao.Value, CultureInfo.InvariantCulture);
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
            txtTuLuan_NhanBiet.Value = 0 + "";
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
                        where c.lesson_id == 0
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
                              where c.lesson_id == Convert.ToInt32(item)
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
        update.tracnghiem_diem = Convert.ToDouble(ddlDiem.SelectedItem.Text, CultureInfo.InvariantCulture);
        if (txtTuLuan_NhanBiet.Value != "" && txtTracNghiem_NhanBiet.Value != "")
        {
            hieu_NhanBiet = Convert.ToDouble(txtTracNghiem_NhanBiet.Value, CultureInfo.InvariantCulture) - Convert.ToDouble(txtTuLuan_NhanBiet.Value, CultureInfo.InvariantCulture);
            socauNhanBiet = (int)(hieu_NhanBiet * Convert.ToDouble(ddlDiem.SelectedValue, CultureInfo.InvariantCulture));
            update.tracnghiem_nhanbiet = hieu_NhanBiet;
            update.tracnghiem_nhanbiet_socau = socauNhanBiet;
            var checkDuLieuNhanBiet = (getDuLieu.Where(x => x.question_dangcauhoi == "Nhận biết")).OrderBy(x => (~(x.question_id & seed)) & (x.question_id | seed)).Take(socauNhanBiet);
            foreach (var item in checkDuLieuNhanBiet)
            {
                chuoiCauHoi = chuoiCauHoi + "," + item.question_id;
            }
        }
        if (txtTuLuan_ThongHieu.Value != "" && txtTracNghiem_ThongHieu.Value != "")
        {
            hieu_ThongHieu = Convert.ToDouble(txtTracNghiem_ThongHieu.Value, CultureInfo.InvariantCulture) - Convert.ToDouble(txtTuLuan_ThongHieu.Value, CultureInfo.InvariantCulture);
            socauThongHieu = (int)(hieu_ThongHieu * Convert.ToDouble(ddlDiem.SelectedValue, CultureInfo.InvariantCulture));

            update.tracnghiem_thonghieu = hieu_ThongHieu;
            update.tracnghiem_thonghieu_socau = socauThongHieu;
            var checkDuLieuThongHieu = (getDuLieu.Where(x => x.question_dangcauhoi == "Thông hiểu")).OrderBy(x => (~(x.question_id & seed)) & (x.question_id | seed)).Take(socauThongHieu);
            foreach (var item in checkDuLieuThongHieu)
            {
                chuoiCauHoi = chuoiCauHoi + "," + item.question_id;
            }
        }
        if (txtTuLuan_VanDung.Value != "" && txtTracNghiem_VanDung.Value != "")
        {
            hieu_vanDung = Convert.ToDouble(txtTracNghiem_VanDung.Value, CultureInfo.InvariantCulture) - Convert.ToDouble(txtTuLuan_VanDung.Value, CultureInfo.InvariantCulture);
            socauVanDung = (int)(hieu_vanDung * Convert.ToDouble(ddlDiem.SelectedValue, CultureInfo.InvariantCulture));

            update.tracnghiem_vandung = hieu_vanDung;
            update.tracnghiem_vandung_socau = socauVanDung;
            var checkDuLieuVanDung = (getDuLieu.Where(x => x.question_dangcauhoi == "Vận dụng")).OrderBy(x => (~(x.question_id & seed)) & (x.question_id | seed)).Take(socauVanDung);
            foreach (var item in checkDuLieuVanDung)
            {
                chuoiCauHoi = chuoiCauHoi + "," + item.question_id;
            }
        }
        if (txtTuLuan_VanDungCao.Value != "" && txtTracNghiem_VanDungCao.Value != "")
        {
            hieu_VanDungCao = Convert.ToDouble(txtTracNghiem_VanDungCao.Value, CultureInfo.InvariantCulture) - Convert.ToDouble(txtTuLuan_VanDungCao.Value, CultureInfo.InvariantCulture);
            socauVanDungCao = (int)(hieu_VanDungCao * Convert.ToDouble(ddlDiem.SelectedValue, CultureInfo.InvariantCulture));

            update.tracnghiem_vandungcao = hieu_VanDungCao;
            update.tracnghiem_vandungcao_socau = socauVanDungCao;
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
        insert.luyentap_status = 1;
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

        db.tbTracNghiem_Tests.InsertOnSubmit(test);
        db.SubmitChanges();
        test.test_link = "bai-luyen-tap-chi-tiet-" + Convert.ToInt32(ddlKhoi.SelectedValue) + "/" + cls_ToAscii.ToAscii(txtTenBai.Value) + "-" + test.test_id;
        db.SubmitChanges();
        var getCauHoi = from qe in db.tbTracNghiem_Questions
                        select qe;
        int countTN_NB = 0;
        int countTN_TH = 0;
        int countTN_VD = 0;
        int countTN_VDC = 0;
        int countTL_NB = 0;
        int countTL_TH = 0;
        int countTL_VD = 0;
        int countTL_VDC = 0;

        string[] arrCauHoi = Session["chuoiCauHoi"].ToString().Split(',');
        string[] arrBai = lkBai.Text.Split(',');
        foreach (string bai in arrBai)
        {
            foreach (var item in arrCauHoi)
            {
                int _TNNB = getCauHoi.Where(x => x.lesson_id == Convert.ToInt32(bai)
                && x.question_id == Convert.ToInt32(item)
                && x.question_dangcauhoi == "Nhận biết"
                && x.question_type == "Trắc nghiệm").Count();
                if (_TNNB == 1)
                {
                    countTN_NB = countTN_NB + 1;
                    arrCauHoi = arrCauHoi.Where(val => val != item).ToArray();
                }
                else
                {
                    int _TNTH = getCauHoi.Where(x => x.lesson_id == Convert.ToInt32(bai)
               && x.question_id == Convert.ToInt32(item)
               && x.question_dangcauhoi == "Thông hiểu"
               && x.question_type == "Trắc nghiệm").Count();
                    if (_TNTH == 1)
                    {
                        arrCauHoi = arrCauHoi.Where(val => val != item).ToArray();
                        countTN_TH = countTN_TH + 1;
                    }
                    else
                    {
                        int _TNVD = getCauHoi.Where(x => x.lesson_id == Convert.ToInt32(bai)
                    && x.question_id == Convert.ToInt32(item)
                    && x.question_dangcauhoi == "Vận dụng"
                    && x.question_type == "Trắc nghiệm").Count();
                        if (_TNVD == 1)
                        {
                            arrCauHoi = arrCauHoi.Where(val => val != item).ToArray();
                            countTN_VD = countTN_VD + 1;
                        }
                        else
                        {
                            int _TNVDC = getCauHoi.Where(x => x.lesson_id == Convert.ToInt32(bai)
                        && x.question_id == Convert.ToInt32(item)
                        && x.question_dangcauhoi == "Vận dụng cao"
                        && x.question_type == "Trắc nghiệm").Count();
                            if (_TNVDC == 1)
                            {
                                arrCauHoi = arrCauHoi.Where(val => val != item).ToArray();
                                countTN_VDC = countTN_VDC + 1;
                            }
                            else
                            {
                                int _TLNB = getCauHoi.Where(x => x.lesson_id == Convert.ToInt32(bai)
                            && x.question_id == Convert.ToInt32(item)
                            && x.question_dangcauhoi == "Nhận biết"
                            && x.question_type == "Tự luận").Count();
                                if (_TLNB == 1)
                                {
                                    arrCauHoi = arrCauHoi.Where(val => val != item).ToArray();
                                    countTL_NB = countTL_NB + 1;
                                }
                                else
                                {
                                    int _TLTH = getCauHoi.Where(x => x.lesson_id == Convert.ToInt32(bai)
                                && x.question_id == Convert.ToInt32(item)
                                && x.question_dangcauhoi == "Thông hiểu"
                                && x.question_type == "Tự luận").Count();
                                    if (_TLTH == 1)
                                    {
                                        arrCauHoi = arrCauHoi.Where(val => val != item).ToArray();
                                        countTL_TH = countTL_TH + 1;
                                    }
                                    else
                                    {
                                        int _TLVD = getCauHoi.Where(x => x.lesson_id == Convert.ToInt32(bai)
                                    && x.question_id == Convert.ToInt32(item)
                                    && x.question_dangcauhoi == "Vận dụng"
                                    && x.question_type == "Tự luận").Count();
                                        if (_TLVD == 1)
                                        {
                                            arrCauHoi = arrCauHoi.Where(val => val != item).ToArray();
                                            countTL_VD = countTL_VD + 1;
                                        }
                                        else
                                        {
                                            int _TLVDC = getCauHoi.Where(x => x.lesson_id == Convert.ToInt32(bai)
                                        && x.question_id == Convert.ToInt32(item)
                                        && x.question_dangcauhoi == "Vận dụng cao"
                                        && x.question_type == "Tự luận").Count();
                                            if (_TLVDC == 1)
                                            {
                                                arrCauHoi = arrCauHoi.Where(val => val != item).ToArray();
                                                countTL_VDC = countTL_VDC + 1;
                                            }
                                            else
                                            {
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (txtLockInsert.Value == "0")
                {
                    tbTracNghiem_TestDetail cttest = new tbTracNghiem_TestDetail();
                    cttest.test_id = test.test_id;
                    cttest.question_id = Convert.ToInt32(item);
                    cttest.hidden = false;
                    db.tbTracNghiem_TestDetails.InsertOnSubmit(cttest);
                    db.SubmitChanges();
                }
            }
            txtLockInsert.Value = "1";
            // dòng 1
            tbTracNghiem_MaTranChiTiet add_TNNB = new tbTracNghiem_MaTranChiTiet();
            add_TNNB.matranchitiet_name = "TNNB";
            add_TNNB.matranchitiet_socau = countTN_NB + "";
            add_TNNB.matranchitiet_diemchitiet = ddlDiem.SelectedItem.Text;
            add_TNNB.matranchitiet_diem = (Convert.ToDouble(ddlDiem.SelectedItem.Text, CultureInfo.InvariantCulture) * countTN_NB) + "";
            add_TNNB.matranchitiet_phantram = (Convert.ToDouble(ddlDiem.SelectedItem.Text, CultureInfo.InvariantCulture) * countTN_NB) * 10 + "";
            add_TNNB.lession_id = Convert.ToInt32(bai);
            add_TNNB.test_id = test.test_id;
            db.tbTracNghiem_MaTranChiTiets.InsertOnSubmit(add_TNNB);

            // dòng 2
            tbTracNghiem_MaTranChiTiet add_TLNB = new tbTracNghiem_MaTranChiTiet();
            add_TLNB.matranchitiet_name = "TLNB";
            add_TLNB.matranchitiet_socau = countTL_NB + "";
            add_TLNB.matranchitiet_diemchitiet = txtTuLuan_Diem_NhanBiet.Value;
            add_TLNB.matranchitiet_diem = (Convert.ToDouble(txtTuLuan_Diem_NhanBiet.Value, CultureInfo.InvariantCulture) * countTL_NB) + "";
            add_TLNB.matranchitiet_phantram = (Convert.ToDouble(txtTuLuan_Diem_NhanBiet.Value, CultureInfo.InvariantCulture) * countTL_NB) * 10 + "";
            add_TLNB.lession_id = Convert.ToInt32(bai);
            add_TLNB.test_id = test.test_id;
            db.tbTracNghiem_MaTranChiTiets.InsertOnSubmit(add_TLNB);

            // dòng 3
            tbTracNghiem_MaTranChiTiet add_TNTH = new tbTracNghiem_MaTranChiTiet();
            add_TNTH.matranchitiet_name = "TNTH";
            add_TNTH.matranchitiet_socau = countTN_TH + "";
            add_TNTH.matranchitiet_diemchitiet = ddlDiem.SelectedItem.Text;
            add_TNTH.matranchitiet_diem = (Convert.ToDouble(ddlDiem.SelectedItem.Text, CultureInfo.InvariantCulture) * countTN_TH) + "";
            add_TNTH.matranchitiet_phantram = (Convert.ToDouble(ddlDiem.SelectedItem.Text, CultureInfo.InvariantCulture) * countTN_TH) * 10 + "";
            add_TNTH.lession_id = Convert.ToInt32(bai);
            add_TNTH.test_id = test.test_id;
            db.tbTracNghiem_MaTranChiTiets.InsertOnSubmit(add_TNTH);

            // dòng 4
            tbTracNghiem_MaTranChiTiet add_TLTH = new tbTracNghiem_MaTranChiTiet();
            add_TLTH.matranchitiet_name = "TLTH";
            add_TLTH.matranchitiet_socau = countTL_TH + "";
            add_TLTH.matranchitiet_diemchitiet = txtTuLuan_Diem_ThongHieu.Value;
            add_TLTH.matranchitiet_diem = (Convert.ToDouble(txtTuLuan_Diem_ThongHieu.Value, CultureInfo.InvariantCulture) * countTL_TH) + "";
            add_TLTH.matranchitiet_phantram = (Convert.ToDouble(txtTuLuan_Diem_ThongHieu.Value, CultureInfo.InvariantCulture) * countTL_TH) * 10 + "";
            add_TLTH.lession_id = Convert.ToInt32(bai);
            add_TLTH.test_id = test.test_id;
            db.tbTracNghiem_MaTranChiTiets.InsertOnSubmit(add_TLTH);

            //dòng 5
            tbTracNghiem_MaTranChiTiet add_TNVD = new tbTracNghiem_MaTranChiTiet();
            add_TNVD.matranchitiet_name = "TNVD";
            add_TNVD.matranchitiet_socau = countTN_VD + "";
            add_TNVD.matranchitiet_diemchitiet = ddlDiem.SelectedItem.Text;
            add_TNVD.matranchitiet_diem = (Convert.ToDouble(ddlDiem.SelectedItem.Text, CultureInfo.InvariantCulture) * countTN_VD) + "";
            add_TNVD.matranchitiet_phantram = (Convert.ToDouble(ddlDiem.SelectedItem.Text, CultureInfo.InvariantCulture) * countTN_VD) * 10 + "";
            add_TNVD.lession_id = Convert.ToInt32(bai);
            add_TNVD.test_id = test.test_id;
            db.tbTracNghiem_MaTranChiTiets.InsertOnSubmit(add_TNVD);

            // dòng 6
            tbTracNghiem_MaTranChiTiet add_TLVD = new tbTracNghiem_MaTranChiTiet();
            add_TLVD.matranchitiet_name = "TLVD";
            add_TLVD.matranchitiet_socau = countTL_VD + "";
            add_TLVD.matranchitiet_diemchitiet = txtTuLuan_Diem_VanDung.Value;
            add_TLVD.matranchitiet_diem = (Convert.ToDouble(txtTuLuan_Diem_VanDung.Value, CultureInfo.InvariantCulture) * countTL_VD) + "";
            add_TLVD.matranchitiet_phantram = (Convert.ToDouble(txtTuLuan_Diem_VanDung.Value, CultureInfo.InvariantCulture) * countTL_VD) * 10 + "";
            add_TLVD.lession_id = Convert.ToInt32(bai);
            add_TLVD.test_id = test.test_id;
            db.tbTracNghiem_MaTranChiTiets.InsertOnSubmit(add_TLVD);
            // dòng 7
            tbTracNghiem_MaTranChiTiet add_TNVDC = new tbTracNghiem_MaTranChiTiet();
            add_TNVDC.matranchitiet_name = "TNVDC";
            add_TNVDC.matranchitiet_socau = countTN_VDC + "";
            add_TNVDC.matranchitiet_diemchitiet = ddlDiem.SelectedItem.Text;
            add_TNVDC.matranchitiet_diem = (Convert.ToDouble(ddlDiem.SelectedItem.Text, CultureInfo.InvariantCulture) * countTN_VDC) + "";
            add_TNVDC.matranchitiet_phantram = (Convert.ToDouble(ddlDiem.SelectedItem.Text, CultureInfo.InvariantCulture) * countTN_VDC) * 10 + "";
            add_TNVDC.lession_id = Convert.ToInt32(bai);
            add_TNVDC.test_id = test.test_id;
            db.tbTracNghiem_MaTranChiTiets.InsertOnSubmit(add_TNVDC);

            //dòng 8
            tbTracNghiem_MaTranChiTiet add_TLVDC = new tbTracNghiem_MaTranChiTiet();
            add_TLVDC.matranchitiet_name = "TLVDC";
            add_TLVDC.matranchitiet_socau = countTL_VDC + "";
            add_TLVDC.matranchitiet_diemchitiet = txtTuLuan_Diem_VanDungCao.Value;
            add_TLVDC.matranchitiet_diem = (Convert.ToDouble(txtTuLuan_Diem_VanDungCao.Value, CultureInfo.InvariantCulture) * countTL_VDC) + "";
            add_TLVDC.matranchitiet_phantram = (Convert.ToDouble(txtTuLuan_Diem_VanDungCao.Value, CultureInfo.InvariantCulture) * countTL_VDC) * 10 + "";
            add_TLVDC.lession_id = Convert.ToInt32(bai);
            add_TLVDC.test_id = test.test_id;
            db.tbTracNghiem_MaTranChiTiets.InsertOnSubmit(add_TLVDC);

            countTN_NB = 0;
            countTN_TH = 0;
            countTN_VD = 0;
            countTN_VDC = 0;
            countTL_NB = 0;
            countTL_TH = 0;
            countTL_VD = 0;
            countTL_VDC = 0;

        }
        db.SubmitChanges();
        alert.alert_Success(Page, "Tạo đề thành công!", "");
        setNULL();
    }
    public void setNULL()
    {
        txtTuLuan_NhanBiet.Value = "";
        txtTuLuan_NhanBiet.Value = "";
        txtTuLuan_ThongHieu.Value = "";
        txtTuLuan_VanDung.Value = "";
        txtTracNghiem_NhanBiet.Value = "";
        txtTracNghiem_ThongHieu.Value = "";
        txtTracNghiem_VanDung.Value = "";
        txtTracNghiem_VanDungCao.Value = "";
        txtLockInsert.Value = "0";
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        List<object> selectedKey = grvDeLuyenTap.GetSelectedFieldValues(new string[] { "test_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                var user_test = (from u in db.tbTracNghiem_Tests
                                where u.test_id == Convert.ToInt32(item)
                                select u).FirstOrDefault();
                if(user_test.username_id != user_id)
                {
                    alert.alert_Warning(Page, "Không thể xóa bài luyện tập của giáo viên khác ", "");
                }
                else
                {
                    tbTracNghiem_Test del = db.tbTracNghiem_Tests.Where(x => x.test_id == Convert.ToInt32(item)).FirstOrDefault();
                    db.tbTracNghiem_Tests.DeleteOnSubmit(del);
                    try
                    {
                        db.SubmitChanges();
                        alert.alert_Success(Page, "Xoá  thành công!", "");
                    }
                    catch (Exception ex)
                    {
                        alert.alert_Error(Page, "Xoá không thành công!", "");
                    }
                }
            }
        }
        else
        {
            alert.alert_Warning(Page, "Bạn chưa chọn dữ liệu", "");
        }
    }
}