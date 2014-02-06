using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_UserInfo : System.Web.UI.UserControl
{
  protected void Page_Load(object sender, EventArgs e)
  {

  }

  // we don't want to display the cart summary in the shopping cart page
  protected void Page_Init(object sender, EventArgs e)
  {
    // get the current page
    string page = Request.AppRelativeCurrentExecutionFilePath;
    // if we're in the shopping cart, don't display the cart summary
    if (String.Compare(page, "~/ShoppingCart.aspx", true) == 0)
      this.Visible = false;
    else
      this.Visible = true;
  }
}
