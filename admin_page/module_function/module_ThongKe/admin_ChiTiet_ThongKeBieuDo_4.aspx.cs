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
        if (!IsPostBack)
        {
            _code = Convert.ToString(RouteData.Values["hocsinh_code"]);
            //_code = "hs01184";
            getdata();
        }
       
    }
    private void getdata()
    {
        //string name_hs = (from hs in db.tbHocSinhs where hs.hocsinh_code == _code select hs).First().hocsinh_name;
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

 
}