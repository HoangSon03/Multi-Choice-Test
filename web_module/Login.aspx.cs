using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_Login : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Value;
        var codehs = from cd in db.tbHocSinhs
                     where cd.hocsinh_code.Trim() == username
                     select cd;
        if (codehs.Count() > 0)
        {
            HttpCookie cookName = new HttpCookie("User_name");
            cookName.Value = username;
            cookName.Expires = DateTime.Today.AddDays(1);
            Response.Cookies.Add(cookName);
            try
            {
                if (Session == null || Session["Url_Test"] == null)
                    Response.Redirect("/trang-chu");
                else
                Response.Redirect("http://tracnghiem.vietnhatschool.edu.vn" + Session["Url_Test"].ToString());
            }
            catch (Exception) { }
        }
        else
        {
            alert.alert_Error(Page, "Sai tên đăng nhập", "");
        }
    }
}