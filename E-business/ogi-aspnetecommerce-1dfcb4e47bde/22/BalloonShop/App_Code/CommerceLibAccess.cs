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
public class TaxInfo
{
  public int TaxID;
  public string TaxType;
  public double TaxPercentage;
}

/// <summary>
/// Wraps shipping data
/// </summary>
public class ShippingInfo
{
  public int ShippingID;
  public string ShippingType;
  public double ShippingCost;
  public int ShippingRegionId;
}

public class CommerceLibAccess
{
  public static readonly string[] OrderStatuses = 
    {"Order placed, notifying customer", // 0
    "Awaiting confirmation of funds",    // 1
    "Notifying supplier—stock check",    // 2
    "Awaiting stock confirmation",       // 3
    "Awaiting credit card payment",      // 4
    "Notifying supplier—shipping",       // 5
    "Awaiting shipment confirmation",    // 6
    "Sending final notification",        // 7
    "Order completed",                   // 8
    "Order canceled"};                  // 9

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

  public static void CreateAudit(int orderID, string message,
int messageNumber)
  {
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "CreateAudit";
    // create a new parameter
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@OrderID";
    param.Value = orderID;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // create a new parameter
    param = comm.CreateParameter();
    param.ParameterName = "@Message";
    param.Value = message;
    param.DbType = DbType.String;
    param.Size = 512;
    comm.Parameters.Add(param);
    // create a new parameter
    param = comm.CreateParameter();
    param.ParameterName = "@MessageNumber";
    param.Value = messageNumber;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // execute the stored procedure
    GenericDataAccess.ExecuteNonQuery(comm);
  }

  public static void UpdateOrderStatus(int orderID, int status)
  {
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "CommerceLibOrderUpdateStatus";
    // create a new parameter
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@OrderID";
    param.Value = orderID;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // create a new parameter
    param = comm.CreateParameter();
    param.ParameterName = "@Status";
    param.Value = status;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // execute the stored procedure
    GenericDataAccess.ExecuteNonQuery(comm);
  }

  public static void SetOrderAuthCodeAndReference(int orderID,
  string authCode, string reference)
  {
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "CommerceLibOrderSetAuthCode";
    // create a new parameter
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@OrderID";
    param.Value = orderID;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // create a new parameter
    param = comm.CreateParameter();
    param.ParameterName = "@AuthCode";
    param.Value = authCode;
    param.DbType = DbType.String;
    param.Size = 50;
    comm.Parameters.Add(param);
    // create a new parameter
    param = comm.CreateParameter();
    param.ParameterName = "@Reference";
    param.Value = reference;
    param.DbType = DbType.String;
    param.Size = 50;
    comm.Parameters.Add(param);
    // execute the stored procedure
    GenericDataAccess.ExecuteNonQuery(comm);
  }

  public static void SetOrderDateShipped(int orderID)
  {
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "CommerceLibOrderSetDateShipped";
    // create a new parameter
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@OrderID";
    param.Value = orderID;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // execute the stored procedure
    GenericDataAccess.ExecuteNonQuery(comm);
  }

  public static List<CommerceLibAuditInfo> GetOrderAuditTrail
    (string orderID)
  {
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "CommerceLibOrderGetAuditTrail";
    // create a new parameter
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@OrderID";
    param.Value = orderID;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // obtain the results
    DataTable orderAuditTrailData =
      GenericDataAccess.ExecuteSelectCommand(comm);
    // create List<>
    List<CommerceLibAuditInfo> orderAuditTrail =
      new List<CommerceLibAuditInfo>(
      orderAuditTrailData.Rows.Count);
    foreach (DataRow orderAudit in orderAuditTrailData.Rows)
    {
      orderAuditTrail.Add(new CommerceLibAuditInfo(orderAudit));
    }
    return orderAuditTrail;
  }

  public static List<CommerceLibOrderInfo>
  ConvertDataTableToOrders(DataTable table)
  {
    List<CommerceLibOrderInfo> orders =
      new List<CommerceLibOrderInfo>(table.Rows.Count);
    foreach (DataRow orderRow in table.Rows)
    {
      try
      {
        // try to add order
        orders.Add(new CommerceLibOrderInfo(orderRow));
      }
      catch
      {
        // can't add this order
      }
    }
    return orders;
  }

  public static List<CommerceLibOrderInfo> GetOrdersByCustomer(
  string customerID)
  {
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "CommerceLibOrdersGetByCustomer";
    // create a new parameter
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@CustomerID";
    param.Value = new Guid(customerID);
    param.DbType = DbType.Guid;
    comm.Parameters.Add(param);
    // obtain the results
    return ConvertDataTableToOrders(
      GenericDataAccess.ExecuteSelectCommand(comm));
  }

  public static List<CommerceLibOrderInfo> GetOrdersByDate(
  string startDate, string endDate)
  {
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "CommerceLibOrdersGetByDate";
    // create a new parameter
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@StartDate";
    param.Value = startDate;
    param.DbType = DbType.Date;
    comm.Parameters.Add(param);
    // create a new parameter
    param = comm.CreateParameter();
    param.ParameterName = "@EndDate";
    param.Value = endDate;
    param.DbType = DbType.Date;
    comm.Parameters.Add(param);
    // obtain the results
    return ConvertDataTableToOrders(
      GenericDataAccess.ExecuteSelectCommand(comm));
  }

