using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_web_ListMonHoc : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();


    protected void Page_Load(object sender, EventArgs e)
    {
        int _idKhoi = Convert.ToInt32(RouteData.Values["id_khoi"]);
        //int _idMon = Convert.ToInt32(RouteData.Values["id_mon"]);

        var getMonHoc = from mhck in db.tbMonHocCuaKhois
                        join mh in db.tbMonHocs on mhck.monhoc_id equals mh.monhoc_id
                        where mhck.khoi_id == _idKhoi && mhck.hidden == true
                        orderby mh.monhoc_name ascending
                        select new
                        {
                            mh.monhoc_id,
                            mh.monhoc_name,
                            mhck.khoi_id
                        };

        rpMonHoc.DataSource = getMonHoc;
        rpMonHoc.DataBind();



    }


}