using System;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Register : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    // Set the title of the page
    this.Title = BalloonShopConfiguration.SiteName +
                " : Register";
  }

  protected void CreateUserWizard1_CreatedUser(object sender,
  EventArgs e)
  {
    Roles.AddUserToRole((sender as CreateUserWizard).UserName,
    "Customers");
  }
}
