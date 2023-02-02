using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var getId = (from hs in db.tbHocSinhs
                         join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                         join l in db.tbLops on hstl.lop_id equals l.lop_id
                         where hs.hocsinh_code == Request.Cookies["User_name"].Value.ToLower()
                         select l).FirstOrDefault().khoi_id;
            var getMonHoc = from mhck in db.tbMonHocCuaKhois
                            join mh in db.tbMonHocs on mhck.monhoc_id equals mh.monhoc_id
                            where mhck.khoi_id == getId && mhck.hidden == true
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
}