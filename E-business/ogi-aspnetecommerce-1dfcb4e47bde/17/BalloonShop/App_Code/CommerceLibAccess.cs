using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Text;
using System.Data;
using System.Web.Profile;
using System.Web.Security;
using SecurityLib;

/// <summary>
/// Wraps tax data
/// </summary>
public struct TaxInfo
{
  public int TaxID;
  public string TaxType;
  public double TaxPercentage;
}

/// <summary>
/// Wraps shipping data
/// </summary>
public struct ShippingInfo
{
  public int ShippingID;
  public string ShippingType;
  public double ShippingCost;
  public int ShippingRegionId;
}

public class CommerceLibAccess
{
  public static List<ShippingInfo> GetShippingInfo(
  int shippingRegionId)
  {
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "CommerceLibShippingGetInfo";
    // create a new parameter
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@ShippingRegionId";
    param.Value = shippingRegionId;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // obtain the results
    DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
    List<ShippingInfo> result = new List<ShippingInfo>();
    foreach (DataRow row in table.Rows)
    {
      ShippingInfo rowData = new ShippingInfo();
      rowData.ShippingID = int.Parse(row["ShippingId"].ToString());
      rowData.ShippingType = row["ShippingType"].ToString();
      rowData.ShippingCost =
        double.Parse(row["ShippingCost"].ToString());
      rowData.ShippingRegionId = shippingRegionId;
      result.Add(rowData);
    }
    return result;
  }

  public static List<CommerceLibOrderDetailInfo> GetOrderDetails(string orderId)
  {
    // use existing method for DataTable
    DataTable orderDetailsData = OrdersAccess.GetDetails(orderId);
    // create List<>
    List<CommerceLibOrderDetailInfo> orderDetails =
      new List<CommerceLibOrderDetailInfo>(
      orderDetailsData.Rows.Count);
    foreach (DataRow orderDetail in orderDetailsData.Rows)
    {
      orderDetails.Add(
        new CommerceLibOrderDetailInfo(orderDetail));
    }
    return orderDetails;
  }

  public static CommerceLibOrderInfo GetOrder(string orderID)
  {
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "CommerceLibOrderGetInfo";
    // create a new parameter
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@OrderID";
    param.Value = orderID;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // obtain the results
    DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
    DataRow orderRow = table.Rows[0];
    // save the results into an CommerceLibOrderInfo object
    CommerceLibOrderInfo orderInfo =
      new CommerceLibOrderInfo(orderRow);
    return orderInfo;
  }
}

/// <summary>
/// Wraps order detail data
/// </summary>
public class CommerceLibOrderDetailInfo
{
  public int OrderID;
  public int ProductID;
  public string ProductName;
  public int Quantity;
  public double UnitCost;
  public string ItemAsString;

  public double Subtotal
  {
    get
    {
      return Quantity * UnitCost;
    }
  }

  public CommerceLibOrderDetailInfo(DataRow orderDetailRow)
  {
    OrderID = Int32.Parse(orderDetailRow["OrderID"].ToString());
    ProductID = Int32.Parse(orderDetailRow["ProductId"].ToString());
    ProductName = orderDetailRow["ProductName"].ToString();
    Quantity = Int32.Parse(orderDetailRow["Quantity"].ToString());
    UnitCost = Double.Parse(orderDetailRow["UnitCost"].ToString());
    // set info property
    Refresh();
  }

  public void Refresh()
  {
    ItemAsString = Quantity.ToString() + " " + ProductName + ", $" + UnitCost.ToString() + " each, total cost $" + Subtotal.ToString();
  }
}

/// <summary>
/// Wraps order data
/// </summary>
public class CommerceLibOrderInfo
{
  public int OrderID;
  public string DateCreated;
  public string DateShipped;
  public string Comments;
  public int Status;
  public string AuthCode;
  public string Reference;
  public MembershipUser Customer;
  public ProfileCommon CustomerProfile;
  public SecureCard CreditCard;
  public double TotalCost;
  public string OrderAsString;
  public string CustomerAddressAsString;
  public ShippingInfo Shipping;
  public TaxInfo Tax;

