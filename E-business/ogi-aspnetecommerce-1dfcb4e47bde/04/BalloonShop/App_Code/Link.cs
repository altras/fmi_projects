using System;
using System.Web;

/// <summary>
/// Link factory class
/// </summary>
public class Link
{
    // Builds an absolute URL
    private static string BuildAbsolute(string relativeUri)
    {
        // get current uri
        Uri uri = HttpContext.Current.Request.Url;
        // build absolute path
        string app = HttpContext.Current.Request.ApplicationPath;
        if (!app.EndsWith("/")) app += "/";
        relativeUri = relativeUri.TrimStart('/');
        // return the absolute path
        return HttpUtility.UrlPathEncode(
          String.Format("http://{0}:{1}{2}{3}",
          uri.Host, uri.Port, app, relativeUri));
    }

    // Generate a department URL
    public static string ToDepartment(string departmentId, string page)
    {
        if (page == "1")
            return BuildAbsolute(String.Format("Catalog.aspx?DepartmentID={0}", departmentId));
        else
            return BuildAbsolute(String.Format("Catalog.aspx?DepartmentID={0}&Page={1}", departmentId, page));
    }

    // Generate a department URL for the first page
    public static string ToDepartment(string departmentId)
    {
        return ToDepartment(departmentId, "1");
    }
}
