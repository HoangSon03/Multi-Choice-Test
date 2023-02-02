using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_GetLink
/// </summary>
public class cls_GetLink
{
    public cls_GetLink()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string getLink(string tittle)
    {
        string link = cls_ToAscii.ToAscii(tittle.ToLower());
        try
        {
            return link;
        }
        catch
        {
            return null;
        }
    }
}