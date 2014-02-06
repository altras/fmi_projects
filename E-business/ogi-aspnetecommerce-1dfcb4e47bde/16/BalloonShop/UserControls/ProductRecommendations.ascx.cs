using System;
using System.Data;

public partial class UserControls_ProductRecommendations : System.Web.UI.UserControl
{
  public void LoadProductRecommendations(string productId)
  {
    // display product recommendations
    DataTable table = CatalogAccess.GetRecommendations(productId);
    if (table.Rows.Count > 0)
    {
      list.ShowHeader = true;
      list.DataSource = table;
      list.DataBind();   
    }
  }

  public void LoadCartRecommendations()
  {
    // display product recommendations
    DataTable table = ShoppingCartAccess.GetRecommendations();
    if (table.Rows.Count > 0)
    {
      list.ShowHeader = true;
      list.DataSource = table;
      list.DataBind();      
    }
  }
} 