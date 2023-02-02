using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_CauHoiLuyenTap_module_DanhSachBaiLuyenTap : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private int _id;
    private static int _idUser;
    protected void Page_Load(object sender, EventArgs e)
    {
        getdata();

        if(!IsPostBack)
        {
            var user = (from u in db.admin_Users
                        where u.username_username == Request.Cookies["UserName"].Value
                        select u).FirstOrDefault();

            if(user.groupuser_id == 1 || user.groupuser_id == 2 || user.groupuser_id == 3 || user.groupuser_id == 4) //only root or admin or teacher or worker can access 
            {
                _idUser = user.username_id;
            }
            else
            {
                _idUser = 0;
            }
        }
    }
    private void getdata()
    {
        var getdata = (from test in db.tbTracNghiem_Tests
                      join khoi in db.tbKhois on test.khoi_id equals khoi.khoi_id
                      join mh in db.tbMonHocs on test.monhoc_id equals mh.monhoc_id
                     // join c in db.tbTracNghiem_Chapters on khoi.khoi_id equals c.khoi_id
                      join lt in db.tbTracNghiem_BaiLuyenTaps on test.luyentap_id equals lt.luyentap_id
                      join user in db.admin_Users on test.username_id equals user.username_id
                      where user.username_username == Request.Cookies["UserName"].Value
                      && test.luyentap_id != null
                      && lt.luyentap_status == 1
                      select new
                      {
                          test.test_id,
                          khoi.khoi_name,
                          lt.luyentap_name,
                          lt.luyentap_id,
                          test.test_createdate,
                        //  c.chapter_name,
                          mh.monhoc_name,
                      }).OrderByDescending(test => test.test_createdate);
        grvList.DataSource = getdata;
        grvList.DataBind();

    }
    protected void build_url_Click(object sender, EventArgs e)
    {
        var test = (from t in db.tbTracNghiem_Tests
                    //join btk in db.tbTracNghiem_BaiThiCates on t.baithicate_id equals btk.baithicate_id
                    where t.test_id == Convert.ToInt32(id_key.Value) 
                    select new
                    {
                        //t.test_id,
                        //t.khoi_id,
                        //btk.baithicate_name,
                        t.test_link,
                    }).SingleOrDefault();

        string[] arrList = test.test_link.Split('/');
        string str_first = arrList[0];
        string str_sec = arrList[1];
        string duongdan = "http://tracnghiem.vietnhatschool.edu.vn/" + "truy-cap-" + str_first + "-" + _idUser + "/" + str_sec;
        url.Value = duongdan;
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "geturl()", true);
    }

    protected void btnChiTiet_ServerClick(object sender, EventArgs e)
    {
        try
        {
            List<object> selectedId = grvList.GetSelectedFieldValues(new string[] { "test_id" });
            if (selectedId.Count == 1)
            {
                foreach (var item in selectedId)
                {
                    _id = Convert.ToInt32(item);
                }
                Response.Redirect("admin-bai-luyen-tap-chi-tiet-" + _id);
            }
            else if (selectedId.Count == 0)
            {
                alert.alert_Warning(Page, "Chưa chọn bài luyện tập để xem!", "");
            }
            else if (selectedId.Count > 1)
            {
                alert.alert_Warning(Page, "Chỉ được chọn 1 bài luyện tập để xem!", "");
            }
        }
        catch(Exception)
        {
            alert.alert_Error(Page, "Lỗi! Xin vui lòng liên hệ tổ IT!", "");
        }
        
    }
}