using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_ThongKe_admin_ThongKeBieuDo : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    private static string _id;
    public string ngay = "";
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //_id = "hs01184";
            _id = RouteData.Values["id"].ToString();
            var getdataMon = from mhck in db.tbMonHocs
                             select mhck;
            ddlMon.Items.Clear();
            ddlMon.AppendDataBoundItems = true;
            ddlMon.Items.Insert(0, "Chọn môn");
            ddlMon.DataValueField = "monhoc_id";
            ddlMon.DataTextField = "monhoc_name";
            ddlMon.DataSource = getdataMon;
            ddlMon.DataBind();

            getName();
        }
        // txtTenBaiKiemTra.Value = "'test1','test2','test3'";
    }
    protected void getName()
    {
        rpGetName.DataSource = db.tbHocSinhs.Where(hs => hs.hocsinh_code == _id).Select(hs => hs);
        rpGetName.DataBind();
    }
    //protected void ddlKiemTra_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //string diem = "";
    //    //var list = from kq in db.tbTracNghiem_ResultTests
    //    //           join test in db.tbTracNghiem_Tests on kq.test_id equals test.test_id
    //    //           join blt in db.tbTracNghiem_BaiLuyenTaps on test.luyentap_id equals blt.luyentap_id
    //    //           where blt.luyentap_id == Convert.ToInt32(ddlKiemTra.SelectedValue)
    //    //           && kq.hocsinh_code == _id
    //    //           select kq;
    //    //txtTenBaiKiemTra.Value = string.Join(",", list.Select(x => x.resulttest_datetime.Value.ToString("dd/MM", CultureInfo.InvariantCulture)).ToArray());
    //    //txtDiemBaiKiemTra.Value = string.Join(",", list.Select(x => x.resulttest_result).ToArray()); ;
    //    //ngay = "'test1','test2','test3'";
    //    // ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "myKetQuaBaiKiemTra("+ ngay + ")", true);
    //    //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "AlertBox", "swal('Cho ra kết quả!', '','success').then(function(){window.location = '/admin_page/module_function/module_ThongKe/admin_ThongKeBieuDo.aspx';})", true);
    //}

    protected void ddlMon_SelectedIndexChanged(object sender, EventArgs e)
    {
        var getdataKiemTra = from blt in db.tbTracNghiem_BaiLuyenTaps
                             join test in db.tbTracNghiem_Tests on blt.luyentap_id equals test.luyentap_id
                             where test.monhoc_id == Convert.ToInt32(ddlMon.SelectedValue)
                             select blt;
        ddlKiemTra.Items.Clear();
        ddlKiemTra.AppendDataBoundItems = true;
        ddlKiemTra.Items.Insert(0, "Chọn bài tập");
        ddlKiemTra.DataValueField = "luyentap_id";
        ddlKiemTra.DataTextField = "luyentap_name";
        ddlKiemTra.DataSource = getdataKiemTra;
        ddlKiemTra.DataBind();
    }

    protected void btnKetQua_ServerClick(object sender, EventArgs e)
    {
        if (dteTuNgay.Value == "" || dteDenNgay.Value == "")
        {
            alert.alert_Warning(Page, "Vui lòng chọn từ ngày đến ngày!", "");
        }
        else if (ddlMon.SelectedValue == "Chọn môn")
        {
            alert.alert_Warning(Page, "Vui lòng chọn môn học!", "");
        }
        else if (ddlKiemTra.SelectedValue == "Chọn bài tập" || ddlKiemTra.SelectedValue == "")
        {
            alert.alert_Warning(Page, "Vui lòng chọn bài tâp!", "");
        }
        else
        {
            var list = from kq in db.tbTracNghiem_ResultTests
                       join test in db.tbTracNghiem_Tests on kq.test_id equals test.test_id
                       join blt in db.tbTracNghiem_BaiLuyenTaps on test.luyentap_id equals blt.luyentap_id
                       where blt.luyentap_id == Convert.ToInt32(ddlKiemTra.SelectedValue)
                       && kq.hocsinh_code == _id
                       && kq.resulttest_datetime.Value.Date >= Convert.ToDateTime(dteTuNgay.Value).Date
                       && kq.resulttest_datetime.Value.Month >= Convert.ToDateTime(dteTuNgay.Value).Month
                       && kq.resulttest_datetime.Value.Year >= Convert.ToDateTime(dteTuNgay.Value).Year
                       && kq.resulttest_datetime.Value.Date <= Convert.ToDateTime(dteDenNgay.Value).Date
                       && kq.resulttest_datetime.Value.Month >= Convert.ToDateTime(dteDenNgay.Value).Month
                       && kq.resulttest_datetime.Value.Year >= Convert.ToDateTime(dteDenNgay.Value).Year
                       orderby kq.resulttest_datetime
                       select kq;
            //group kq by new
            //{
            //    kq.resulttest_datetime.Value.Date,
            //    kq.resulttest_datetime.Value.Month,
            //    kq.resulttest_datetime.Value.Year,
            //} into k
            //select new
            //{
            //    resulttest_datetime = k.First().resulttest_datetime,
            //    resulttest_result = k.Average(x => Convert.ToDouble(x.resulttest_result)),
            //};
            txtTenBaiKiemTra.Value = string.Join(";", list.Select(x => x.resulttest_datetime.Value.ToString("dd/MM", CultureInfo.InvariantCulture)).ToArray());
            txtDiemBaiKiemTra.Value = string.Join(";", list.Select(x => x.resulttest_result).ToArray());
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "myKetQuaBaiKiemTra()", true);
        }
    }
}