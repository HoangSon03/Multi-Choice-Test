using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_CauHoiLuyenTap_module_ChiTiet_LamBaiTap : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private string _code;
    protected void Page_Load(object sender, EventArgs e)
    {
        _code = Convert.ToString(RouteData.Values["hocsinh_code"]);
        getdata();

    }
    private void getdata()
    {
        string name_hs = (from hs in db.tbHocSinhs where hs.hocsinh_code == _code select hs).First().hocsinh_name;
        var getData = from kq in db.tbTracNghiem_ResultTests
                      join test in db.tbTracNghiem_Tests on kq.test_id equals test.test_id
                      join lt in db.tbTracNghiem_BaiLuyenTaps on test.luyentap_id equals lt.luyentap_id
                      join mh in db.tbMonHocs on test.monhoc_id equals mh.monhoc_id
                      where kq.hocsinh_code == _code
                      orderby kq.resulttest_datetime descending
                      select new
                      {
                          kq.resulttest_id,
                          ngaylambai = Convert.ToDateTime(kq.resulttest_datetime).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                          kq.resulttest_result,
                          kq.result_thoigianlambai,
                          mh.monhoc_name,
                          lt.luyentap_name,
                      };
        txtName.InnerText = name_hs;
        grvList.DataSource = getData;
        grvList.DataBind();

    }
    protected void btnXem_ServerClick(object sender, EventArgs e)
    {
        if (dteTuNgay.Value == "" || dteDenNgay.Value == "")
        {
            alert.alert_Warning(Page, "Vui lòng chọn từ ngày đến ngày!", "");
        }
        else
        {
            var getData = from kq in db.tbTracNghiem_ResultTests
                          join test in db.tbTracNghiem_Tests on kq.test_id equals test.test_id
                          join lt in db.tbTracNghiem_BaiLuyenTaps on test.luyentap_id equals lt.luyentap_id
                          join mh in db.tbMonHocs on test.monhoc_id equals mh.monhoc_id
                          where kq.hocsinh_code == _code
                          && kq.resulttest_datetime.Value.Date >= Convert.ToDateTime(dteTuNgay.Value).Date
                       && kq.resulttest_datetime.Value.Month >= Convert.ToDateTime(dteTuNgay.Value).Month
                       && kq.resulttest_datetime.Value.Year >= Convert.ToDateTime(dteTuNgay.Value).Year
                       && kq.resulttest_datetime.Value.Date <= Convert.ToDateTime(dteDenNgay.Value).Date
                       && kq.resulttest_datetime.Value.Month >= Convert.ToDateTime(dteDenNgay.Value).Month
                       && kq.resulttest_datetime.Value.Year >= Convert.ToDateTime(dteDenNgay.Value).Year
                          orderby kq.resulttest_datetime descending
                          select new
                          {
                              kq.resulttest_id,
                              ngaylambai = Convert.ToDateTime(kq.resulttest_datetime).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                              kq.resulttest_result,
                              kq.result_thoigianlambai,
                              mh.monhoc_name,
                              lt.luyentap_name,
                          };
            grvList.DataSource = getData;
            grvList.DataBind();
        }
    }
}