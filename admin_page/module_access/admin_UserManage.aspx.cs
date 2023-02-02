using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_access_admin_UserManage : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private int _id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserName"] != null)
        {
            if (!IsPostBack)
            {
                Session["_id"] = 0;
            }
            loadDataGiaoVien();
        }
        else
        {
            Response.Redirect("/admin-login");
        }

    }
    // Dành cho root
    private void loadData()
    {
        var getData = from gv in db.admin_Users select gv;
        grvList.DataSource = getData;
        grvList.DataBind();
    }
    // Dành cho các trung tâm
    private void loadDataTrungTam()
    {
       // admin_User logedMember = Session["AdminLogined"] as admin_User;
        var getData = from gv in db.admin_Users
                      where gv.groupuser_id == 2
                      select gv;
        grvList.DataSource = getData;
        grvList.DataBind();
    }
    // Dành cho các giáo viên
    private void loadDataGiaoVien()
    {
       // admin_User logedMember = Session["AdminLogined"] as admin_User;

      
            var getData = from gv in db.admin_Users
                          where gv.username_id != 1
                          orderby gv.username_id descending
                          select new
                          {
                              gv.username_id,
                              gv.username_fullname,
                              gv.username_email,
                              gv.username_phone,
                              gv.username_username,
                              username_gender = gv.username_gender == true ? "Nam" : "Nữ"
                          };
            grvList.DataSource = getData;
            grvList.DataBind();
      
    }
    private void setNULL()
    {
        txtUserName.Text = "";
        txtFullname.Text = "";
        txtEmail.Text = "";
        txtPhone.Text = "";
        txtPass.Text = "";
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        Session["_id"] = 0;
        setNULL();
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Insert", "popupControl.Show();", true);
    }
    protected void btnChiTiet_Click(object sender, EventArgs e)
    {
        _id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "username_id" }));
        Session["_id"] = _id;
        var getData = (from gr in db.admin_Users
                       where gr.username_id == _id
                       select gr).Single();
        txtFullname.Text = getData.username_fullname;
        txtEmail.Text = getData.username_email;
        txtPhone.Text = getData.username_phone;
        txtUserName.Text = getData.username_username;
        txtPass.Text = getData.username_password;
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "popupControl.Show();", true);
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {

        cls_AccountAdmin cls;
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "username_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                cls = new cls_AccountAdmin();
                if (cls.Linq_Xoa(Convert.ToInt32(item)))
                    alert.alert_Success(Page, "Xóa thành công", "");
                else
                    alert.alert_Error(Page, "Xóa thất bại", "");
            }
        }
        else
            alert.alert_Warning(Page, "Bạn chưa chọn dữ liệu", "");
    }


    //Kiểm tra Email
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        cls_AccountAdmin cls = new cls_AccountAdmin();
        cls_security md5 = new cls_security();
        string passWord = txtPass.Text.Trim();
        string passmd5 = md5.HashCode(txtPass.Text);

        if (txtUserName.Text == "" || txtPass.Text == "")
            alert.alert_Warning(Page, "Vui lòng nhập đầy đủ thông tin!", "");
        else
        {
            if (Session["_id"].ToString() == "0")
            {
                if
                    (cls.Linq_Them(txtUserName.Text, passmd5, txtFullname.Text, txtPhone.Text, txtEmail.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Thêm thành công','','success').then(function(){grvList.Refresh();})", true);
                }
                else
                {
                    alert.alert_Error(Page, "Thêm thất bại", "");
                }
            }
            else
            {

                if (cls.Linq_Sua(Convert.ToInt32(Session["_id"].ToString()), txtUserName.Text, passmd5, txtFullname.Text, txtPhone.Text, txtEmail.Text))
                    alert.alert_Success(Page, "Cập nhật thành công", "");
                else alert.alert_Error(Page, "Cập nhật thất bại", "");
            }

            popupControl.ShowOnPageLoad = false;
        }
    }
}