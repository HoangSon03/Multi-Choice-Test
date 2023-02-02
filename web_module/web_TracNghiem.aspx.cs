using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_web_TracNghiem : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();

    protected void Page_Load(object sender, EventArgs e)
    {
        int _idKhoi = Convert.ToInt32(RouteData.Values["id_khoi"]);
        int _idMon = Convert.ToInt32(RouteData.Values["id_mon"]);

        var getCh = from c in db.tbTracNghiem_Chapters
                    join mh in db.tbMonHocs on c.monhoc_id equals mh.monhoc_id
                    join k in db.tbKhois on c.khoi_id equals k.khoi_id
                    where c.khoi_id == _idKhoi && c.monhoc_id == _idMon
                    && c.hidden == true
                    select c;


        rpTracNghiem.DataSource = getCh;
        rpTracNghiem.DataBind();


    }
    
}