  public static List<CommerceLibOrderInfo> GetOrdersByRecent(
  int count)
  {
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();

    // set the stored procedure name
    comm.CommandText = "CommerceLibOrdersGetByRecent";
    // create a new parameter
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@Count";
    param.Value = count;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // obtain the results
    return ConvertDataTableToOrders(
      GenericDataAccess.ExecuteSelectCommand(comm));
  }

  public static List<CommerceLibOrderInfo> GetOrdersByStatus(
  int status)
  {
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "CommerceLibOrdersGetByStatus";
    // create a new parameter
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@Status";
    param.Value = status;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // obtain the results
    return ConvertDataTableToOrders(
      GenericDataAccess.ExecuteSelectCommand(comm));
  }

  public static void UpdateOrder(int orderID,
  string newDateCreated, string newDateShipped,
  int newStatus, string newAuthCode, string newReference,
  string newComments)
  {
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "CommerceLibOrderUpdate";
    // create a new parameter
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@OrderID";
    param.Value = orderID;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // create a new parameter
    param = comm.CreateParameter();
    param.ParameterName = "@DateCreated";
    param.Value = DateTime.Parse(newDateCreated);
    param.DbType = DbType.DateTime;
    comm.Parameters.Add(param);
    // The DateShipped parameter is sent only if data is available
    if (newDateShipped != null && newDateShipped != "")
    {
      param = comm.CreateParameter();
      param.ParameterName = "@DateShipped";
      param.Value = DateTime.Parse(newDateShipped);
      param.DbType = DbType.DateTime;
      comm.Parameters.Add(param);
    }
    // create a new parameter
    param = comm.CreateParameter();
    param.ParameterName = "@Status";
    param.Value = newStatus;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // create a new parameter
    param = comm.CreateParameter();
    param.ParameterName = "@AuthCode";
    param.Value = newAuthCode;
    param.DbType = DbType.String;
    comm.Parameters.Add(param);
    // create a new parameter
    param = comm.CreateParameter();
    param.ParameterName = "@Reference";
    param.Value = newReference;
    param.DbType = DbType.String;
    comm.Parameters.Add(param);
    // create a new parameter
    param = comm.CreateParameter();
    param.ParameterName = "@Comments";
    param.Value = newComments;
    param.DbType = DbType.String;
    comm.Parameters.Add(param);
    // update the order
    GenericDataAccess.ExecuteNonQuery(comm);
  }


}

/// <summary>
/// Wraps order detail data
/// </summary>
public class CommerceLibOrderDetailInfo
{
  public int OrderID { get; set; }
  public int ProductID { get; set; }
  public string ProductName { get; set; }
  public int Quantity { get; set; }
  public double UnitCost { get; set; }
  public string ItemAsString { get; set; }

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
  public int OrderID { get; set; }
  public string DateCreated { get; set; }
  public string DateShipped { get; set; }
  public string Comments { get; set; }
  public int Status { get; set; }
  public string AuthCode { get; set; }
  public string Reference { get; set; }
  public MembershipUser Customer { get; set; }
  public ProfileCommon CustomerProfile { get; set; }
  public SecureCard CreditCard { get; set; }
  public double TotalCost { get; set; }
  public string OrderAsString { get; set; }
  public string CustomerAddressAsString { get; set; }
  public ShippingInfo Shipping { get; set; }
  public TaxInfo Tax { get; set; }

  public List<CommerceLibOrderDetailInfo> OrderDetails;
  private List<CommerceLibAuditInfo> auditTrail;

  public CommerceLibOrderInfo(DataRow orderRow)
  {
    Shipping = new ShippingInfo();
    Tax = new TaxInfo();

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

  public void UpdateStatus(int status)
  {
    // call static method
    CommerceLibAccess.UpdateOrderStatus(OrderID, status);
    // update field
    Status = status;
  }

  public void SetAuthCodeAndReference(string authCode,
    string reference)
  {
    // call static method
    CommerceLibAccess.SetOrderAuthCodeAndReference(OrderID,
      authCode, reference);
    // update fields
    AuthCode = authCode;
    Reference = reference;
  }

  public void SetDateShipped()
  {
    // call static method
    CommerceLibAccess.SetOrderDateShipped(OrderID);
    // update field
    DateShipped = DateTime.Now.ToString();
  }

  public string StatusAsString
  {
    get
    {
      try
      {
        return CommerceLibAccess.OrderStatuses[Status];
      }
      catch
      {
        return "Status unknown";
      }
    }
  }

  public string CustomerName
  {
    get
    {
      return Customer.UserName;
    }
  }

  public List<CommerceLibAuditInfo> AuditTrail
  {
    get
    {
      if (auditTrail == null)
      {
        auditTrail = CommerceLibAccess.GetOrderAuditTrail(
          OrderID.ToString());
      }
      return auditTrail;
    }
  }


}

/// <summary>
/// Wraps audit trail data
/// </summary>
public class CommerceLibAuditInfo
{
  public int AuditID { get; private set; }
  public int OrderID { get; private set; }
  public DateTime DateStamp { get; private set; }
  public string Message { get; private set; }
  public int MessageNumber { get; private set; }

  public CommerceLibAuditInfo(DataRow auditRow)
  {
    AuditID = (int)auditRow["AuditID"];
    OrderID = (int)auditRow["OrderID"];
    DateStamp = (DateTime)auditRow["DateStamp"];
    Message = auditRow["Message"] as string;
    MessageNumber = (int)auditRow["messageNumber"];
  }
}
