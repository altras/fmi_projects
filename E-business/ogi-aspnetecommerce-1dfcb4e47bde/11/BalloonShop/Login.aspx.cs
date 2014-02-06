using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class Login : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    // get controls
    TextBox usernameTextBox = (TextBox)loginControl.FindControl("UserName");

    // set focus on the username textbox when the page loads
    usernameTextBox.Focus();

    // set the page title
    this.Title = BalloonShopConfiguration.SiteName + ": Login";
  }
}
