<%@ WebHandler Language="C#" Class="DownloadHandler" %>
using System;
using System.Web;

public class DownloadHandler : IHttpHandler 
{    
    public void ProcessRequest (HttpContext context) 
    {
        string file = "";
        
        // get the file name from the querystring
        if (context.Request.QueryString["ImageName"] != null)
        {
            file = context.Request.QueryString["ImageName"].ToString();
        }
        
        string filename = context.Server.MapPath("~/uploadimages/thuvienanh/" + file);
        System.IO.FileInfo fileInfo = new System.IO.FileInfo(filename);

        try
        {
            if (fileInfo.Exists)
            {
                context.Response.Clear();
                context.Response.AddHeader("Content-Disposition", "attachment;filename=\"" + fileInfo.Name + "\"");
                context.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                context.Response.ContentType = "application/octet-stream";
                context.Response.TransmitFile(fileInfo.FullName);
                context.Response.Flush();
            }
            else
            {
                throw new Exception("File not found");
            }
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(ex.Message);
        }
        finally
        {
            context.Response.End();
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
}