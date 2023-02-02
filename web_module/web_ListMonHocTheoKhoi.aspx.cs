using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_web_ListMonHoc : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public int id_khoi;

    protected void Page_Load(object sender, EventArgs e)
    {
        id_khoi = Convert.ToInt32(RouteData.Values["id_khoi"]);
        var getMonHoc = from mhck in db.tbMonHocCuaKhois
                        join mh in db.tbMonHocs on mhck.monhoc_id equals mh.monhoc_id
                        where mhck.khoi_id == id_khoi && mhck.hidden == true
                        orderby mh.monhoc_name ascending
                        select new
                        {
                            mh.monhoc_id,
                            mh.monhoc_name,
                            mhck.khoi_id
                        };

        rpMonHoc.DataSource = getMonHoc;
        rpMonHoc.DataBind();
        rpBaiThi.DataSource = getMonHoc;
        rpBaiThi.DataBind();
    }
}