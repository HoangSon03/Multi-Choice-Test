using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_QuanLyGiaoVienDayHoc_module_ThemGiaoVienDayKhoi : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    int _idGV = 0;
    string _nameGV = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            var listGv = (from gv in db.admin_Users
                          where gv.groupuser_id == 3

                          select gv);

            ddlGiaoVien.Items.Clear();
            ddlGiaoVien.Items.Insert(0, "Chọn giáo viên");
            ddlGiaoVien.AppendDataBoundItems = true;
            ddlGiaoVien.DataTextField = "username_fullname";
            ddlGiaoVien.DataValueField = "username_id";
            ddlGiaoVien.DataSource = listGv;
            ddlGiaoVien.DataBind();
            var listKhoi = (from k in db.tbKhois select k);
            ckbKhoi.DataSource = listKhoi;
            ckbKhoi.DataBind();

        }
      
        if (ddlGiaoVien.Text != "Chọn giáo viên")
        {


            _idGV = Convert.ToInt32(ddlGiaoVien.SelectedValue);
            //txtKhoiName
            var getList_Checked = from gvdk in db.tbGiaoVienDayKhois
                                      //join gv in db.tbGiaoViens on gvdk.username_id equals gv.username_id
                                  join u in db.admin_Users on gvdk.username_id equals u.username_id
                                  where gvdk.username_id == _idGV
                                  select gvdk.khoi_id;

            foreach (int item in getList_Checked)
            {
                txtKhoiName.Value = txtKhoiName.Value + item + ",";

            }
        }
        
    }

    protected void btnThem_Click(object sender, EventArgs e)
    {
        if (txtKhoiHienTai.Value != "")
        {
            //alert.alert_Error(Page, "abgfdgas", "");

            int id_khoi = Convert.ToInt32(txtKhoiHienTai.Value);//1
            var getList_khoiID = from gvdk in db.tbGiaoVienDayKhois
                                 join u in db.admin_Users on gvdk.username_id equals u.username_id
                                 where gvdk.username_id == _idGV && gvdk.khoi_id == id_khoi
                                 select gvdk;
            if (getList_khoiID.Count() > 0)
            {
                //xoa
                db.tbGiaoVienDayKhois.DeleteAllOnSubmit(getList_khoiID);
                db.SubmitChanges();
                //alert.alert_Error(Page, "da day", "");
            }
            else
            {
                //them
                // alert.alert_Error(Page, "chua day", "");
                //var getKhoi_ID = from gvdk in db.tbGiaoVienDayKhois
                //                 join u in db.admin_Users on gvdk.username_id equals u.username_id
                //                 where gvdk.username_id == _idGV && gvdk.khoi_id == id_khoi
                //                 select new {
                //                     gvdk.username_id,
                //                     gvdk.khoi_id
                //} ;
                tbGiaoVienDayKhoi insert = new tbGiaoVienDayKhoi();
                insert.username_id = Convert.ToInt32(ddlGiaoVien.SelectedValue);
                insert.khoi_id = id_khoi;
                db.tbGiaoVienDayKhois.InsertOnSubmit(insert);
                db.SubmitChanges();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "tai_lai_trang()", true);
                //alert.alert_Success(Page, "Thanh cong!", " ");
            }
        }
        else
        {
            var listKhoiHT = (txtKhoiName.Value).Split(',');

        }
    }

    protected void ddlGiaoVien_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    // đưa về rỗng
    //txtKhoiName.Value = "";



    protected void btnCheck_ServerClick(object sender, EventArgs e)
    {
        if (ddlGiaoVien.Text != "Chọn giáo viên")
        {
            txtKhoiName.Value = "";
            tbGiaoVienDayKhoi checkDuLieu = (from gvdk in db.tbGiaoVienDayKhois
                                             where gvdk.khoi_id == Convert.ToInt16(txtKhoiHienTai.Value)
                                             && gvdk.username_id == Convert.ToInt16(ddlGiaoVien.SelectedValue)
                                             select gvdk).SingleOrDefault();
            if (checkDuLieu != null)
            {
                db.tbGiaoVienDayKhois.DeleteOnSubmit(checkDuLieu);
                db.SubmitChanges();

            }
            else
            {
                tbGiaoVienDayKhoi insert = new tbGiaoVienDayKhoi();
                insert.username_id = Convert.ToInt32(ddlGiaoVien.SelectedValue);
                insert.khoi_id = Convert.ToInt32(txtKhoiHienTai.Value);
                db.tbGiaoVienDayKhois.InsertOnSubmit(insert);
                db.SubmitChanges();
            }
            _idGV = Convert.ToInt32(ddlGiaoVien.SelectedValue);
            _nameGV = (ddlGiaoVien.SelectedItem).ToString();

            _idGV = Convert.ToInt32(ddlGiaoVien.SelectedValue);
            //txtKhoiName
            var getList_Checked = from gvdk in db.tbGiaoVienDayKhois
                                      //join gv in db.tbGiaoViens on gvdk.username_id equals gv.username_id
                                  join u in db.admin_Users on gvdk.username_id equals u.username_id
                                  where gvdk.username_id == _idGV
                                  select gvdk.khoi_id;

            foreach (int item in getList_Checked)
            {
                txtKhoiName.Value = txtKhoiName.Value + item + ",";
            }
        }
        else
        {
            alert.alert_Error(Page, "Vui lòng chọn giáo viên", "");
        }
    }
}
