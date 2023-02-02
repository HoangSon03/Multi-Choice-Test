using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_ThongKe_admin_ThongKeTongSoLanLamBai : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Load Khói
            var listKhoi = from k in db.tbKhois select k;
            ddlKhoi.Items.Clear();
            ddlKhoi.Items.Insert(0, "Chọn khối");
            ddlKhoi.AppendDataBoundItems = true;
            ddlKhoi.DataTextField = "khoi_name";
            ddlKhoi.DataValueField = "khoi_id";
            ddlKhoi.DataSource = listKhoi;
            ddlKhoi.DataBind();
         
        }
    }
    protected void ddlKhoi_SelectedIndexChanged(object sender, EventArgs e)
    {
        var listLop = from l in db.tbLops
                      where l.khoi_id == Convert.ToInt32(ddlKhoi.SelectedValue)
                      select new
                      {
                          l.lop_id,
                          l.lop_name,
                          tongsoluong_hocsinhlambai = (from hstl in db.tbHocSinhTrongLops
                                                       where hstl.lop_id == l.lop_id && hstl.namhoc_id == 1
                                                       select hstl).Count(),
                          // tính số lượng học sinh làm bài trong lớp đó
                          soluong_hocsinhlambai = (from d in db.tbTracNghiem_ResultTests
                                                   where d.lop_id == l.lop_id
                                                   group d.hocsinh_code by d.hocsinh_code into g
                                                   select g.Key).Count()

                      };
        rpLop.DataSource = listLop;
        rpLop.DataBind();
    }

    protected void btnShowKetQuaHocSinhTrongLop_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("admin-thong-ke-so-lan-lam-bai-" + txtLop.Value);
    }
}