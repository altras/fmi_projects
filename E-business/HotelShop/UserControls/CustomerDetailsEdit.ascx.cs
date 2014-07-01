using System;
using System.Web.UI.WebControls;

public partial class UserControls_CustomerDetailsEdit : System.Web.UI.UserControl
{
  public bool Editable
  {
    get
    {
      if (ViewState["editable"] != null)
      {
        return (bool)ViewState["editable"];
      }
      else
      {
        return true;
      }
    }
    set
    {
      ViewState["editable"] = value;
    }
  }

  protected override void OnPreRender(EventArgs e)
  {
    // Find and set edit button visibility
    Button EditButton =
     FormView1.FindControl("EditButton") as Button;
    if (EditButton != null)
    {
      EditButton.Visible = Editable;
    }
  }
}
