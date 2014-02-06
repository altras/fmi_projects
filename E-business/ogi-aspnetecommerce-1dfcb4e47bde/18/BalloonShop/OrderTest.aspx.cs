using System;

public partial class OrderTest : System.Web.UI.Page
{
  protected void goButton_Click(object sender, EventArgs e)
  {
    try
    {
      CommerceLibOrderInfo orderInfo = CommerceLibAccess.GetOrder(
        orderIDBox.Text);
      resultLabel.Text = "Order found.";
      addressLabel.Text = orderInfo.CustomerAddressAsString.Replace(
        "\n", "<br />");
      creditCardLabel.Text = orderInfo.CreditCard.CardNumberX;
      orderLabel.Text =
        orderInfo.OrderAsString.Replace("\n", "<br />");
    }
    catch
    {
      resultLabel.Text = "No order found, or order is in old format.";
      addressLabel.Text = "";
      creditCardLabel.Text = "";
      orderLabel.Text = "";
    }
  }
}
