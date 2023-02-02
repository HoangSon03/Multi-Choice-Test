using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Transactions;

/// <summary>
/// Summary description for cls_GameTiengViet
/// </summary>
public class cls_GameTiengViet1
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_GameTiengViet1()
    {
    }
    public void SaveData(string hocsinh_code, string luyentap_name, string test_link, string diem)
    {
        //var getData = (from hs in db.tbHocSinhs
        //               join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
        //               join lop in db.tbLops on hstl.lop_id equals lop.lop_id
        //               where hs.hocsinh_code == hocsinh_code
        //               && hstl.namhoc_id == 1
        //               select new
        //               {
        //                   hs.hocsinh_code,
        //                   lop.lop_id,
        //                   lop.khoi_id
        //               }).FirstOrDefault();

        ////ktra xem đã có sẵn bài luyện tập hay chưa
        //var exist_blt = (from blt in db.tbTracNghiem_BaiLuyenTaps
        //                 where blt.luyentap_name == luyentap_name
        //                 select blt).FirstOrDefault();

        //if (exist_blt != null)
        //{
        //    using (var transaction = new TransactionScope())
        //    {
        //        try
        //        {
        //            //tìm bài test có bài luyện tập tương ứng
        //            var test = (from t in db.tbTracNghiem_Tests
        //                        where t.luyentap_id == exist_blt.luyentap_id
        //                        select t).FirstOrDefault();


        //            //thêm kết quả làm bài
        //            tbTracNghiem_ResultTest rt = new tbTracNghiem_ResultTest();
        //            rt.lop_id = getData.lop_id;
        //            rt.hocsinh_code = getData.hocsinh_code;
        //            rt.resulttest_datetime = DateTime.Now;
        //            rt.resulttest_result = diem;
        //            rt.result_type = 2;
        //            rt.test_id = test.test_id;
        //            // rt.result_thoigianlambai = ;
        //            db.tbTracNghiem_ResultTests.InsertOnSubmit(rt);
        //            db.SubmitChanges();
        //            transaction.Complete();
        //        }
        //        catch(Exception)
        //        {; }
        //    }

        //}
        //else
        //{
        //    using (var transaction = new TransactionScope())
        //    {
        //        try
        //        {
        //            //thêm bài luyện tập
        //            tbTracNghiem_BaiLuyenTap blt = new tbTracNghiem_BaiLuyenTap();
        //            blt.luyentap_name = luyentap_name;
        //            blt.username_id = 51; // id tkhoan a đức
        //            blt.luyentap_status = 1;
        //            db.tbTracNghiem_BaiLuyenTaps.InsertOnSubmit(blt);
        //            db.SubmitChanges();

        //            //thêm test
        //            tbTracNghiem_Test test = new tbTracNghiem_Test();
        //            test.khoi_id = 1; //khối 1 id là 1
        //            test.monhoc_id = 64;//môn tiếng việt 1 id là 64
        //            test.test_createdate = DateTime.Now;
        //            test.username_id = 51;
        //            test.luyentap_id = blt.luyentap_id;
        //            test.test_link = test_link;
        //            db.tbTracNghiem_Tests.InsertOnSubmit(test);
        //            db.SubmitChanges();

        //            //thêm kết quả làm bài
        //            tbTracNghiem_ResultTest rt = new tbTracNghiem_ResultTest();
        //            rt.lop_id = getData.lop_id;
        //            rt.hocsinh_code = getData.hocsinh_code;
        //            rt.resulttest_datetime = DateTime.Now;
        //            rt.resulttest_result = diem;
        //            rt.result_type = 2;
        //            rt.test_id = test.test_id;
        //            // rt.result_thoigianlambai = ; //in progress
        //            db.tbTracNghiem_ResultTests.InsertOnSubmit(rt);
        //            db.SubmitChanges();
        //            transaction.Complete();
        //        }
        //        catch(Exception)
        //        {; }
        //    }    
              
        //}
    }
}