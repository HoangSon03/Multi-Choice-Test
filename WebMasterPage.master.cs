using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebMasterPage : System.Web.UI.MasterPage
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    public string User_name;
    private int _idKhoi;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["User_name"] != null)
        {

            //var getKhoiStudent = from khoi in db.tbKhois
            //                     join lop in db.tbLops on khoi.khoi_id equals lop.khoi_id
            //                     join hstl in db.tbHocSinhTrongLops on lop.lop_id equals hstl.lop_id
            //                     join hs in db.tbHocSinhs on hstl.hocsinh_id equals hs.hocsinh_id
            //                     where hs.hocsinh_code == Request.Cookies["User_name"].Value.ToLower()
            //                     && hstl.namhoc_id == 1
            //                     && khoi.khoi_id <= 12
            //                     select khoi;

            //rpKhoi.DataSource = getKhoiStudent;
            //rpKhoi.DataBind();

            var data = from k in db.tbKhois
                       where k.khoi_id <= 18 && k.khoi_id != 1 && k.khoi_id != 2
                       select k;
            rpKhoi.DataSource = data;
            rpKhoi.DataBind();


            //var getdata = from k in db.tbKhois
            //              where k.khoi_id <=2
            //              select k;
            //rpKhoiTest.DataSource = getdata;
            //rpKhoiTest.DataBind();


            User_name = (from ac in db.tbHocSinhs
                         where ac.hocsinh_code == Request.Cookies["User_name"].Value.ToLower()
                         select ac.hocsinh_name).SingleOrDefault();
            //Response.Redirect("/bai-kiem-tra-18.html");
        }
        else
        {
            Response.Redirect("/login-account");
        }
        //_idKhoi = Convert.ToInt32(txtIdKhoi.Value);
        //var check1 = from mhck in db.tbMonHocCuaKhois
        //             group mhck by mhck.khoi_id into k
        //             select new
        //             {
        //                 k.Key
        //             };
        //txtKTM.Value = string.Join(";", check1.Select(ktm => ktm.Key));
        //var check2 = from k in db.tbKhois
        //             select new
        //             {
        //                 k.khoi_id
        //             };
        //txtK.Value = string.Join(";", check2.Select(k => k.khoi_id));
    }


    private bool isEmail(string txtEmail)
    {
        Regex re = new Regex(@"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
                      RegexOptions.IgnoreCase);
        return re.IsMatch(txtEmail);
    }

    protected void btnDangKy_ServerClick(object sender, EventArgs e)
    {

    }

    //protected void rpKhoi_ItemDataBound(object sender, RepeaterItemEventArgs e)
    //{

    //    Repeater rpItem = e.Item.FindControl("rpItem") as Repeater;
    //    int khoi_id = int.Parse(DataBinder.Eval(e.Item.DataItem, "khoi_id").ToString());
    //    var getMonhoc = from mhch in db.tbMonHocCuaKhois
    //                    join mh in db.tbMonHocs on mhch.monhoc_id equals mh.monhoc_id
    //                    where mhch.khoi_id == khoi_id
    //                    select new
    //                    {
    //                        mh.monhoc_id,
    //                        mh.monhoc_name,
    //                        mhch.khoi_id
    //                    };
    //    rpItem.DataSource = getMonhoc;
    //    rpItem.DataBind();
    //}



    protected void btnDangXuat_ServerClick(object sender, EventArgs e)
    {
        if (Request.Cookies["User_name"] != null)
        {
            Response.Cookies["User_name"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("/login-account");
        }
    }
}
