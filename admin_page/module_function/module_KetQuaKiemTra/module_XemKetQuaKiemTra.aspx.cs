using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_KetQuaKiemTra_module_XemKetQuaKiemTra : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public int STT = 1;
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var listNV = from l in db.tbLops
                             //join gvtl in db.tbGiaoVienTrongLops on l.lop_id equals gvtl.lop_id
                             //join gv in db.admin_Users on gvtl.taikhoan_id equals gv.username_id
                         orderby l.lop_position ascending
                         select l;
            ddlLop.Items.Clear();
            ddlLop.Items.Insert(0, "Chọn lớp");
            ddlLop.AppendDataBoundItems = true;
            ddlLop.DataTextField = "lop_name";
            ddlLop.DataValueField = "lop_id";
            ddlLop.DataSource = listNV;
            ddlLop.DataBind();
        }
    }

    private void loadData()
    {
        if (dteTuNgay.Value == "" && dteDenNgay.Value == "")
        {
            alert.alert_Warning(Page, "Vui lòng chọn từ ngày nào đến ngày nào để hiển thỉ danh sách học sinh!", "");
        }
        else
        {
            if (ddlLop.SelectedValue == "Chọn lớp")
            {
                alert.alert_Warning(Page, "Vui lòng chọn lớp để hiển thỉ danh sách học sinh!", "");
            }
            else
            {
                if (ddlHocSinh.SelectedValue == "Tất cả" || ddlHocSinh.SelectedValue == "")
                {
                    var getData = from kq in db.tbTracNghiem_ResultTests
                                  join hs in db.tbHocSinhs on kq.hocsinh_code equals hs.hocsinh_code
                                  join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                                  join l in db.tbLops on hstl.lop_id equals l.lop_id
                                  join test in db.tbTracNghiem_Tests on kq.test_id equals test.test_id
                                  join mh in db.tbMonHocs on test.monhoc_id equals mh.monhoc_id
                                  where kq.resulttest_datetime.Value.Date >= Convert.ToDateTime(dteTuNgay.Value).Date
                                  && kq.resulttest_datetime.Value.Month >= Convert.ToDateTime(dteTuNgay.Value).Month
                                  && kq.resulttest_datetime.Value.Year >= Convert.ToDateTime(dteTuNgay.Value).Year
                                  && kq.resulttest_datetime.Value.Date <= Convert.ToDateTime(dteDenNgay.Value).Date
                                  && kq.resulttest_datetime.Value.Month >= Convert.ToDateTime(dteDenNgay.Value).Month
                                  && kq.resulttest_datetime.Value.Year >= Convert.ToDateTime(dteDenNgay.Value).Year
                                  && hstl.namhoc_id == 1
                                  select new
                                  {
                                      kq.resulttest_id,
                                      hs.hocsinh_name,
                                      kq.resulttest_datetime,
                                      kq.resulttest_result,
                                      mh.monhoc_name,
                                      //cate.baithicate_name,
                                      l.lop_name,
                                  };

                    rpList.DataSource = getData;
                    rpList.DataBind();
                }
                else
                {
                    //var getData = from nx in db.tbHocTap_NhanXetCuoiTuans
                    //              join l in db.tbLops on nx.lop_id equals l.lop_id
                    //              join hstl in db.tbHocSinhTrongLops on nx.mhstl_id equals hstl.hstl_id
                    //              join hs in db.tbHocSinhs on hstl.hocsinh_id equals hs.hocsinh_id
                    //              where nx.lop_id == Convert.ToInt32(ddlLop.SelectedValue)
                    //              && hs.hocsinh_id == Convert.ToInt32(ddlHocSinh.SelectedValue)
                    //              && nx.nxct_ngaydanhgia >= Convert.ToDateTime(dteTuNgay.Value)
                    //              && nx.nxct_ngaydanhgia <= Convert.ToDateTime(dteDenNgay.Value)
                    //              select new
                    //              {
                    //                  hs.hocsinh_name,
                    //                  nx.nxct_mon,
                    //                  nx.nxct_ngaydanhgia,
                    //                  nx.nxct_nhanxet,
                    //                  nx.nxct_danhgia,
                    //                  l.lop_name,
                    //              };
                    //rpList.DataSource = getData;
                    //rpList.DataBind();
                }
            }
        }
    }
    protected void ddlLop_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLop.SelectedValue == "Chọn lớp")
        {
            ddlHocSinh.Text = "Tất cả";
        }
        else
        {
            var listNV = from l in db.tbLops
                             //join gvtl in db.tbGiaoVienTrongLops on l.lop_id equals gvtl.lop_id
                         join hstl in db.tbHocSinhTrongLops on l.lop_id equals hstl.lop_id
                         join hs in db.tbHocSinhs on hstl.hocsinh_id equals hs.hocsinh_id
                         where l.lop_id == Convert.ToInt32(ddlLop.SelectedValue)
                         && hstl.namhoc_id == 1
                         select hs;
            ddlHocSinh.Items.Clear();
            ddlHocSinh.Items.Insert(0, "Tất cả");
            ddlHocSinh.AppendDataBoundItems = true;
            ddlHocSinh.DataTextField = "hocsinh_name";
            ddlHocSinh.DataValueField = "hocsinh_id";
            ddlHocSinh.DataSource = listNV;
            ddlHocSinh.DataBind();
        }
    }

    protected void btnXem_ServerClick(object sender, EventArgs e)
    {
        loadData();
    }
}