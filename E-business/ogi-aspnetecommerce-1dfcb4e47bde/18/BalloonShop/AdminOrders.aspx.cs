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

  // list the most recent orders
  protected void byRecentGo_Click(object sender, EventArgs e)
  {
    // how many orders to list?
    int recordCount;

    // load the new data into the grid
    if (int.TryParse(recentCountTextBox.Text, out recordCount))
      grid.DataSource = OrdersAccess.GetByRecent(recordCount);
    else
      errorLabel.Text = "Please enter a valid number!";
    // refresh the data grid
    grid.DataBind();
  }

  // get unverified, uncanceled orders
  protected void unverfiedGo_Click(object sender, EventArgs e)
  {
    // load the grid with the requested data
    grid.DataSource = OrdersAccess.GetUnverifiedUncanceled();
    // refresh the data grid
    grid.DataBind();
  }

  // list the orders that happened between specified dates
  protected void byDateGo_Click(object sender, EventArgs e)
  {
    // check if the page is valid (we have date validator controls)
    if ((Page.IsValid) && (startDateTextBox.Text + endDateTextBox.Text != ""))
    {
      // get the dates
      string startDate = startDateTextBox.Text;
      string endDate = endDateTextBox.Text;
      // load the grid with the requested data
      grid.DataSource = OrdersAccess.GetByDate(startDate, endDate);
    }
    else
      errorLabel.Text = "Please enter valid dates!";
    // refresh the data grid
    grid.DataBind();
  }

  // get verified, but uncompleted orders
  protected void uncompletedGo_Click(object sender, EventArgs e)
  {
    // load the grid with the requested data
    grid.DataSource = OrdersAccess.GetVerifiedUncompleted();
    // refresh the data grid
    grid.DataBind();
  }

  // Load the details of the selected order
  protected void grid_SelectedIndexChanged(object sender, EventArgs e)
  {
    string destination = String.Format("AdminOrderDetails.aspx?OrderID={0}",
      grid.DataKeys[grid.SelectedIndex].Value.ToString());
    Response.Redirect(destination);
  }
}