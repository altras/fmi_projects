using System;
using System.Data;

public partial class Checkout : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!IsPostBack)
      PopulateControls();
  }

  // fill controls with data
  private void PopulateControls()
  {
    // get the items in the shopping cart
    DataTable dt = ShoppingCartAccess.GetItems();
    // populate the list with the shopping cart contents
    grid.DataSource = dt;
    grid.DataBind();
    grid.Visible = true;
    // display the total amount
    decimal amount = ShoppingCartAccess.GetTotalAmount();
    totalAmountLabel.Text = String.Format("{0:c}", amount);

    // check customer details
    bool addressOK = true;
    bool cardOK = true;
    if (Profile.Address1 + Profile.Address2 == ""
        || Profile.ShippingRegion == ""
        || Profile.ShippingRegion == "Please Select"
        || Profile.Country == "")
    {
      addressOK = false;
    }
    if (Profile.CreditCard == "")
    {
      cardOK = false;
    }

    // report / hide place order button
    if (!addressOK)
    {
      if (!cardOK)
      {
        InfoLabel.Text =
          "You must provide a valid address and credit card "
          + "before placing your order.";
      }
      else
      {
        InfoLabel.Text =
         "You must provide a valid address before placing your "
         + "order.";
      }
    }
    else if (!cardOK)
    {
      InfoLabel.Text = "You must provide a credit card before "
        + "placing your order.";
    }
    else
    {
      InfoLabel.Text = 
        "Please confirm that the above details are "
        + "correct before proceeding.";
    }
    placeOrderButton.Visible = addressOK && cardOK;
  }

  protected void placeOrderButton_Click(object sender, 
    EventArgs e)
  {

    // Get the total amount
    decimal amount = ShoppingCartAccess.GetTotalAmount();
    // Create the order and store the order ID
    string orderId = ShoppingCartAccess.CreateOrder();
    string ordername = BalloonShopConfiguration.SiteName + 
      " Order " + orderId;
    // Go to PayPal Checkout
    string destination = Link.ToPayPalCheckout(ordername, 
      amount);
    Response.Redirect(destination);
  }
}
