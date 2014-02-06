using System;
using System.Web;
using System.Text.RegularExpressions;

/// <summary>
/// Link factory class
/// </summary>
public class Link
{
  // regular expression that removes characters that aren't a-z, 0-9, dash, 
  // underscore or space
  private static Regex purifyUrlRegex = new Regex("[^-a-zA-Z0-9_ ]", RegexOptions.Compiled);

  // regular expression that changes dashes, underscores and spaces to dashes
  private static Regex dashesRegex = new Regex("[-_ ]+", RegexOptions.Compiled);

  // prepares a string to be included in an URL
  private static string PrepareUrlText(string urlText)
  {
    // remove all characters that aren't a-z, 0-9, dash, underscore or space
    urlText = purifyUrlRegex.Replace(urlText, "");

    // remove all leading and trailing spaces
    urlText = urlText.Trim();

    // change all dashes, underscores and spaces to dashes
    urlText = dashesRegex.Replace(urlText, "-");

    // return the modified string    
    return urlText;
  }

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

  // 301 redirects to correct product URL if not already there
  public static void CheckProductUrl(string productId)
  {
    // get requested URL
    HttpContext context = HttpContext.Current;
    string requestedUrl = context.Request.RawUrl;

    // get last part of proper URL
    string properUrl = Link.ToProduct(productId);
    string properUrlTrunc = properUrl.Substring(Math.Abs(properUrl.Length - requestedUrl.Length));

    // 301 redirect to the proper URL if necessary
    if (requestedUrl != properUrlTrunc)
    {
      context.Response.Status = "301 Moved Permanently";
      context.Response.AddHeader("Location", properUrl);
    }
  }

  public static string ToDepartment(string departmentId, string page)
  {
    // prepare department URL name
    DepartmentDetails d = CatalogAccess.GetDepartmentDetails(departmentId);
    string deptUrlName = PrepareUrlText(d.Name);

    // build department URL
    if (page == "1")
      return BuildAbsolute(String.Format("{0}--d{1}", deptUrlName, departmentId));
    else
      return BuildAbsolute(String.Format("{0}--d{1}-page{2}", deptUrlName, departmentId, page));
  }

  // Generate a department URL for the first page
  public static string ToDepartment(string departmentId)
  {
    return ToDepartment(departmentId, "1");
  }

  public static string ToCategory(string departmentId, string categoryId, string page)
  {
    // prepare department and category URL names
    DepartmentDetails d = CatalogAccess.GetDepartmentDetails(departmentId);
    string deptUrlName = PrepareUrlText(d.Name);
    CategoryDetails c = CatalogAccess.GetCategoryDetails(categoryId);
    string catUrlName = PrepareUrlText(c.Name);

    // build category URL
    if (page == "1")
      return BuildAbsolute(String.Format("{0}--{2}--d{1}-c{3}", deptUrlName, departmentId, catUrlName, categoryId));
    else
      return BuildAbsolute(String.Format("{0}--{2}--d{1}-c{3}-page{4}", deptUrlName, departmentId, catUrlName, categoryId, page));
  }

  public static string ToCategory(string departmentId, string categoryId)
  {
    return ToCategory(departmentId, categoryId, "1");
  }

    public static string ToFrontpage(string page)
    {
        // build front page URL
        if (page == "1")
            return BuildAbsolute("");
        else
            return BuildAbsolute(String.Format("front--page{0}", page));
    }

    public static string ToFrontpage()
    {
        return ToFrontpage("1");
    }
    
  public static string ToProduct(string productId)
  {
    // prepare product URL name
    ProductDetails p = CatalogAccess.GetProductDetails(productId.ToString());
    string prodUrlName = PrepareUrlText(p.Name);

    // build product URL
    return BuildAbsolute(String.Format("{0}--p{1}", prodUrlName, productId));
  }

  public static string ToProductImage(string fileName)
  {
    // build product URL
    return BuildAbsolute("/ProductImages/" + fileName);
  }

  public static string ToSearch(string searchString, bool allWords, string page)
  {
    if (page == "1")
      return BuildAbsolute(
        String.Format("/Search.aspx?Search={0}&AllWords={1}",
          searchString, allWords.ToString()));
    else
      return BuildAbsolute(
        String.Format("/Search.aspx?Search={0}&AllWords={1}&Page={2}",
          searchString, allWords.ToString(), page));
  }

  public static string ToPayPalViewCart()
  {
    return HttpUtility.UrlPathEncode(
      String.Format("{0}&business={1}&return={2}&cancel_return={3}&display=1",
        BalloonShopConfiguration.PaypalUrl,
        BalloonShopConfiguration.PaypalEmail,
        BalloonShopConfiguration.PaypalReturnUrl,
        BalloonShopConfiguration.PaypalCancelUrl));
  }

  public static string ToPayPalAddItem(string productUrl, string productName, decimal productPrice, string productOptions)
  {
    return HttpUtility.UrlPathEncode(
      String.Format("{0}&business={1}&return={2}&cancel_return={3}&shopping_url={4}&item_name={5}&amount={6:0.00}&currency={7}&on0=Options&os0={8}&add=1",
          BalloonShopConfiguration.PaypalUrl,
          BalloonShopConfiguration.PaypalEmail,
          BalloonShopConfiguration.PaypalReturnUrl,
          BalloonShopConfiguration.PaypalCancelUrl,
          productUrl,
          productName,
          productPrice,
          BalloonShopConfiguration.PaypalCurrency,
          productOptions));
  }

  public static string ToPayPalCheckout(string orderName, decimal orderAmount)
  {
    return HttpUtility.UrlPathEncode(
        String.Format("{0}/business={1}&item_name={2}&amount={3:0.00}&currency={4}&return={5}&cancel_return={6}",
            BalloonShopConfiguration.PaypalUrl,
            BalloonShopConfiguration.PaypalEmail,
            orderName,
            orderAmount,
            BalloonShopConfiguration.PaypalCurrency,
            BalloonShopConfiguration.PaypalReturnUrl,
            BalloonShopConfiguration.PaypalCancelUrl));
  }
}
