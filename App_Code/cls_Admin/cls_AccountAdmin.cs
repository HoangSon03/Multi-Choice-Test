using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_NewsCate
/// </summary>
public class cls_AccountAdmin
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_AccountAdmin()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public bool Linq_Them(string username, string pass, string fullnanme, string phone, string email)
    {
        admin_User insert = new admin_User();
        insert.username_username = username;
        insert.username_password = pass;
        insert.username_fullname = fullnanme;
        insert.username_phone = phone;
        insert.username_email = email;
        insert.groupuser_id = 3;
        insert.username_active = true;
        db.admin_Users.InsertOnSubmit(insert);
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
    public bool Linq_Sua(int account_id, string username, string pass, string fullnanme, string phone, string email)
    {
        admin_User update = db.admin_Users.Where(x => x.username_id == account_id).FirstOrDefault();
        update.username_username = username;
        update.username_password = pass;
        update.username_fullname = fullnanme;
        update.username_phone = phone;
        update.username_email = email;
        update.username_active = true;
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
    public bool Linq_Xoa(int account_id)
    {
        admin_User delete = db.admin_Users.Where(x => x.username_id == account_id).FirstOrDefault();
        db.admin_Users.DeleteOnSubmit(delete);
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