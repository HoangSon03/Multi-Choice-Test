using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_BaiKiemTraTest_module_TaoBaiKiemTraNgauNhien : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    DataTable dtCauHoi;
    protected void Page_Load(object sender, EventArgs e)
    {
        //lấy thông tin tk đăng nhập
        var getUser = (from u in db.admin_Users
                       where u.username_username == Request.Cookies["UserName"].Value
                       select u).SingleOrDefault();
        if (!IsPostBack)
        {
            ddlMon.Visible = false;
            lkChapter.Visible = false;
            dvSoCauHoi.Visible = false;
            btnTaoDe.Visible = false;
            var getKhoi = from k in db.tbKhois
                          where k.khoi_id <= 12
                          select k;
            ddlKhoi.Items.Clear();
            ddlKhoi.AppendDataBoundItems = true;
            ddlKhoi.Items.Insert(0, "Chọn khối");
            ddlKhoi.DataValueField = "khoi_id";
            ddlKhoi.DataTextField = "khoi_name";
            ddlKhoi.DataSource = getKhoi;
            ddlKhoi.DataBind();
            Session["CauHoi"] = null;
        }
        if (lkChapter.Text != "")
        {
            dvSoCauHoi.Visible = true;
            btnTaoDe.Visible = true;
        }
        if (grvList.VisibleRowCount.ToString() != "0")
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "displayButton()", true);
        }
        loaddatatable();
    }
    public void loaddatatable()
    {
        try
        {
            if (dtCauHoi == null)
            {
                dtCauHoi = new DataTable();
                dtCauHoi.Columns.Add("question_id", typeof(int));
                dtCauHoi.Columns.Add("question_content", typeof(string));
                dtCauHoi.Columns.Add("chapter_name", typeof(string));
                dtCauHoi.Columns.Add("username_fullname", typeof(string));
            }
        }
        catch { }
    }

    //tạo bài ktra 15 phút
    protected void btnBaiKT15Phut_Click(object sender, EventArgs e)
    {
        string _id = lkChapter.Text;
        string[] arrListStr = _id.Split(',');
        var listrandom = from ch in db.tbTracNghiem_Questions
                         join c in db.tbTracNghiem_Chapters on ch.chapter_id equals c.chapter_id
                         join u in db.admin_Users on ch.username_id equals u.username_id
                         where c.chapter_name == "" && ch.hidden == false
                         select new
                         {
                             ch.question_id,
                             ch.question_content,
                             ch.question_type,
                             c.chapter_name,
                             u.username_fullname
                         };
        //duyệt vòng for để lấy số câu hỏi ứng với từng loại câu hỏi (dễ-vừa-khó)
        var list = from ch in db.tbTracNghiem_Questions
                   join c in db.tbTracNghiem_Chapters on ch.chapter_id equals c.chapter_id
                   join u in db.admin_Users on ch.username_id equals u.username_id
                   where c.chapter_name == "" && ch.hidden == false
                   select new
                   {
                       ch.question_id,
                       ch.question_content,
                       ch.question_type,
                       c.chapter_name,
                       u.username_fullname
                   };
        foreach (string item in arrListStr)
        {
            var list1 = from ch in db.tbTracNghiem_Questions
                        join c in db.tbTracNghiem_Chapters on ch.chapter_id equals c.chapter_id
                        join u in db.admin_Users on ch.username_id equals u.username_id
                        where c.chapter_name == item.ToString().Trim() && ch.hidden == false
                        select new
                        {
                            ch.question_id,
                            ch.question_content,
                            ch.question_type,
                            c.chapter_name,
                            u.username_fullname
                        };
            list = list.Union(list1);
        }
        //duyệt trong list tổng để lấy ra 5 câu dễ, 3 câu vừa,2 câu khó cho bộ đề

        if (list.Count() < 10)
        {
            alert.alert_Error(Page, "Bộ câu hỏi không đủ để tạo đề!", "Vui lòng chọn thêm dữ liệu");
        }
        else if (list.Count() == 10)
        {
            grvList.DataSource = list;
            grvList.DataBind();
            //txtLoaiBaiThi.Value = "1";
            dtCauHoi = (DataTable)list;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "showButtonLuu()", true);
        }
        else
        {
            var ListDe = from ld in list
                         where ld.question_type == "Dễ"
                         select ld;
            var ListVua = from lv in list
                          where lv.question_type == "Vừa"
                          select lv;
            var ListKho = from lk in list
                          where lk.question_type == "Khó"
                          select lk;
            if (ListDe.Count() < 5 || ListVua.Count() < 3 || ListKho.Count() < 2)
            {
                alert.alert_Error(Page, "Bộ câu hỏi không đủ để tạo đề!", "Vui lòng chọn thêm dữ liệu");
            }
            else
            {
                Random rnd1 = new Random();
                do
                {
                    int rd1 = rnd1.Next(1, ListDe.Count());
                    listrandom = listrandom.Union(ListDe.Skip(rd1 - 1).Take(1));
                    listrandom.Count();
                    Thread.Sleep(100);
                }
                while (listrandom.Count() < 5);
                do
                {
                    int rd1 = rnd1.Next(1, ListVua.Count());
                    listrandom = listrandom.Union(ListVua.Skip(rd1 - 1).Take(1));
                    listrandom.Count();
                    Thread.Sleep(100);
                }
                while (listrandom.Count() < 8);
                do
                {
                    int rd1 = rnd1.Next(1, ListKho.Count());
                    listrandom = listrandom.Union(ListKho.Skip(rd1 - 1).Take(1));
                    listrandom.Count();
                    Thread.Sleep(100);
                }
                while (listrandom.Count() < 10);
            }
            grvList.DataSource = listrandom;
            grvList.DataBind();
            Session["CauHoi"] = listrandom;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "showButtonLuu()", true);
        }
    }

    // tạo bài kiểm tra 40 câu
    protected void btnBaiKT1Tiet1_Click(object sender, EventArgs e)
    {
        string _id = lkChapter.Text;
        string[] arrListStr = _id.Split(',');
        var listrandom = from ch in db.tbTracNghiem_Questions
                         join c in db.tbTracNghiem_Chapters on ch.chapter_id equals c.chapter_id
                         join u in db.admin_Users on ch.username_id equals u.username_id
                         where c.chapter_name == "" && ch.hidden == false
                         select new
                         {
                             ch.question_id,
                             ch.question_content,
                             ch.question_type,
                             c.chapter_name,
                             u.username_fullname
                         };
        //duyệt vòng for để lấy số câu hỏi ứng với từng loại câu hỏi (dễ-vừa-khó)
        var list = from ch in db.tbTracNghiem_Questions
                   join c in db.tbTracNghiem_Chapters on ch.chapter_id equals c.chapter_id
                   join u in db.admin_Users on ch.username_id equals u.username_id
                   where c.chapter_name == "" && ch.hidden == false
                   select new
                   {
                       ch.question_id,
                       ch.question_content,
                       ch.question_type,
                       c.chapter_name,
                       u.username_fullname
                   };
        foreach (string item in arrListStr)
        {
            var list1 = from ch in db.tbTracNghiem_Questions
                        join c in db.tbTracNghiem_Chapters on ch.chapter_id equals c.chapter_id
                        join u in db.admin_Users on ch.username_id equals u.username_id
                        where c.chapter_name == item.ToString().Trim()
                        select new
                        {
                            ch.question_id,
                            ch.question_content,
                            ch.question_type,
                            c.chapter_name,
                            u.username_fullname
                        };
            list = list.Union(list1);
        }
        //duyệt trong list tổng để lấy ra 20 câu dễ, 12 câu vừa, 8 câu khó cho bộ đề

        if (list.Count() < 40)
        {
            alert.alert_Error(Page, "Bộ câu hỏi không đủ để tạo đề!", "Vui lòng chọn thêm dữ liệu");
        }
        else if (list.Count() == 40)
        {
            grvList.DataSource = list;
            grvList.DataBind();
            //txtLoaiBaiThi.Value = "2";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "showButtonLuu()", true);
        }
        else
        {
            var ListDe = from ld in list
                         where ld.question_type == "Dễ"
                         select ld;
            var ListVua = from lv in list
                          where lv.question_type == "Vừa"
                          select lv;
            var ListKho = from lk in list
                          where lk.question_type == "Khó"
                          select lk;
            if (ListDe.Count() < 20 || ListVua.Count() < 12 || ListKho.Count() < 8)
            {
                alert.alert_Error(Page, "Bộ câu hỏi không đủ để tạo đề!", "Vui lòng chọn thêm dữ liệu");
            }
            else
            {
                Random rnd1 = new Random();
                do
                {
                    int rd1 = rnd1.Next(1, ListDe.Count());
                    listrandom = listrandom.Union(ListDe.Skip(rd1 - 1).Take(1));
                    listrandom.Count();
                    Thread.Sleep(100);
                }
                while (listrandom.Count() < 20);
                do
                {
                    int rd1 = rnd1.Next(1, ListVua.Count());
                    listrandom = listrandom.Union(ListVua.Skip(rd1 - 1).Take(1));
                    listrandom.Count();
                    Thread.Sleep(100);
                }
                while (listrandom.Count() < 32);
                do
                {
                    int rd1 = rnd1.Next(1, ListKho.Count());
                    listrandom = listrandom.Union(ListKho.Skip(rd1 - 1).Take(1));
                    listrandom.Count();
                    Thread.Sleep(100);
                }
                while (listrandom.Count() < 40);
            }
            grvList.DataSource = listrandom;
            grvList.DataBind();
            //txtLoaiBaiThi.Value = "2";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "showButtonLuu()", true);
        }
    }
    //tạo bài kiểm tra 50 câu
    protected void btnBaiKT1Tiet2_Click(object sender, EventArgs e)
    {
        string _id = lkChapter.Text;
        string[] arrListStr = _id.Split(',');
        var listrandom = from ch in db.tbTracNghiem_Questions
                         join c in db.tbTracNghiem_Chapters on ch.chapter_id equals c.chapter_id
                         join u in db.admin_Users on ch.username_id equals u.username_id
                         where c.chapter_name == "" && ch.hidden == false
                         select new
                         {
                             ch.question_id,
                             ch.question_content,
                             ch.question_type,
                             c.chapter_name,
                             u.username_fullname
                         };
        //duyệt vòng for để lấy số câu hỏi ứng với từng loại câu hỏi (dễ-vừa-khó)
        var list = from ch in db.tbTracNghiem_Questions
                   join c in db.tbTracNghiem_Chapters on ch.chapter_id equals c.chapter_id
                   join u in db.admin_Users on ch.username_id equals u.username_id
                   where c.chapter_name == "" && ch.hidden == false
                   select new
                   {
                       ch.question_id,
                       ch.question_content,
                       ch.question_type,
                       c.chapter_name,
                       u.username_fullname
                   };
        foreach (string item in arrListStr)
        {
            var list1 = from ch in db.tbTracNghiem_Questions
                        join c in db.tbTracNghiem_Chapters on ch.chapter_id equals c.chapter_id
                        join u in db.admin_Users on ch.username_id equals u.username_id
                        where c.chapter_name == item.ToString().Trim() && ch.hidden == false
                        select new
                        {
                            ch.question_id,
                            ch.question_content,
                            ch.question_type,
                            c.chapter_name,
                            u.username_fullname
                        };
            list = list.Union(list1);
        }
        //duyệt trong list tổng để lấy ra 25 câu dễ, 15 câu vừa,10 câu khó cho bộ đề

        if (list.Count() < 50)
        {
            alert.alert_Error(Page, "Bộ câu hỏi không đủ để tạo đề!", "Vui lòng chọn thêm dữ liệu");
        }
        else if (list.Count() == 50)
        {
            grvList.DataSource = list;
            grvList.DataBind();
            //txtLoaiBaiThi.Value = "2";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "showButtonLuu()", true);
        }
        else
        {
            var ListDe = from ld in list
                         where ld.question_type == "Dễ"
                         select ld;
            var ListVua = from lv in list
                          where lv.question_type == "Vừa"
                          select lv;
            var ListKho = from lk in list
                          where lk.question_type == "Khó"
                          select lk;
            if (ListDe.Count() < 25 || ListVua.Count() < 15 || ListKho.Count() < 10)
            {
                alert.alert_Error(Page, "Bộ câu hỏi không đủ để tạo đề!", "Vui lòng chọn thêm dữ liệu");
            }
            else
            {
                Random rnd1 = new Random();
                do
                {
                    int rd1 = rnd1.Next(1, ListDe.Count());
                    listrandom = listrandom.Union(ListDe.Skip(rd1 - 1).Take(1));
                    listrandom.Count();
                    Thread.Sleep(100);
                }
                while (listrandom.Count() < 25);
                do
                {
                    int rd1 = rnd1.Next(1, ListVua.Count());
                    listrandom = listrandom.Union(ListVua.Skip(rd1 - 1).Take(1));
                    listrandom.Count();
                    Thread.Sleep(100);
                }
                while (listrandom.Count() < 40);
                do
                {
                    int rd1 = rnd1.Next(1, ListKho.Count());
                    listrandom = listrandom.Union(ListKho.Skip(rd1 - 1).Take(1));
                    listrandom.Count();
                    Thread.Sleep(100);
                }
                while (listrandom.Count() < 50);
            }
            grvList.DataSource = listrandom;
            grvList.DataBind();
            //txtLoaiBaiThi.Value = "2";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "showButtonLuu()", true);
        }
    }
    //tạo bài thi
    protected void btnBaiKTThi_Click(object sender, EventArgs e)
    {
        string _id = lkChapter.Text;
        string[] arrListStr = _id.Split(',');
        var listrandom = from ch in db.tbTracNghiem_Questions
                         join c in db.tbTracNghiem_Chapters on ch.chapter_id equals c.chapter_id
                         join u in db.admin_Users on ch.username_id equals u.username_id
                         where c.chapter_name == "" && ch.hidden == false
                         select new
                         {
                             ch.question_id,
                             ch.question_content,
                             ch.question_type,
                             c.chapter_name,
                             u.username_fullname
                         };
        //duyệt vòng for để lấy số câu hỏi ứng với từng loại câu hỏi (dễ-vừa-khó)
        var list = from ch in db.tbTracNghiem_Questions
                   join c in db.tbTracNghiem_Chapters on ch.chapter_id equals c.chapter_id
                   join u in db.admin_Users on ch.username_id equals u.username_id
                   where c.chapter_name == "" && ch.hidden == false
                   select new
                   {
                       ch.question_id,
                       ch.question_content,
                       ch.question_type,
                       c.chapter_name,
                       u.username_fullname
                   };
        foreach (string item in arrListStr)
        {
            var list1 = from ch in db.tbTracNghiem_Questions
                        join c in db.tbTracNghiem_Chapters on ch.chapter_id equals c.chapter_id
                        join u in db.admin_Users on ch.username_id equals u.username_id
                        where c.chapter_name == item.ToString().Trim() && ch.hidden == false
                        select new
                        {
                            ch.question_id,
                            ch.question_content,
                            ch.question_type,
                            c.chapter_name,
                            u.username_fullname
                        };
            list = list.Union(list1);
        }
        //duyệt trong list tổng để lấy ra 25 câu dễ, 15 câu vừa,10 câu khó cho bộ đề

        if (list.Count() < 50)
        {
            alert.alert_Error(Page, "Bộ câu hỏi không đủ để tạo đề!", "Vui lòng chọn thêm dữ liệu");
        }
        else if (list.Count() == 50)
        {
            grvList.DataSource = list;
            grvList.DataBind();
            //txtLoaiBaiThi.Value = "3";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "showButtonLuu()", true);
        }
        else
        {
            var ListDe = from ld in list
                         where ld.question_type == "Dễ"
                         select ld;
            var ListVua = from lv in list
                          where lv.question_type == "Vừa"
                          select lv;
            var ListKho = from lk in list
                          where lk.question_type == "Khó"
                          select lk;
            if (ListDe.Count() < 25 || ListVua.Count() < 15 || ListKho.Count() < 10)
            {
                alert.alert_Error(Page, "Bộ câu hỏi không đủ để tạo đề!", "Vui lòng chọn thêm dữ liệu");
            }
            else
            {
                Random rnd1 = new Random();
                do
                {
                    int rd1 = rnd1.Next(1, ListDe.Count());
                    listrandom = listrandom.Union(ListDe.Skip(rd1 - 1).Take(1));
                    listrandom.Count();
                    Thread.Sleep(100);
                }
                while (listrandom.Count() < 25);
                do
                {
                    int rd1 = rnd1.Next(1, ListVua.Count());
                    listrandom = listrandom.Union(ListVua.Skip(rd1 - 1).Take(1));
                    listrandom.Count();
                    Thread.Sleep(100);
                }
                while (listrandom.Count() < 40);
                do
                {
                    int rd1 = rnd1.Next(1, ListKho.Count());
                    listrandom = listrandom.Union(ListKho.Skip(rd1 - 1).Take(1));
                    listrandom.Count();
                    Thread.Sleep(100);
                }
                while (listrandom.Count() < 50);
            }
            grvList.DataSource = listrandom;
            grvList.DataBind();
            // txtLoaiBaiThi.Value = "3";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "showButtonLuu()", true);
        }
    }

    protected void ddlKhoi_SelectedIndexChanged(object sender, EventArgs e)
    {
        var getdataMon = from mhck in db.tbMonHocCuaKhois
                         join m in db.tbMonHocs on mhck.monhoc_id equals m.monhoc_id
                         join gvdm in db.tbGiaoVienDayMons on m.monhoc_id equals gvdm.monhoc_id
                         where mhck.khoi_id == Convert.ToInt32(ddlKhoi.SelectedValue)
                         select m;
        ddlMon.Items.Clear();
        ddlMon.AppendDataBoundItems = true;
        ddlMon.Items.Insert(0, "Chọn môn");
        ddlMon.DataValueField = "monhoc_id";
        ddlMon.DataTextField = "monhoc_name";
        ddlMon.DataSource = getdataMon;
        ddlMon.DataBind();
        ddlMon.Visible = true;
    }

    protected void ddlMon_SelectedIndexChanged(object sender, EventArgs e)
    {
        var getdataChuong = from ch in db.tbTracNghiem_Chapters
                            where ch.monhoc_id == Convert.ToInt32(ddlMon.SelectedValue)
                             && ch.khoi_id == Convert.ToInt32(ddlKhoi.SelectedValue)
                            select ch;
        lkChapter.DataSource = getdataChuong;
        lkChapter.DataBind();
        lkChapter.Visible = true;
    }

    protected void btnLuu_Click(object sender, EventArgs e)
    {

        //lấy thông tin tk đăng nhập
        var getUser = (from u in db.admin_Users
                       where u.username_username == Request.Cookies["UserName"].Value
                       select u).SingleOrDefault();
        try
        {
            var list = Session["CauHoi"] as IEnumerable<dynamic>;
            //lưu vào databasse
            tbTracNghiem_Test insert = new tbTracNghiem_Test();
            //insert.question_id = String.Join(",", selectedKey);
            insert.test_createdate = DateTime.Now;
            insert.username_id = getUser.username_id;
            insert.hidden = false;
            insert.khoi_id = Convert.ToInt32(ddlKhoi.SelectedValue);
            insert.monhoc_id = Convert.ToInt32(ddlMon.SelectedValue);
          
            db.tbTracNghiem_Tests.InsertOnSubmit(insert);
            db.SubmitChanges();
            foreach (var item in list)
            {
                tbTracNghiem_TestDetail ins = new tbTracNghiem_TestDetail();
                ins.test_id = insert.test_id;
                ins.question_id = Convert.ToInt32(item.question_id);
                ins.hidden = false;
                db.tbTracNghiem_TestDetails.InsertOnSubmit(ins);
                db.SubmitChanges();
            }
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Tạo bài kiểm tra thành công!','','success')", true);
        }
        catch (Exception) { }
    }

    protected void btnTaoDe_Click(object sender, EventArgs e)
    {
       
      if (txtLoai.Value == "")
        {
            alert.alert_Warning(Page, "Vui lòng nhập tên bài kiểm tra", "");
        }
        else
        {
            string _id = lkChapter.Text;
            string[] arrListStr = _id.Split(',');
            var listrandom = from ch in db.tbTracNghiem_Questions
                             join c in db.tbTracNghiem_Chapters on ch.chapter_id equals c.chapter_id
                             join u in db.admin_Users on ch.username_id equals u.username_id
                             where c.chapter_name == "" && ch.hidden == false
                             select new
                             {
                                 ch.question_id,
                                 ch.question_content,
                                 ch.question_type,
                                 c.chapter_name,
                                 u.username_fullname
                             };
            //duyệt vòng for để lấy số câu hỏi ứng với từng loại câu hỏi (dễ-vừa-khó)
            var list = from ch in db.tbTracNghiem_Questions
                       join c in db.tbTracNghiem_Chapters on ch.chapter_id equals c.chapter_id
                       join u in db.admin_Users on ch.username_id equals u.username_id
                       where c.chapter_name == "" && ch.hidden == false
                       select new
                       {
                           ch.question_id,
                           ch.question_content,
                           ch.question_type,
                           c.chapter_name,
                           u.username_fullname
                       };
            foreach (string item in arrListStr)
            {
                var list1 = from ch in db.tbTracNghiem_Questions
                            join c in db.tbTracNghiem_Chapters on ch.chapter_id equals c.chapter_id
                            join u in db.admin_Users on ch.username_id equals u.username_id
                            where c.chapter_name == item.ToString().Trim() && ch.hidden == false
                            select new
                            {
                                ch.question_id,
                                ch.question_content,
                                ch.question_type,
                                c.chapter_name,
                                u.username_fullname
                            };
                list = list.Union(list1);
            }
            int socauhoi = Convert.ToInt32(txtSoCauHoi.Value);
            float a = socauhoi / 2;
            float b = socauhoi * 3 / 10;
            int socaude = Convert.ToInt32(Math.Round(a));
            int socauvua = Convert.ToInt32(Math.Round(b));
            int socaukho = socauhoi - socaude - socauvua;
            //duyệt trong list tổng để lấy ra 50% câu dễ, 30% câu vừa và 20% câu khó cho bộ đề
            if (list.Count() < socauhoi)
            {
                alert.alert_Error(Page, "Bộ câu hỏi không đủ để tạo đề!", "Vui lòng chọn thêm dữ liệu");
            }
            else if (list.Count() == socauhoi)
            {
                grvList.DataSource = list;
                grvList.DataBind();
                dtCauHoi = (DataTable)list;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "showButtonLuu()", true);
            }
            else
            {
                var ListDe = from ld in list
                             where ld.question_type == "Dễ"
                             select ld;
                var ListVua = from lv in list
                              where lv.question_type == "Vừa"
                              select lv;
                var ListKho = from lk in list
                              where lk.question_type == "Khó"
                              select lk;
                if (ListDe.Count() < socaude || ListVua.Count() < socauvua || ListKho.Count() < socaukho)
                {
                    alert.alert_Error(Page, "Bộ câu hỏi không đủ để tạo đề!", "Vui lòng chọn thêm dữ liệu");
                }
                else
                {
                    Random rnd1 = new Random();
                    do
                    {
                        int rd1 = rnd1.Next(1, ListDe.Count());
                        listrandom = listrandom.Union(ListDe.Skip(rd1 - 1).Take(1));
                        listrandom.Count();
                        Thread.Sleep(100);
                    }
                    while (listrandom.Count() < socaude);
                    do
                    {
                        int rd1 = rnd1.Next(1, ListVua.Count());
                        listrandom = listrandom.Union(ListVua.Skip(rd1 - 1).Take(1));
                        listrandom.Count();
                        Thread.Sleep(100);
                    }
                    while (listrandom.Count() < (socaude + socauvua));
                    do
                    {
                        int rd1 = rnd1.Next(1, ListKho.Count());
                        listrandom = listrandom.Union(ListKho.Skip(rd1 - 1).Take(1));
                        listrandom.Count();
                        Thread.Sleep(100);
                    }
                    while (listrandom.Count() < socauhoi);
                }
                grvList.DataSource = listrandom;
                grvList.DataBind();
                Session["CauHoi"] = listrandom;
                if (grvList.VisibleRowCount.ToString() != "0")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "displayButton()", true);
                }
            }
        }
    }
}
