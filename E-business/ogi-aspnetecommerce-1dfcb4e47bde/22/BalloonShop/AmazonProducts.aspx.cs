using System;

public partial class AmazonProducts : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!IsPostBack)
    {
      // fill the DataList with Amazon products. Calling any of
      // GetAmazonDataWithRest or GetAmazonDataWithSoap should return
      // the same results
      list.DataSource = AmazonAccess.GetAmazonDataWithRest();
      list.DataBind();
    }
  }
}
