using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_TracNghiem_module_DuyetMon : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var khoi = from k in db.tbKhois
                       where k.khoi_id <= 12
                       select k;
            ddlKhoi.Items.Clear();
            ddlKhoi.AppendDataBoundItems = true;
            ddlKhoi.Items.Insert(0, "Chọn khối");
            ddlKhoi.DataValueField = "khoi_id";
            ddlKhoi.DataTextField = "khoi_name";
            ddlKhoi.DataSource = khoi;
            ddlKhoi.DataBind();
        }
        loaddataKhoi();
    }
    private void loaddataKhoi()
    {
        if (ddlKhoi.SelectedValue == "Chọn khối")
        {
            var getMonhoc = from mhck in db.tbMonHocCuaKhois
                            join k in db.tbKhois on mhck.khoi_id equals k.khoi_id
                            join mh in db.tbMonHocs on mhck.monhoc_id equals mh.monhoc_id
                            where mhck.hidden == false
                            select new
                            {
                                mhck.monhoccuakhoi_id,
                                k.khoi_name,
                                mh.monhoc_id,
                                mh.monhoc_name,
                                hidden = mhck.hidden == false ? "Chưa duyệt" : "Đã duyệt"
                            };
            grvListMH.DataSource = getMonhoc;
            grvListMH.DataBind();
        }
        else
        {
            var getMon = from gm in db.tbMonHocCuaKhois
                         join k in db.tbKhois on gm.khoi_id equals k.khoi_id
                         join mh in db.tbMonHocs on gm.monhoc_id equals mh.monhoc_id
                         where gm.khoi_id == Convert.ToInt32(ddlKhoi.SelectedValue) && gm.hidden == false
                         select new
                         {
                             gm.monhoccuakhoi_id,
                             k.khoi_name,
                             mh.monhoc_id,
                             mh.monhoc_name,
                             hidden = gm.hidden == false ? "Chưa duyệt" : "Đã duyệt"
                         };
            grvListMH.DataSource = getMon;
            grvListMH.DataBind();
        }
    }
    protected void ddlKhoi_SelectedIndexChanged1(object sender, EventArgs e)
    {
    }

    protected void btnDuyet_Click(object sender, EventArgs e)
    {
        List<object> selectedKey = grvListMH.GetSelectedFieldValues(new string[] { "monhoccuakhoi_id" });
        if (selectedKey.Count <= 0)
        {
            alert.alert_Warning(Page, "Bạn chưa chọn môn để duyệt", "");
        }
        else
        {
            foreach (var item in selectedKey)
            {
                var Duyet = (from d in db.tbMonHocCuaKhois
                             where d.monhoccuakhoi_id == Convert.ToInt32(item)
                             select d).SingleOrDefault();
                Duyet.hidden = true;
                db.SubmitChanges();
            }
            alert.alert_Success(Page, "Duyệt môn thành công", "");
            loaddataKhoi();
        }
    }

}