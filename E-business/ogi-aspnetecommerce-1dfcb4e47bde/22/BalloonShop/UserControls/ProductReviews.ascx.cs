using System;
using System.Web;
using System.Data;
using System.Web.Security;

public partial class UserControls_ProductReviews : System.Web.UI.UserControl
{
  protected void Page_Load(object sender, EventArgs e)
  {
    // Retrieve ProductID from the query string
    string productId = Request.QueryString["ProductID"];
    // display product recommendations
    DataTable table = CatalogAccess.GetProductReviews(productId);
    if (table.Rows.Count > 0)
    {
      list.ShowHeader = true;
      list.DataSource = table;
      list.DataBind();
    }
    // show or hide the review panel
    addReviewPanel.Visible = 
      (HttpContext.Current.User != null
        && HttpContext.Current.User.Identity.IsAuthenticated);
  }

  protected void addReviewButton_Click(object sender, EventArgs e)
  {
    string customerId = Membership.GetUser(
       HttpContext.Current.User.Identity.Name)
       .ProviderUserKey.ToString();
    string productId = Request.QueryString["ProductID"];
    CatalogAccess.AddReview(customerId, productId, reviewTextBox.Text);
    Response.Redirect(HttpContext.Current.Request.RawUrl);
  }
}