  public List<CommerceLibOrderDetailInfo> OrderDetails;

  public CommerceLibOrderInfo(DataRow orderRow)
  {
    OrderID = Int32.Parse(orderRow["OrderID"].ToString());
    DateCreated = orderRow["DateCreated"].ToString();
    DateShipped = orderRow["DateShipped"].ToString();
    Comments = orderRow["Comments"].ToString();
    Status = Int32.Parse(orderRow["Status"].ToString());
    AuthCode = orderRow["AuthCode"].ToString();
    Reference = orderRow["Reference"].ToString();
    Customer = Membership.GetUser(
      new Guid(orderRow["CustomerID"].ToString()));
    CustomerProfile =
      (HttpContext.Current.Profile as ProfileCommon)
        .GetProfile(Customer.UserName);
    CreditCard = new SecureCard(CustomerProfile.CreditCard);
    OrderDetails =
      CommerceLibAccess.GetOrderDetails(
      orderRow["OrderID"].ToString());
    // Get Shipping Data
    if (orderRow["ShippingID"] != DBNull.Value
      && orderRow["ShippingType"] != DBNull.Value
      && orderRow["ShippingCost"] != DBNull.Value)
    {
      Shipping.ShippingID =
         Int32.Parse(orderRow["ShippingID"].ToString());
      Shipping.ShippingType = orderRow["ShippingType"].ToString();
      Shipping.ShippingCost =
         double.Parse(orderRow["ShippingCost"].ToString());
    }
    else
    {
      Shipping.ShippingID = -1;
    }
    // Get Tax Data
    if (orderRow["TaxID"] != DBNull.Value
      && orderRow["TaxType"] != DBNull.Value
      && orderRow["TaxPercentage"] != DBNull.Value)
    {
      Tax.TaxID = Int32.Parse(orderRow["TaxID"].ToString());
      Tax.TaxType = orderRow["TaxType"].ToString();
      Tax.TaxPercentage =
       double.Parse(orderRow["TaxPercentage"].ToString());
    }
    else
    {
      Tax.TaxID = -1;
    }
    // set info properties
    Refresh();
  }

  public void Refresh()
  {
    // calculate total cost and set data
    StringBuilder sb = new StringBuilder();
    TotalCost = 0.0;
    foreach (CommerceLibOrderDetailInfo item in OrderDetails)
    {
      sb.AppendLine(item.ItemAsString);
      TotalCost += item.Subtotal;
    }
    // Add shipping cost
    if (Shipping.ShippingID != -1)
    {
      sb.AppendLine("Shipping: " + Shipping.ShippingType);
      TotalCost += Shipping.ShippingCost;
    }

    // Add tax
    if (Tax.TaxID != -1 && Tax.TaxPercentage != 0.0)
    {
      double taxAmount = Math.Round(TotalCost * Tax.TaxPercentage,
        MidpointRounding.AwayFromZero) / 100.0;
      sb.AppendLine("Tax: " + Tax.TaxType + ", $"
        + taxAmount.ToString());
      TotalCost += taxAmount;
    }
    sb.AppendLine();
    sb.Append("Total order cost: $");
    sb.Append(TotalCost.ToString());
    OrderAsString = sb.ToString();

    // get customer address string
    sb = new StringBuilder();
    sb.AppendLine(Customer.UserName);
    sb.AppendLine(CustomerProfile.Address1);
    if (CustomerProfile.Address2 != "")
    {
      sb.AppendLine(CustomerProfile.Address2);
    }
    sb.AppendLine(CustomerProfile.City);
    sb.AppendLine(CustomerProfile.Region);
    sb.AppendLine(CustomerProfile.PostalCode);
    sb.AppendLine(CustomerProfile.Country);
    CustomerAddressAsString = sb.ToString();
  }
}
