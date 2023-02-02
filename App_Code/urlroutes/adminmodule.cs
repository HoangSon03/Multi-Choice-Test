using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for adminmodule
/// </summary>
public class adminmodule
{
    public adminmodule()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<string> UrlRoutes()
    {
        List<string> list = new List<string>();

        list.Add("modulethoikhoabieutunggiaovien|admin-thoi-khoa-bieu|~/admin_page/module_function/module_OMT/omt_GiaoVien/admin_omt_NhapThoiKhoaBieuGiaoVien.aspx");
        list.Add("moduledanhmucluachon|admin-danh-muc-lua-chon|~/admin_page/module_function/DanhMucLuaChon.aspx");

        list.Add("modulequanlychuong|admin-chuong|~/admin_page/module_function/module_TracNghiem/module_QuanLyChuong.aspx");
        //Module thêm chương
        list.Add("modulethemchuong|admin-them-chuong-{khoi_id}-{mon_id}|~/admin_page/module_function/module_TracNghiem/module_QuanLyChuong.aspx");
        //Module quản lý môn học của khối
        list.Add("modulethemmonhoc|admin-them-mon-hoc-{khoi_id}|~/admin_page/module_function/module_MonHoc/module_QuanLyMonHocCuaKhoi.aspx");
        //Module thêm bài học
        list.Add("modulethembaihoc|admin-them-bai-hoc/{chuong_id}|~/admin_page/module_function/module_MonHoc/module_ThemBaiHoc.aspx");
        // Module thêm câu hỏi Trắc Nghiệm
        list.Add("modulethemcauhoitracnghiem|admin-quan-ly-cau-hoi-trac-nghiem-{khoi_id}-{mon_id}-{chuong_id}-{baihoc_id}|~/admin_page/module_function/module_TracNghiem/module_QuanLyCauHoiTracNghiem.aspx");

        list.Add("modulethemcauhoitracnghiemtuluan|admin-quan-ly-cau-hoi-tu-luan-{khoi_id}-{mon_id}-{chuong_id}-{baihoc_id}|~/admin_page/module_function/module_TracNghiem/module_QuanLyCauHoiTuLuan.aspx");
        // Module thêm câu hỏi Speaking
        list.Add("modulethemcauhoispeaking|admin-quan-ly-cau-hoi-speaking-{khoi_id}-{mon_id}-{chuong_id}-{baihoc_id}|~/admin_page/module_function/module_TracNghiem/module_QuanLyCauHoiSpeaking.aspx");
        // Module Thêm Câu Hỏi Writing
        list.Add("modulethemcauhoiwriting|admin-quan-ly-cau-hoi-writing-{khoi_id}-{mon_id}-{chuong_id}-{baihoc_id}|~/admin_page/module_function/module_TracNghiem/module_QuanLyCauHoiWriting.aspx");

        //3 Module tạo bài kiểm tra luyện tập
        list.Add("moduletaobaikiemtra|admin-tao-bai-kiem-tra|~/admin_page/module_function/module_BaiKiemTra/module_TaoBaiKiemTra.aspx");
        list.Add("moduletaobaikiemtrangaunhien|admin-tao-bai-kiem-tra-ngau-nhien|~/admin_page/module_function/module_BaiKiemTra/module_TaoBaiKiemTraNgauNhien.aspx");
        list.Add("moduledanhsachbaikiemtra|admin-danh-sach-bai-kiem-tra|~/admin_page/module_function/module_BaiKiemTra/module_DanhSachBaiKiemTra.aspx");
        list.Add("moduletaohsvaokiemtra|admin-hoc-sinh-vao-bai-kiem-tra|~/admin_page/module_function/module_BaiKiemTra/module_TaoHocSinhVaoBaiKiemTra.aspx");
        //3.1 tạo bài ngẫu nhiên
        list.Add("moduletaoluyentapngaunhien|admin-tao-bai-luyen-tap-ngau-nhien|~/admin_page/module_function/module_CauHoiLuyenTap/module_TaoDeLuyenTap_Version2.aspx");

        // module câu hỏi luyện tập
        list.Add("moduletaocauhoiluyentap|admin-tao-bai-luyen-tap|~/admin_page/module_function/module_CauHoiLuyenTap/module_TaoCauHoiLuyenTap.aspx");
        list.Add("moduletaocauhoiluyentapngaunhien|admin-tao-bai-luyen-tap-ngau-nhien|~/admin_page/module_function/module_CauHoiLuyenTap/module_TaoDeLuyenTap_Version2.aspx");
        list.Add("moduledanhsachbailuyentap|admin-danh-sach-bai-luyen-tap|~/admin_page/module_function/module_CauHoiLuyenTap/module_DanhSachBaiLuyenTap.aspx");
        list.Add("modulebailuyentapchitiet|admin-bai-luyen-tap-chi-tiet-{id}|~/admin_page/module_function/module_CauHoiLuyenTap/module_BaiLuyenTap_ChiTiet.aspx");
        list.Add("modulecapnhattracnghiem|admin-cap-nhat-cau-hoi-trac-nghiem-{khoi_id}-{mon_id}-{chuong_id}-{baihoc_id}-{test_id}|~/admin_page/module_function/module_TracNghiem/module_QuanLyCauHoi.aspx");
        //module duyệt môn - chương - bài
        list.Add("moduleduyetmonhoc|admin-duyet-mon-hoc|~/admin_page/module_function/module_Duyet/module_DuyetMon.aspx");
        list.Add("moduleduyetchuonghoc|admin-duyet-chuong-hoc|~/admin_page/module_function/module_Duyet/module_DuyetChuong.aspx");
        list.Add("moduleduyetbaihoc|admin-duyet-bai-hoc|~/admin_page/module_function/module_Duyet/module_DuyetBaiHoc.aspx");

        //module thống kê
        list.Add("modulethongkebieudo|admin-thong-ke-bieu-do-{id}|~/admin_page/module_function/module_ThongKe/admin_ThongKeBieuDo.aspx");
        //list.Add("modulethongketong|admin-thong-ke-tong|~/admin_page/module_function/module_ThongKe/admin_ThongKeTong.aspx");

        list.Add("moduletchitietthongkebieudo4|admin-chi-tiet-thong-ke-bieu-do-4-{hocsinh_code}|~/admin_page/module_function/module_ThongKe/admin_ChiTiet_ThongKeBieuDo_4.aspx");

        //module thống kê theo số lần làm bài
        list.Add("modulethongkesolanlambai|admin-thong-ke-so-lan-lam-bai-{lop_id}|~/admin_page/module_function/module_ThongKe/admin_BieuDoSoLanLamBai.aspx");
        list.Add("modulethongketongsolanlambai|admin-thong-ke-tong-so-lan-lam-bai|~/admin_page/module_function/module_ThongKe/admin_ThongKeTongSoLanLamBai.aspx");
        list.Add("moduletchitietlambaitap|admin-chi-tiet-lam-bai-tap-{hocsinh_code}|~/admin_page/module_function/module_ThongKe/admin_ChiTiet_LamBaiTap.aspx");

        //moduel kết quả học tập -rèn luyện
        list.Add("moduleketquabailuyentap|admin-ket-qua-luyen-tap|~/admin_page/module_function/module_KetQuaHocTap/admin_KetQuaBaiLuyenTap.aspx");

        //modun tiêng anh
        //admin-danh-sach-bai-kiem-tra-a2-b1

        list.Add("moduledanhsachbaikiemtraa2b1|admin-danh-sach-bai-kiem-tra-a2-b1|~/admin_page/module_function/module_English/module_DanhSachBaiKiemTra.aspx");
        list.Add("moduletaobaikiemtraa2b1|admin-tao-bai-kiem-tra-a2-b1|~/admin_page/module_function/module_English/module_TaoBaiKiemTra.aspx");
        list.Add("moduletaobaikiemtrangaunhiena2b1|admin-tao-bai-kiem-tra-ngau-nhien-a2-b1|~/admin_page/module_function/module_English/module_TaoBaiKiemTraNgauNhien.aspx");
       
        
        //module chấm điểm
        list.Add("modulechamdiemtienganha2b1|admin-cham-diem-tieng-anh-a2-b1|~/admin_page/module_function/module_ChamDiem/module_ChamDiemTiengAnh_A2B1.aspx");
        list.Add("modulethongkeketquaa2b1|admin-thong-ke-ket-qua-a2-b1|~/admin_page/module_function/module_ChamDiem/mudule_ThongKeKetQuaThi_A2B1.aspx");
        list.Add("modulethongketongtheodea2b1|admin-thong-ke-tong|~/admin_page/module_function/module_ChamDiem/module_BieuDoThongKeKetQuaTheoDe_A2B1.aspx");
        list.Add("modulethongkekynangtheodea2b1|admin-thong-ke-ky-nang-theo-de-a2-b1|~/admin_page/module_function/module_ChamDiem/module_BieuDoThongKeTheoKyNang_A2B1.aspx");

        //module quản lý chung
        list.Add("modulegiaoviendaykhoi|admin-quan-ly-giao-vien-day-khoi|~/admin_page/module_function/module_QuanLyGiaoVienDayHoc/module_ThemGiaoVienDayKhoi.aspx");
        list.Add("modulegiaoviendaymon|admin-quan-ly-giao-vien-day-mon|~/admin_page/module_function/module_MonHoc/module_QuanLyMonHocCuaKhoi.aspx");
        list.Add("moduledacta|admin-dac-ta|~/admin_page/module_function/module_DacTa.aspx");
        list.Add("moduleluyentapchitiet|admin-de-luyen-tap-chi-tiet-{test_id}|~/admin_page/module_function/module_CauHoiLuyenTap/module_BaiLuyenTap_ChiTiet.aspx");


        return list;
    }
}