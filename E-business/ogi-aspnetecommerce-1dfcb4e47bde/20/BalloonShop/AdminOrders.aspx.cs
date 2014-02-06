using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminOrders : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {

  }

  // Load the details of the selected order
  protected void grid_SelectedIndexChanged(object sender, EventArgs e)
  {
    string destination = String.Format("AdminOrderDetails.aspx?OrderID={0}",
      grid.DataKeys[grid.SelectedIndex].Value.ToString());
    Response.Redirect(destination);
  }

  // Display orders by customer
  protected void byCustomerGo_Click(object sender, EventArgs e)
  {
    try
    {
      List<CommerceLibOrderInfo> orders =
        CommerceLibAccess.GetOrdersByCustomer(
        userDropDown.SelectedValue);
      grid.DataSource = orders;
      if (orders.Count == 0)
      {
        errorLabel.Text =
          "Selected customer has made no orders.";
      }
      grid.DataBind();
    }
    catch
    {
      errorLabel.Text = "Couldn't get the requested orders!";
    }
  }

  // Display single order only
  protected void byIDGo_Click(object sender, EventArgs e)
  {
    string destination = String.Format("AdminOrderDetails.aspx?OrderID={0}",
      orderIDBox.Text);
    Response.Redirect(destination);
  }

  // Display the most recent orders
  protected void byRecentGo_Click(object sender, EventArgs e)
  {
    try
    {
      int recordCount = Int32.Parse(recentCountTextBox.Text);
      List<CommerceLibOrderInfo> orders =
        CommerceLibAccess.GetOrdersByRecent(recordCount);
      grid.DataSource = orders;
      if (orders.Count == 0)
      {
        errorLabel.Text = "No orders to get.";
      }
      grid.DataBind();
    }
    catch
    {
      errorLabel.Text = "Couldn't get the requested orders!";
    }
  }

  // Display orders that happened in a specified period of time
  protected void byDateGo_Click(object sender, EventArgs e)
  {
    try
    {
      string startDate = startDateTextBox.Text;
      string endDate = endDateTextBox.Text;
      List<CommerceLibOrderInfo> orders =
        CommerceLibAccess.GetOrdersByDate(startDate, endDate);
      grid.DataSource = orders;
      if (orders.Count == 0)
      {
        errorLabel.Text =
          "No orders between selected dates.";
      }
      grid.DataBind();
    }
    catch
    {
      errorLabel.Text = "Couldn't get the requested orders!";
    }
  }

  // Display orders awaiting stock
  protected void awaitingStockGo_Click(object sender, EventArgs e)
  {
    try
    {
      List<CommerceLibOrderInfo> orders =
        CommerceLibAccess.GetOrdersByStatus(3);
      grid.DataSource = orders;
      if (orders.Count == 0)
      {
        errorLabel.Text = "No orders awaiting stock check.";
      }
      grid.DataBind();
    }
    catch
    {
      errorLabel.Text = "Couldn't get the requested orders!";
    }
  }

  // Display orders awaiting shipping
  protected void awaitingShippingGo_Click(object sender, EventArgs e)
  {
    try
    {
      List<CommerceLibOrderInfo> orders =
        CommerceLibAccess.GetOrdersByStatus(6);
      grid.DataSource = orders;
      if (orders.Count == 0)
      {
        errorLabel.Text = "No orders awaiting shipment.";
      }
      grid.DataBind();
    }

    catch
    {
      errorLabel.Text = "Couldn't get the requested orders!";
    }
  }


}