using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_MonHoc_Default2 : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private int _IdGiaoVien;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var listGiaoVien = from g in db.admin_Users
                               where g.groupuser_id == 3
                               select g;
            ddlGiaoVien.DataSource = listGiaoVien;
            ddlGiaoVien.DataTextField = "username_fullname";
            ddlGiaoVien.DataValueField = "username_id";
            ddlGiaoVien.DataBind();

            var listMonHoc = from h in db.tbMonHocs
                             select h;
            rpMon.DataSource = listMonHoc;
            rpMon.DataBind();

            var listGiaoVienDayMon = from d in db.tbGiaoVienDayMons
                                     join u in db.admin_Users on d.username_id equals u.username_id
                                     join m in db.tbMonHocs on d.monhoc_id equals m.monhoc_id
                                     orderby d.giaoviendaymon_id descending
                                     //where d.username_id == u.username_id && d.monhoc_id == m.monhoc_id
                                     select new
                                     {
                                         d.giaoviendaymon_id,
                                         u.username_fullname,
                                         m.monhoc_name,
                                     };
            grvList.DataSource = listGiaoVienDayMon;
            grvList.DataBind();

        }
        if (ddlGiaoVien.Text != "Chọn Giáo Viên")
        {

            _IdGiaoVien = Convert.ToInt32(ddlGiaoVien.SelectedValue);
            var getGiaoVienDayMon = (from d in db.tbGiaoVienDayMons
                                     join u in db.admin_Users on d.username_id equals u.username_id
                                     where d.username_id == _IdGiaoVien
                                     select d.monhoc_id);
            txtListMon.Value.ToList();
            txtListMon.Value = "";
            foreach (int item in getGiaoVienDayMon)
            {
                txtListMon.Value = txtListMon.Value + item + ",";
            }
            txtListMon.Value.ToList();
        }



    }

    private void loadGrid()
    {
        var loadList = from d in db.tbGiaoVienDayMons
                       join u in db.admin_Users on d.username_id equals u.username_id
                       join m in db.tbMonHocs on d.monhoc_id equals m.monhoc_id
                       orderby d.giaoviendaymon_id descending
                       select new
                       {
                           d.giaoviendaymon_id,
                           u.username_fullname,
                           m.monhoc_name,
                       };
        grvList.DataSource = loadList;
        grvList.DataBind();



    }
    protected void btnck_ServerClick(object sender, EventArgs e)
    {
        tbGiaoVienDayMon del = (from d in db.tbGiaoVienDayMons
                                where d.username_id == Convert.ToInt32(ddlGiaoVien.SelectedValue)
                                && d.monhoc_id == Convert.ToInt32(txtMonHidden.Value)
                                select d).FirstOrDefault();

        if (del == null)
        {
            tbGiaoVienDayMon insert = new tbGiaoVienDayMon();
            insert.username_id = Convert.ToInt32(ddlGiaoVien.SelectedValue);
            insert.monhoc_id = Convert.ToInt32(txtMonHidden.Value);
            db.tbGiaoVienDayMons.InsertOnSubmit(insert);
            db.SubmitChanges();
            alert.alert_Success(Page, "Thêm thành công", "");
            loadGrid();
        }
        else
        {

            db.tbGiaoVienDayMons.DeleteOnSubmit(del);
            db.SubmitChanges();
            alert.alert_Success(Page, "Xóa thành công", "");
            loadGrid();

        }
        var loadtxtMon = (from d in db.tbGiaoVienDayMons
                          where d.username_id == _IdGiaoVien
                          select d.monhoc_id);
        txtListMon.Value = "";
        txtListMon.Value.ToList();
        foreach (int item in loadtxtMon)
        {
            txtListMon.Value = txtListMon.Value + item + ",";
        }


    }
    protected void btnHuy_ServerClick(object sender, EventArgs e)
    {
      
        if (ddlGiaoVien.Text=="Chọn Giáo Viên")
        {
            alert.alert_Warning(Page, "Bạn chưa chọn thông tin", "");
        }
        else
        {
            var delete = (from d in db.tbGiaoVienDayMons
                          where d.username_id == Convert.ToInt32(ddlGiaoVien.SelectedValue)
                          select d);

            db.tbGiaoVienDayMons.DeleteAllOnSubmit(delete);
            db.SubmitChanges();
            alert.alert_Success(Page, "Xóa thành công", "");
        }
        loadGrid();
        var loadtxtMon = (from d in db.tbGiaoVienDayMons
                          where d.username_id == _IdGiaoVien
                          select d.monhoc_id);
        txtListMon.Value = "";
        txtListMon.Value.ToList();
        foreach (int item in loadtxtMon)
        {
            txtListMon.Value = txtListMon.Value + item + ",";
        }

    }
}