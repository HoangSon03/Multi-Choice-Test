using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_NewsCate
/// </summary>
public class cls_DacTa
{
    dbcsdlDataContext db = new dbcsdlDataContext();
	public cls_DacTa()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public bool Linq_Them( string noidung, int username,int khoi, int mon, int chude, int bai, string loai)
    {
        tbTracNghiem_DacTa insert = new tbTracNghiem_DacTa();
        insert.dacta_content = noidung;
        insert.username_id = username;
        insert.khoi_id = khoi;
        insert.mon_id = mon;
        insert.chapter_id = chude;
        insert.lession_id = bai;
        insert.dacta_loai = loai;
        db.tbTracNghiem_DacTas.InsertOnSubmit(insert);
        try
        {
            db.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public bool Linq_Sua(int _id, string noidung, int username, int khoi, int mon, int chude, int bai, string loai)
    {

        tbTracNghiem_DacTa update = db.tbTracNghiem_DacTas.Where(x => x.dacta_id == _id).FirstOrDefault();
        update.dacta_content = noidung;
        update.username_id = username;
        update.khoi_id = khoi;
        update.mon_id = mon;
        update.chapter_id = chude;
        update.lession_id = bai;
        update.dacta_loai = loai;
        try
        {
            db.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public bool Linq_Xoa(int _id)
    {
        tbTracNghiem_DacTa delete = db.tbTracNghiem_DacTas.Where(x => x.dacta_id == _id).FirstOrDefault();
        db.tbTracNghiem_DacTas.DeleteOnSubmit(delete);
        try
        {
            db.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
}