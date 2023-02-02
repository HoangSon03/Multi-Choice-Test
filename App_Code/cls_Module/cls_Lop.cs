using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_News
/// </summary>
public class cls_Lop
{
    dbcsdlDataContext db = new dbcsdlDataContext();
 
    public cls_Lop()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Linq_Them(string lop_name )
    {
       
        tbLop insert = new tbLop();
        insert.lop_name = lop_name;
        insert.hidden = false;
        db.tbLops.InsertOnSubmit(insert);
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
    public bool Linq_Sua(int lop_id, string lop_name  )
    { 
        tbLop update = db.tbLops.Where(x => x.lop_id == lop_id).FirstOrDefault();
        update.lop_name = lop_name;
          
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
    public bool Linq_Xoa(int lop_id)
    {
        tbLop delete = db.tbLops.Where(x => x.lop_id == lop_id).FirstOrDefault();
        delete.hidden=true;
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