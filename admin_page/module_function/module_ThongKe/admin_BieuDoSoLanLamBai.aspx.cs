using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_ThongKe_admin_BieuDoSoLanLamBai : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private static int _id;
    //ngày, tháng, năm hiện tại
    private static int month = DateTime.Now.Month;
    private static int year = DateTime.Now.Year;
    private static int dayinmonth = DateTime.DaysInMonth(year, month);
    //t2 trong tuần hiện tại
    DateTime monday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
    //t7 trong tuần hiện tại
    DateTime saturday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Saturday);

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            //_id = 1;
            _id = Convert.ToInt32(RouteData.Values["lop_id"]);
            div_TuNgayToiNgay.Visible = false;
        }
    }

    public void LoadThongKe(string option, DateTime tungay, DateTime denngay)
    {
        var dates = new List<DateTime>();
        
        //list các học sinh trong lớp có làm bài test
        List<tbTracNghiem_ResultTest> list_HocSinh = db.tbTracNghiem_ResultTests.Where(test => test.lop_id == _id).GroupBy(test => test.hocsinh_code).Select(g => g.First()).ToList();
        string[] list_SoLan = new string[list_HocSinh.Count + 1];
        string[] list_TenHocSinh = new string[list_HocSinh.Count + 1];
   
        string arr_day = "";
        string arr_solanlambai = "";
        string arr_tenhocsinh = "";
        string arr_hocsinhcode = "";

        if (option == "Trong tháng")
        {
            string[] list_Day = new string[dayinmonth + 1];
            int n = 1;
         

            //Lấy tất cả các ngày trong tháng hiện tại đổ dữ liệu lên trục Y
            do
            {
                //định dạng ngày thành 'dd/MM' lưu trong mảng list_Day[]
                list_Day[n] = "'" + n + "/" + month + "'";

                //dùng chuỗi arr_day lưu các giá trị ngày để xuất lên chart "'dd/MM', 'dd/MM', ..."
                if (n == dayinmonth)
                {
                    arr_day = arr_day + list_Day[n];
                }
                else
                {
                    arr_day = arr_day + list_Day[n] + ", ";
                }
                n++;
            }
            while (n <= dayinmonth);

            for (int j = 0; j <= list_HocSinh.Count() - 1; j++)
            {
                for (int i = 1; i <= dayinmonth; i++)
                {
                    //lấy được số lần làm bài của học sinh theo lớp mỗi ngày trong tháng đó
                    int count = (from kq in db.tbTracNghiem_ResultTests
                                 join hs in db.tbHocSinhs on kq.hocsinh_code equals hs.hocsinh_code
                                 where kq.lop_id == _id
                                 && hs.hocsinh_code == list_HocSinh[j].hocsinh_code
                                 && kq.resulttest_datetime.Value.Day == i
                                 && kq.resulttest_datetime.Value.Month == month
                                 && kq.resulttest_datetime.Value.Year == year
                                 select kq).Count();
                    if (count != 0)
                    {
                        list_SoLan[j] = list_SoLan[j] + count.ToString() + ",";
                    }
                    else
                    {
                        list_SoLan[j] = list_SoLan[j] + "0,";
                    }
                }
            }      
        }

        else if (option == "Trong tuần")
        {
            string[] list_Day = new string[7];
            int n = 0;

            //lấy được tất cả các ngày từ thứ 2 -> thứ 7 theo định dạng (dd/MM/yyyy)
            for (var dt = monday; dt <= saturday; dt = dt.AddDays(1))
            {
                dates.Add(dt);
            }

            do
            {
                //thay đổi định dạng ngày thành 'dd/MM' và lưu trong mảng list_Day
                list_Day[n] = "'" + dates[n].Day + "/" + dates[n].Month + "'";

                //dùng chuỗi arr_day lưu các giá trị ngày để xuất lên chart "'dd/MM', 'dd/MM', ..."
                if (n == 5)
                {
                    arr_day = arr_day + list_Day[n];
                }
                else
                {
                    arr_day = arr_day + list_Day[n] + ", ";
                }
                n++;

            } while (n <= 5);

            for(int j = 0; j <= list_HocSinh.Count - 1; j++)
            {
                for (int i = 0; i <= 5; i++)
                {
                    //đếm số lần làm bài của học sinh trong các ngày trong tuần
                    int count = (from kq in db.tbTracNghiem_ResultTests
                                 join hs in db.tbHocSinhs on kq.hocsinh_code equals hs.hocsinh_code
                                 where kq.lop_id == _id
                                 && kq.hocsinh_code == list_HocSinh[j].hocsinh_code
                                 && kq.resulttest_datetime.Value.Day == dates[i].Day
                                 && kq.resulttest_datetime.Value.Month == dates[i].Month
                                 && kq.resulttest_datetime.Value.Year == dates[i].Year
                                 select kq).Count();
                    if (count != 0)
                    {
                        list_SoLan[j] = list_SoLan[j] + count.ToString() + ",";
                    }
                    else
                    {
                        list_SoLan[j] = list_SoLan[j] + "0,";
                    }
                }
            }
        }

        else if (option == "Theo ngày")
        {
            int days = (int)((denngay - tungay).TotalDays);
            string[] list_Day = new string[days + 1];
            int n = 0;

            //lấy được tất cả các ngày từ tungay -> denngay theo định dạng (dd/MM/yyyy) thêm vào list dates[]
            for (var dt = tungay; dt <= denngay; dt = dt.AddDays(1))
            {
                dates.Add(dt);
            }

            do
            {
                //dùng chuỗi arr_day lưu các giá trị ngày để xuất lên chart "'dd/MM', 'dd/MM', ..."
                if (n == days)
                {
                    arr_day = arr_day + "'" + dates[n].Day + "/" + dates[n].Month + "'";
                }
                else
                {
                    arr_day = arr_day + "'" + dates[n].Day + "/" + dates[n].Month + "'" + ", ";
                }
                n++;
            } while (n <= days);

            for(int j = 0; j <= list_HocSinh.Count - 1; j++)
            {
                for (int i = 0; i <= days; i++)
                {
                    //đếm số lần làm bài của các học sinh trong các ngày
                    int count = (from kq in db.tbTracNghiem_ResultTests
                                 join hs in db.tbHocSinhs on kq.hocsinh_code equals hs.hocsinh_code
                                 where kq.lop_id == _id
                                 && kq.hocsinh_code == list_HocSinh[j].hocsinh_code
                                 && kq.resulttest_datetime.Value.Day == dates[i].Day
                                 && kq.resulttest_datetime.Value.Month == dates[i].Month
                                 && kq.resulttest_datetime.Value.Year == dates[i].Year
                                 select kq).Count();
                    if (count != 0)
                    {
                        list_SoLan[j] = list_SoLan[j] + count.ToString() + ",";
                    }
                    else
                    {
                        list_SoLan[j] = list_SoLan[j] + "0,";
                    }
                }
            }
        }

        //dùng chung
        //xử lý các chuỗi
        for (int i = 0; i <= list_HocSinh.Count - 1; i++)
        {
            if (i == list_HocSinh.Count - 1)
            {
                //xử lý thành chuỗi của số lần làm bài của các học sinh "*[...]*, *[...]*, ..."
                arr_solanlambai = arr_solanlambai + "*[" + list_SoLan[i].TrimEnd(',') + "]*";

                //get tên học sinh vào chuỗi arr_tenhocsinh
                list_TenHocSinh[i] = (from hs in db.tbHocSinhs where hs.hocsinh_code == list_HocSinh[i].hocsinh_code select hs).First().hocsinh_name;
                arr_tenhocsinh = arr_tenhocsinh + "'" + list_TenHocSinh[i] + "'";

                //get mã học sinh vào chuỗi arr_hocsinhcode 
                arr_hocsinhcode = arr_hocsinhcode + "'" + list_HocSinh[i].hocsinh_code + "'";

            }
            else
            {
                arr_solanlambai = arr_solanlambai + "*[" + list_SoLan[i].TrimEnd(',') + "]*, ";
                list_TenHocSinh[i] = (from hs in db.tbHocSinhs where hs.hocsinh_code == list_HocSinh[i].hocsinh_code select hs).First().hocsinh_name;
                arr_tenhocsinh = arr_tenhocsinh + "'" + list_TenHocSinh[i] + "', ";
                arr_hocsinhcode = arr_hocsinhcode + "'" + list_HocSinh[i].hocsinh_code + "', ";
            }
        }
        txtSoLanLamBai.Value = arr_solanlambai;
        txtTenHocSinh.Value = arr_tenhocsinh.Replace("\r\n", "");
        txtNgay.Value = arr_day;
        txtHocSinhCode.Value = arr_hocsinhcode;
    }
    public void ResetData()
    {
        txtNgay.Value = "";
        txtSoLanLamBai.Value = "";
        dteTuNgay.Value = "";
        dteDenNgay.Value = "";
    }
    protected void ddlThongKe_SelectedIndexChanged(object sender, EventArgs e)
    {
        string option = ddlThongKe.Text;
        if(option == "3")
        {
            ResetData();  
            div_TuNgayToiNgay.Visible = true;
        }
        else
        {
            div_TuNgayToiNgay.Visible = false;
            if (option == "1")
            {
                LoadThongKe("Trong tuần", Convert.ToDateTime(null), Convert.ToDateTime(null));
            }
            else if (option == "2")
            {
                LoadThongKe("Trong tháng", Convert.ToDateTime(null), Convert.ToDateTime(null));
            }
            else
            {
                ResetData();
            }
        }
    }

    protected void btnChon_Click(object sender, EventArgs e)
    {
        div_TuNgayToiNgay.Visible = true;
        if(dteTuNgay.Value == "" || dteDenNgay.Value == "")
        {
            ResetData();
            alert.alert_Warning(Page, "Chưa chọn ngày!", "");
        }
        //Bắt lỗi Từ ngày >= Đến ngày
        else if (Convert.ToDateTime(dteTuNgay.Value) >= Convert.ToDateTime(dteDenNgay.Value))
        {
            ResetData();
            alert.alert_Error(Page, "Dữ liệu ngày không hợp lệ !", "");
        }
        else
        {
            LoadThongKe("Theo ngày", Convert.ToDateTime(dteTuNgay.Value), Convert.ToDateTime(dteDenNgay.Value));
        }
    }
}