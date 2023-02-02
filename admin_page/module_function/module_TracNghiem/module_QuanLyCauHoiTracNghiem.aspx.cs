using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxHtmlEditor;
using OfficeOpenXml;

public partial class admin_page_module_function_module_TracNghiem_module_QuanLyCauHoiTracNghiem : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    int _id;
    int id_user;
    public string title_BaiHoc, image;
    protected void Page_Load(object sender, EventArgs e)
    {
        var checkTaiKhoan = (from u in db.admin_Users
                             where u.username_username == Request.Cookies["UserName"].Value
                             select u).FirstOrDefault();
        id_user = checkTaiKhoan.username_id;
        if (!IsPostBack)
        {
            edtContent.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
            edtDapAnA.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
            edtDapAnB.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
            edtDapAnC.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
            edtDapAnD.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
            edtGiaiThich.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
            Session["_id"] = 0;
        }
        loadData();
    }
    private void loadData()
    {
        var getCH_TN = from ch in db.tbTracNghiem_Questions
                           // join u in db.admin_Users on ch.username_id equals u.username_id
                           //  join k in db.tbGiaoVienDayKhois on u.username_id equals k.username_id
                           // join m in db.tbGiaoVienDayMons on u.username_id equals m.username_id
                       join c in db.tbTracNghiem_Chapters on ch.chapter_id equals c.chapter_id
                       join b in db.tbTracNghiem_Lessons on ch.lesson_id equals b.lesson_id
                       where ch.username_id == id_user
                       //    && ch.khoi_id == Convert.ToInt32(RouteData.Values["khoi_id"])
                       //   && m.monhoc_id == Convert.ToInt32(RouteData.Values["mon_id"])
                       && ch.chapter_id == Convert.ToInt32(RouteData.Values["chuong_id"])
                       && ch.lesson_id == Convert.ToInt32(RouteData.Values["baihoc_id"])
                       && ch.question_type == "Trắc nghiệm"
                       orderby ch.question_id descending
                       select new
                       {
                           c.chapter_id,
                           question_content = ch.question_content.Contains("style=") ? "<div class='content_image'>" + ch.question_content + "'</div>" : ch.question_content.Contains("jpg") ? "<img class='tracnghiem-answer__image' src='" + ch.question_content + "'>" : ch.question_content.Contains("png") ? "<img class='tracnghiem-answer__image' src='" + ch.question_content + "'>" : ch.question_content.Contains("mp3") ? " <audio controls> <source src = '" + ch.question_content + "'> </audio>" : ch.question_content,
                           ch.question_createdate,
                           question_level = ch.question_level,
                           b.lesson_name,
                           ch.question_id,
                           ch.question_dangcauhoi,
                       };
        grvList.DataSource = getCH_TN;
        grvList.DataBind();
    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        //luu file image
        SavefileImage();
        // đếm số đáp án chọn.
        int dem_DapAnChecked = 0;
        if (DaA.Checked == true)
        {
            dem_DapAnChecked = 1;
        }
        if (DaB.Checked == true)
        {
            dem_DapAnChecked = dem_DapAnChecked + 1;
        }
        if (DaC.Checked == true)
        {
            dem_DapAnChecked = dem_DapAnChecked + 1;
        }
        if (DaD.Checked == true)
        {
            dem_DapAnChecked = dem_DapAnChecked + 1;
        }
        if (edtContent.Html == "" && ddlLoaiCauHoi.SelectedValue == "Nhận biết")
        {
            alert.alert_Error(Page, "Bạn chưa nhập nội dung câu hỏi", "");
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "setCheckedDCH();setChecked()", true);
        }
        else if (DaA.Checked == false && DaB.Checked == false && DaC.Checked == false && DaD.Checked == false)
        {
            alert.alert_Error(Page, "Bạn cần chọn câu trả lời đúng", "");
        }
        else if (edtDapAnA.Html == "" || edtDapAnB.Html == "")
        {
            alert.alert_Error(Page, "Bạn cần nhập tối thiếu 2 nội dung đáp án theo thứ tự A,B,...", "");
        }
        //else if ((edtDapAnC.Html == "" || edtDapAnD.Html == "") && (DaC.Checked == false || DaD.Checked == false))
        //{
        //    alert.alert_Error(Page, "Lỗi ", "");
        //}
        else if (dem_DapAnChecked > 1)
        {
            alert.alert_Error(Page, "Bạn chỉ được chọn 1 đáp đúng", "");
        }
        else
        {
            if (Session["_id"].ToString() == "0")
            {
                tbTracNghiem_Question themcauhoi = new tbTracNghiem_Question();
                themdata();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "setCheckedDCH();setChecked();setForm();showImg1_1('" + image + "')", true);
                btnLuu.Text = "Cập nhật";
                btnLuuvaThemmoi.Text = "Cập nhật và thêm mới";
                if (ddlLoaiCauHoi.SelectedValue != "Nhận biết")
                {
                    themcauhoi.question_content = image;
                }
                else
                {
                    themcauhoi.question_content = edtContent.Html;
                }
            }
            else
            {
                //update
                updatedata();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "setCheckedDCH();setChecked();setForm();showImg1_1('" + image + "')", true);

            }
        }
    }
    protected void btnLuuvaThemmoi_Click1(object sender, EventArgs e)
    {
        SavefileImage();
        int dem_DapAnChecked = 0;
        if (DaA.Checked == true)
        {
            dem_DapAnChecked = 1;
        }
        if (DaB.Checked == true)
        {
            dem_DapAnChecked = dem_DapAnChecked + 1;
        }
        if (DaC.Checked == true)
        {
            dem_DapAnChecked = dem_DapAnChecked + 1;
        }
        if (DaD.Checked == true)
        {
            dem_DapAnChecked = dem_DapAnChecked + 1;
        }
        if (edtContent.Html == "" && image == null)
        {
            alert.alert_Error(Page, "Bạn chưa nhập nội dung câu hỏi", "");
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "setCheckedDCH();setChecked()", true);
        }
        else if (DaA.Checked == false && DaB.Checked == false && DaC.Checked == false && DaD.Checked == false)
        {
            alert.alert_Error(Page, "Bạn cần chọn câu trả lời đúng", "");
        }
        else if (edtDapAnA.Html == "" || edtDapAnB.Html == "")
        {
            alert.alert_Error(Page, "Bạn cần nhập tối thiếu 2 nội dung đáp án theo thứ tự A,B,...", "");
        }

        else if (dem_DapAnChecked > 1)
        {
            alert.alert_Error(Page, "Bạn chỉ được chọn 1 đáp đúng", "");
        }
        else
        {
            if (Session["_id"].ToString() == "0")
            {
                tbTracNghiem_Question themcauhoi = new tbTracNghiem_Question();
                themdata();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "setCheckedDCH();setChecked();setForm();", true);
                Session["_id"] = "0";
            }
            else
            {
                updatedata();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "setCheckedDCH();setChecked();setForm();", true);
                Session["_id"] = "0";
                btnLuu.Text = "Lưu";
                btnLuuvaThemmoi.Text = "Lưu và thêm mới";
            }
            datarong();
        }
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "question_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                tbTracNghiem_Question del = db.tbTracNghiem_Questions.Where(x => x.question_id == Convert.ToInt32(item)).FirstOrDefault();
                db.tbTracNghiem_Questions.DeleteOnSubmit(del);
                try
                {
                    db.SubmitChanges();
                    loadData();
                    datarong();
                    ddlLoaiCauHoi.Text = "Nhận biết";
                    alert.alert_Success(Page, "Xoá  thành công!", "");
                }
                catch (Exception ex)
                {
                    alert.alert_Error(Page, "Xoá không thành công!", "");
                }
            }
        }
        else
        {
            alert.alert_Warning(Page, "Bạn chưa chọn dữ liệu", "");
        }
    }

    protected void btnChiTiet_Click(object sender, EventArgs e)
    {
        int countDADung = 0;
        _id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "question_id" }));
        Session["_id"] = _id;
        var chitiet = (from ct in db.tbTracNghiem_Questions
                       join dt in db.tbTracNghiem_DacTas on Convert.ToInt32(ct.question_dacta) equals dt.dacta_id
                       where ct.question_id == _id
                       select new
                       {
                           ct.username_id,
                           ct.question_content,
                           ct.question_type,
                           ct.question_dangcauhoi,
                           ct.question_level,
                           ct.question_giaithich,
                           dt.dacta_content,
                       }).Single();
        if (chitiet.username_id == id_user)
        {
            txtLoaiCauHoi.Value = chitiet.question_level + "";
            ddlLoaiCauHoi.Text = chitiet.question_dangcauhoi + "";
            edtGiaiThich.Html = chitiet.question_giaithich;
            ddlDacTa.Text = chitiet.dacta_content;
            if (!chitiet.question_content.Contains("uploadimages"))
            {
                txtKieuCauHoi.Value = "0";
                edtContent.Html = chitiet.question_content;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "setCheckedDCH();setChecked();", true);
            }
            else
            {
                if (!chitiet.question_content.Contains("mp3"))
                {
                    image = chitiet.question_content;
                    txtKieuCauHoi.Value = "1";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "setCheckedDCH();setChecked();setForm();showImg1_1('" + image + "'),lockAudio()", true);
                }
                else
                {
                    txtKieuCauHoi.Value = "1";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "setCheckedDCH();setChecked();setForm();showImg1_1('" + image + "'),lockImg()", true);
                }
            }
            var chitietquestion = (from ctCH in db.tbTracNghiem_Answers
                                   where ctCH.question_id == _id
                                   select ctCH);
            edtDapAnA.Html = chitietquestion.First().answer_content;
            if (chitietquestion.First().answer_true == true)
            {
                DaA.Checked = true;
                countDADung++;
            }
            else
                DaA.Checked = false;
            edtDapAnB.Html = chitietquestion.Skip(1).First().answer_content;
            if (chitietquestion.Skip(1).First().answer_true == true)
            {
                DaB.Checked = true;
                countDADung++;
            }
            else
                DaB.Checked = false;
            edtDapAnC.Html = chitietquestion.Skip(2).First().answer_content;
            if (chitietquestion.Skip(2).First().answer_true == true)
            {
                DaC.Checked = true;
                countDADung++;
            }
            else
                DaC.Checked = false;
            edtDapAnD.Html = chitietquestion.Skip(3).First().answer_content;
            if (chitietquestion.Skip(3).First().answer_true == true)
            {
                DaD.Checked = true;
                countDADung++;
            }
            else
                DaD.Checked = false;

            btnLuu.Text = "Cập nhật";
            btnLuuvaThemmoi.Text = "Cập nhật và thêm mới";
        }
        else
        {
            alert.alert_Error(Page, "Sai thông tin người dùng", "");
        }
    }


    protected void btnTaiLaiTrang_Click(object sender, EventArgs e)
    {
        loadData();
        datarong();
        Session["_id"] = "0";
        ddlLoaiCauHoi.Text = "Nhận biết";
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "grvList.UnselectRows();setForm()", true);
    }

    private void datarong()
    {
        edtDapAnA.Html = "";
        edtDapAnB.Html = "";
        edtDapAnC.Html = "";
        edtDapAnD.Html = "";
        edtGiaiThich.Html = "";
        ddlDacTa.Text = "";
        DaA.Checked = false;
        DaB.Checked = false;
        DaC.Checked = false;
        DaD.Checked = false;
        edtContent.Html = "";
        btnLuu.Text = "Lưu";
        btnLuuvaThemmoi.Text = "Lưu và thêm mới";
    }
    private void themdata()
    {
        var getUser = (from u in db.admin_Users
                       where u.username_username == Request.Cookies["UserName"].Value
                       select u).SingleOrDefault();
        tbTracNghiem_Question themcauhoi = new tbTracNghiem_Question();
        if (edtContent.Html == "" && txtKieuCauHoi.Value != "0")
        {
            themcauhoi.question_content = image;
        }
        else
        {
            themcauhoi.question_content = edtContent.Html;
        }
        themcauhoi.question_createdate = DateTime.Now;
        themcauhoi.question_level = txtLoaiCauHoi.Value;
        themcauhoi.username_id = getUser.username_id;
        themcauhoi.chapter_id = Convert.ToInt32(RouteData.Values["chuong_id"]);
        themcauhoi.question_type = "Trắc nghiệm";
        themcauhoi.hidden = false;
        themcauhoi.question_dangcauhoi = ddlLoaiCauHoi.SelectedValue;
        themcauhoi.question_giaithich = edtGiaiThich.Html;
        themcauhoi.question_dacta = ddlDacTa.SelectedValue;
        themcauhoi.lesson_id = Convert.ToInt32(RouteData.Values["baihoc_id"]);
        db.tbTracNghiem_Questions.InsertOnSubmit(themcauhoi);
        db.SubmitChanges();
        Session["_id"] = themcauhoi.question_id;
        //lưu đáp án A
        tbTracNghiem_Answer dapanA = new tbTracNghiem_Answer();
        dapanA.answer_content = edtDapAnA.Html;
        dapanA.question_id = themcauhoi.question_id;
        if (DaA.Checked == true)
            dapanA.answer_true = true;
        else
            dapanA.answer_true = false;
        db.tbTracNghiem_Answers.InsertOnSubmit(dapanA);
        tbTracNghiem_Answer dapanB = new tbTracNghiem_Answer();
        dapanB.answer_content = edtDapAnB.Html;
        dapanB.question_id = themcauhoi.question_id;
        if (DaB.Checked == true)
            dapanB.answer_true = true;
        else
            dapanB.answer_true = false;
        db.tbTracNghiem_Answers.InsertOnSubmit(dapanB);
        tbTracNghiem_Answer dapanC = new tbTracNghiem_Answer();
        dapanC.answer_content = edtDapAnC.Html;
        dapanC.question_id = themcauhoi.question_id;
        if (DaC.Checked == true)
            dapanC.answer_true = true;
        else
            dapanC.answer_true = false;
        db.tbTracNghiem_Answers.InsertOnSubmit(dapanC);
        tbTracNghiem_Answer dapanD = new tbTracNghiem_Answer();
        dapanD.answer_content = edtDapAnD.Html;
        dapanD.question_id = themcauhoi.question_id;
        if (DaD.Checked == true)
            dapanD.answer_true = true;
        else
            dapanD.answer_true = false;
        db.tbTracNghiem_Answers.InsertOnSubmit(dapanD);
        db.SubmitChanges();
        alert.alert_Success(Page, "Lưu thành công", "");
        loadData();
    }
    private void updatedata()
    {
        var chitiet = (from ct in db.tbTracNghiem_Questions
                       where ct.question_id == Convert.ToInt32(Session["_id"].ToString())
                       select ct).Single();
        if (txtKieuCauHoi.Value != "0")
        {
            if (image != null)
            {
                chitiet.question_content = image;
            }
        }
        else
        {
            chitiet.question_content = edtContent.Html;
        }
        chitiet.question_level = txtLoaiCauHoi.Value;
        chitiet.question_dangcauhoi = ddlLoaiCauHoi.SelectedValue;
        chitiet.question_giaithich = edtGiaiThich.Html;
        chitiet.question_dacta = ddlDacTa.SelectedValue;
        db.SubmitChanges();
        // update bẳng answer
        //b1: tìm những đáp án của ch có trong bảng và xóa hết
        var xoaDA = from xDa in db.tbTracNghiem_Answers
                    where xDa.question_id == Convert.ToInt32(Session["_id"].ToString())
                    select xDa;
        db.tbTracNghiem_Answers.DeleteAllOnSubmit(xoaDA);
        //b2 insert lại 4 đáp án mới
        tbTracNghiem_Answer dapanA = new tbTracNghiem_Answer();
        dapanA.answer_content = edtDapAnA.Html;
        dapanA.question_id = chitiet.question_id;
        if (DaA.Checked == true)
            dapanA.answer_true = true;
        else
            dapanA.answer_true = false;
        db.tbTracNghiem_Answers.InsertOnSubmit(dapanA);
        tbTracNghiem_Answer dapanB = new tbTracNghiem_Answer();
        dapanB.answer_content = edtDapAnB.Html;
        dapanB.question_id = chitiet.question_id;
        if (DaB.Checked == true)
            dapanB.answer_true = true;
        else
            dapanB.answer_true = false;
        db.tbTracNghiem_Answers.InsertOnSubmit(dapanB);
        tbTracNghiem_Answer dapanC = new tbTracNghiem_Answer();
        dapanC.answer_content = edtDapAnC.Html;
        dapanC.question_id = chitiet.question_id;
        if (DaC.Checked == true)
            dapanC.answer_true = true;
        else
            dapanC.answer_true = false;
        db.tbTracNghiem_Answers.InsertOnSubmit(dapanC);
        tbTracNghiem_Answer dapanD = new tbTracNghiem_Answer();
        dapanD.answer_content = edtDapAnD.Html;
        dapanD.question_id = chitiet.question_id;
        if (DaD.Checked == true)
            dapanD.answer_true = true;
        else
            dapanD.answer_true = false;
        db.tbTracNghiem_Answers.InsertOnSubmit(dapanD);
        db.SubmitChanges();
        alert.alert_Success(Page, "Cập nhật thành công", "");
        btnLuu.Text = "Cập nhật";
        btnLuuvaThemmoi.Text = "Cập nhật và thêm mới";
        loadData();
    }
    private void SavefileImage()
    {
        if (Page.IsValid && FileUpload1.HasFile)
        {
            String folderUser;
            string url;
            string filename;
            string fileName_save;
            if (txtKieuCauHoi.Value == "1")
            {
                //lưu hình ảnh
                folderUser = Server.MapPath("~/uploadimages/anh_cauhoitracnghiem/");
                if (!Directory.Exists(folderUser))
                {
                    Directory.CreateDirectory(folderUser);
                }
                url = "/uploadimages/anh_cauhoitracnghiem/";
                HttpFileCollection hfc = Request.Files;
                filename = DateTime.Now.ToString("yyyyMMdd_") + FileUpload1.FileName;
                fileName_save = Path.Combine(Server.MapPath("~/uploadimages/anh_cauhoitracnghiem"), filename);
                FileUpload1.SaveAs(fileName_save);
                image = url + filename;
            }
            else if (txtKieuCauHoi.Value == "2")
            {
                //lưu video
                folderUser = Server.MapPath("~/uploadimages/video_cauhoitracnghiem/");
                if (!Directory.Exists(folderUser))
                {
                    Directory.CreateDirectory(folderUser);
                }
                url = "/uploadimages/video_cauhoitracnghiem/";
                HttpFileCollection hfc = Request.Files;
                filename = DateTime.Now.ToString("yyyyMMdd_") + FileUpload1.FileName;
                fileName_save = Path.Combine(Server.MapPath("~/uploadimages/video_cauhoitracnghiem"), filename);
                FileUpload1.SaveAs(fileName_save);
                image = url + filename;
            }
        }
    }

    protected void btnQuayLai_Click(object sender, EventArgs e)
    {

        Response.Redirect("admin-home");
    }
    protected void ddlLoaiCauHoi_SelectedIndexChanged(object sender, EventArgs e)
    {
        var listBai = from l in db.tbTracNghiem_DacTas
                      where l.khoi_id == Convert.ToInt16(RouteData.Values["khoi_id"])
                      && l.mon_id == Convert.ToInt16(RouteData.Values["mon_id"])
                      && l.chapter_id == Convert.ToInt16(RouteData.Values["chuong_id"])
                         && l.lession_id == Convert.ToInt16(RouteData.Values["baihoc_id"])
                         && l.dacta_loai == ddlLoaiCauHoi.Text
                      select l;
        if (listBai.Count() > 0)
        {
            ddlDacTa.Items.Clear();
            ddlDacTa.Items.Insert(0, "");
            ddlDacTa.AppendDataBoundItems = true;
            ddlDacTa.DataSource = listBai;
            ddlDacTa.DataTextField = "dacta_content";
            ddlDacTa.DataValueField = "dacta_id";
            ddlDacTa.DataBind();
            ddlDacTa.Enabled = true;
        }
        else
        {
            ddlDacTa.Items.Clear();
            ddlDacTa.Items.Insert(0, "Không có dữ liệu");
            ddlDacTa.AppendDataBoundItems = true;
            ddlDacTa.DataSource = listBai;
            ddlDacTa.DataBind();
        }
    }

    protected void btnNhapExcel_Click(object sender, EventArgs e)
    {
        if (FileUpload2.HasFile)
        {
            string fileName = FileUpload2.FileName;
            string ext = Path.GetExtension(fileName);
            if (ext.ToLower().Equals(".xlsx") || ext.ToLower().Equals(".xls"))
            {
                String folderUser = Server.MapPath("~/Excel_Files/De_luyen_tap/");
                if (!Directory.Exists(folderUser))
                {
                    Directory.CreateDirectory(folderUser);
                }
                //string filename;
                HttpFileCollection hfc = Request.Files;
                string filename = Path.GetFileNameWithoutExtension(FileUpload2.FileName);
                string path = string.Concat(Server.MapPath("~/Excel_Files/De_luyen_tap/" + filename + "_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ext));
                FileUpload2.SaveAs(path);
                //load the uploaded file into the memorystream
                //đặt debug đoạn này
                using (MemoryStream stream = new MemoryStream(FileUpload2.FileBytes))
                using (ExcelPackage excelPackage = new ExcelPackage(stream))
                {
                    //loop all worksheets
                    //foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];
                    //lặp các cột dòng thứ 2 để lấy các khoản thu, các thông tin câu hỏi bắt đầu từ cột 2 
                    //loop all rows
                    //int cell = 6;
                    for (int i = 2; i <= worksheet.Dimension.End.Row; i++)
                    {
                        //Nếu đọc cột part mà dữ liệu trống thì được hiểu là đã đọc cuối danh sách, kết thúc việc đọc
                        tbTracNghiem_Question p = new tbTracNghiem_Question();
                        p.question_content = worksheet.Cells[i, 2].Value + "";
                        p.question_createdate = DateTime.Today;
                        p.question_type = "Trắc nghiệm";
                        p.username_id = id_user;
                        p.chapter_id = Convert.ToInt32(RouteData.Values["chuong_id"]);
                        p.hidden = false;
                        p.question_dangcauhoi= worksheet.Cells[i, 3].Value + "";
                        p.question_level = worksheet.Cells[i, 4].Value + "";
                        p.question_giaithich= worksheet.Cells[i, 5].Value + "";
                        p.lesson_id = Convert.ToInt32(RouteData.Values["baihoc_id"]);
                        db.tbTracNghiem_Questions.InsertOnSubmit(p);
                        db.SubmitChanges();
                        tbTracNghiem_Answer a = new tbTracNghiem_Answer();
                        a.answer_content= worksheet.Cells[i, 6].Value + "";
                        a.question_id = p.question_id;
                        if(worksheet.Cells[i, 10].Value.ToString() == "A")
                        {
                            a.answer_true = true;
                        }
                        else
                        {
                            a.answer_true = false;
                        }
                        db.tbTracNghiem_Answers.InsertOnSubmit(a);
                        db.SubmitChanges();
                        tbTracNghiem_Answer b = new tbTracNghiem_Answer();
                        b.answer_content = worksheet.Cells[i, 7].Value + "";
                        b.question_id = p.question_id;
                        if (worksheet.Cells[i, 10].Value.ToString() == "B")
                        {
                            b.answer_true = true;
                        }
                        else
                        {
                            b.answer_true = false;
                        }
                        db.tbTracNghiem_Answers.InsertOnSubmit(b);
                        db.SubmitChanges();
                        tbTracNghiem_Answer c = new tbTracNghiem_Answer();
                        c.answer_content = worksheet.Cells[i, 8].Value + "";
                        c.question_id = p.question_id;
                        if (worksheet.Cells[i, 10].Value.ToString() == "C")
                        {
                            c.answer_true = true;
                        }
                        else
                        {
                            c.answer_true = false;
                        }
                        db.tbTracNghiem_Answers.InsertOnSubmit(c);
                        db.SubmitChanges();
                        tbTracNghiem_Answer d = new tbTracNghiem_Answer();
                        d.answer_content = worksheet.Cells[i, 9].Value + "";
                        d.question_id = p.question_id;
                        if (worksheet.Cells[i, 10].Value.ToString() == "D")
                        {
                            d.answer_true = true;
                        }
                        else
                        {
                            d.answer_true = false;

                        }
                        db.tbTracNghiem_Answers.InsertOnSubmit(d);
                        db.SubmitChanges();

                    }
                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Nhập thành công!','','success').then(function(){grvList.Refresh();})", true);
                }
            }
            else
                alert.alert_Warning(Page, "File chọn không đúng định dạng!", "");
        }
        else
        {
            alert.alert_Error(Page, "Vui lòng chọn file", "");
        }
    }
}