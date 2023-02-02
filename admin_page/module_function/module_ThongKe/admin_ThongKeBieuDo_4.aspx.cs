using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_ThongKe_admin_ThongKeBieuDo : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    private static string _id;
    public string monhoc = "";
    public string solan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _id = "hs01184";

            var list = from mh in db.tbMonHocs select new { mh.monhoc_name, mh.monhoc_id };
            foreach (var item in list)
            {
                monhoc = monhoc + "'" + item.monhoc_name + "',";
            }
            string mon_hoc = monhoc.TrimEnd(',');
            txtTenMonHoc.Value = mon_hoc;

            var getSoLan = from t in db.tbTracNghiem_Tests
                           join mh in db.tbMonHocs on t.monhoc_id equals mh.monhoc_id
                           join kq in db.tbTracNghiem_ResultTests on t.test_id equals kq.test_id
                           where kq.hocsinh_code == _id
                           group t by t.monhoc_id into g
                           select new
                           {
                               g.Key,
                               soLan = (from t in db.tbTracNghiem_Tests
                                       join mh in db.tbMonHocs on t.monhoc_id equals mh.monhoc_id
                                       where mh.monhoc_id == g.Key select mh).Count(),
                           };
            foreach (var item in getSoLan)
            {
                solan = solan + "'" + item.soLan + "',";
            }
            string so_lan = solan.TrimEnd(',');
            txtSoLanKiemTra.Value = so_lan;

            getName();
        }
    }
    protected void getName()
    {
        rpGetName.DataSource = db.tbHocSinhs.Where(hs => hs.hocsinh_code == _id).Select(hs => hs);
        rpGetName.DataBind();
    }
    protected void btnThem_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("admin-chi-tiet-thong-ke-bieu-do-4-"+ _id);
    }
}