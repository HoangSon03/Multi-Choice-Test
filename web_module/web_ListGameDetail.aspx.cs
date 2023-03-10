using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_web_ListGameDetail : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int _idKhoi = Convert.ToInt32(RouteData.Values["id_khoi"]);
            int _idMon = Convert.ToInt32(RouteData.Values["id_mon"]);
            var getData = from t in db.tbTracNghiem_Tests
                          join lt in db.tbTracNghiem_BaiLuyenTaps on t.luyentap_id equals lt.luyentap_id
                          where t.khoi_id == _idKhoi && t.monhoc_id == _idMon
                          select new
                          {
                              t.monhoc_id,
                              t.test_id,
                              lt.luyentap_id,
                              lt.luyentap_name,
                              khoi_id = _idKhoi
                          };
            if (_idMon == 61)
            {
                div_TV_1.Visible = false;
            }
            else if (_idMon == 64)
            {
                div_math_1.Visible = false;
            }
        }

        //rpTracNghiem.DataSource = getData;
        //rpTracNghiem.DataBind();
    }
}