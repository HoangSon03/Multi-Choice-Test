using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_NewsCate
/// </summary>
public class cls_MonHoc
{
    dbcsdlDataContext db = new dbcsdlDataContext();
	public cls_MonHoc()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public bool Linq_Them( string monhoc_name)
    {
        tbMonHoc insert = new tbMonHoc();
        insert.monhoc_name = monhoc_name;
        db.tbMonHocs.InsertOnSubmit(insert);
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
    public bool Linq_Sua(int monhoc_id, string monhoc_name)
    {

        tbMonHoc update = db.tbMonHocs.Where(x => x.monhoc_id == monhoc_id).FirstOrDefault();
        update.monhoc_name = monhoc_name;
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
    public bool Linq_Xoa(int contact_id)
    {
        tbMonHoc delete = db.tbMonHocs.Where(x => x.monhoc_id == contact_id).FirstOrDefault();
        db.tbMonHocs.DeleteOnSubmit(delete);
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