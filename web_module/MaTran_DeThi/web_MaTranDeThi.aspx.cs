using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_MaTran_DeThi_web_MaTranDeThi : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            var checkTaiKhoan = (from u in db.admin_Users
                                 where u.username_username == Request.Cookies["UserName"].Value
                                 select u).FirstOrDefault();
        }
    }

    protected void btnChiTiet_ServerClick(object sender, EventArgs e)
    {

    }
}