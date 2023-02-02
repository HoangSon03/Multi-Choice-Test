using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_KetQuaHocTap_admin_KetQuaBaiLuyenTap : System.Web.UI.Page
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
    private void loadData()
    {
        if (dteTuNgay.Value == "" && dteDenNgay.Value == "")
        {
            alert.alert_Warning(Page, "Vui lòng chọn từ ngày đến ngày!", "");
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
                    var getData = from kqlt in db.tbTracNghiem_ResultTests
                                  join hs in db.tbHocSinhs on kqlt.hocsinh_code equals hs.hocsinh_code
                                  join l in db.tbLops on kqlt.lop_id equals l.lop_id
                                  join test in db.tbTracNghiem_Tests on kqlt.test_id equals test.test_id
                                  join mh in db.tbMonHocs on test.monhoc_id equals mh.monhoc_id
                                  join blt in db.tbTracNghiem_BaiLuyenTaps on test.luyentap_id equals blt.luyentap_id
                                  join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                                  where kqlt.resulttest_datetime.Value.Date >= Convert.ToDateTime(dteTuNgay.Value).Date
                                    && kqlt.resulttest_datetime.Value.Month >= Convert.ToDateTime(dteTuNgay.Value).Month
                                    && kqlt.resulttest_datetime.Value.Year >= Convert.ToDateTime(dteTuNgay.Value).Year
                                    && kqlt.resulttest_datetime.Value.Date <= Convert.ToDateTime(dteDenNgay.Value).Date
                                    && kqlt.resulttest_datetime.Value.Month >= Convert.ToDateTime(dteDenNgay.Value).Month
                                    && kqlt.resulttest_datetime.Value.Year >= Convert.ToDateTime(dteDenNgay.Value).Year
                                    && hstl.namhoc_id == 1
                                  select new
                                  {
                                      kqlt.resulttest_id,
                                      hs.hocsinh_name,
                                      l.lop_name,
                                      mh.monhoc_name,
                                      blt.luyentap_name,
                                      kqlt.resulttest_result,
                                      kqlt.resulttest_datetime,
                                      kqlt.result_thoigianlambai

                                  };

                    rpList.DataSource = getData;
                    rpList.DataBind();
                }
                else
                {
                    var getData = from kqlt in db.tbTracNghiem_ResultTests
                                  join hs in db.tbHocSinhs on kqlt.hocsinh_code equals hs.hocsinh_code
                                  join l in db.tbLops on kqlt.lop_id equals l.lop_id
                                  join test in db.tbTracNghiem_Tests on kqlt.test_id equals test.test_id
                                  join mh in db.tbMonHocs on test.monhoc_id equals mh.monhoc_id
                                  join blt in db.tbTracNghiem_BaiLuyenTaps on test.luyentap_id equals blt.luyentap_id
                                  join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                                  where kqlt.resulttest_datetime.Value.Date >= Convert.ToDateTime(dteTuNgay.Value).Date
                                    && kqlt.resulttest_datetime.Value.Month >= Convert.ToDateTime(dteTuNgay.Value).Month
                                    && kqlt.resulttest_datetime.Value.Year >= Convert.ToDateTime(dteTuNgay.Value).Year
                                    && kqlt.resulttest_datetime.Value.Date <= Convert.ToDateTime(dteDenNgay.Value).Date
                                    && kqlt.resulttest_datetime.Value.Month >= Convert.ToDateTime(dteDenNgay.Value).Month
                                    && kqlt.resulttest_datetime.Value.Year >= Convert.ToDateTime(dteDenNgay.Value).Year
                                    && hstl.namhoc_id == 1 && hs.hocsinh_id == Convert.ToInt32(ddlHocSinh.SelectedValue)
                                  select new
                                  {
                                      kqlt.resulttest_id,
                                      hs.hocsinh_name,
                                      l.lop_name,
                                      mh.monhoc_name,
                                      blt.luyentap_name,
                                      kqlt.resulttest_result,
                                      kqlt.resulttest_datetime,
                                      kqlt.result_thoigianlambai,
                                  };

                    rpList.DataSource = getData;
                    rpList.DataBind();
                }
            }
        }
    }
    protected void btnXem_ServerClick(object sender, EventArgs e)
    {
        loadData();
    }
}