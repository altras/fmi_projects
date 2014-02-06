using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;

/// <summary>
/// Wraps order data
/// </summary>
public struct OrderInfo
{
  public int OrderID;
  public decimal TotalAmount;
  public string DateCreated;
  public string DateShipped;
  public bool Verified;
  public bool Completed;
  public bool Canceled;
  public string Comments;
  public string CustomerName;
  public string ShippingAddress;
  public string CustomerEmail;
}

/// <summary>
/// Summary description for OrdersAccess
/// </summary>
public class OrdersAccess
{
	public OrdersAccess()
	{
		//
		// TODO: Add constructor logic here
		//
	}

  // Retrieve the recent orders
  public static DataTable GetByRecent(int count)
  {
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "OrdersGetByRecent";
    // create a new parameter
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@Count";
    param.Value = count;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // return the result table
    DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
    return table;
  }

  // Retrieve orders that have been placed in a specified period of time
  public static DataTable GetByDate(string startDate, string endDate)
  {
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();

    // set the stored procedure name
    comm.CommandText = "OrdersGetByDate";
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
    // return the result table
    DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
    return table;
  }

  // Retrieve orders that need to be verified or canceled
  public static DataTable GetUnverifiedUncanceled()
  {
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "OrdersGetUnverifiedUncanceled";
    // return the result table
    DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
    return table;
  }

  // Retrieve orders that need to be shipped/completed
  public static DataTable GetVerifiedUncompleted()
  {
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();

    // set the stored procedure name
    comm.CommandText = "OrdersGetVerifiedUncompleted";
    // return the result table
    DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
    return table;
  }

  // Retrieve order information
  public static OrderInfo GetInfo(string orderID)
  {
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "OrderGetInfo";
    // create a new parameter
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@OrderID";
    param.Value = orderID;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);

    // obtain the results
    DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
    DataRow orderRow = table.Rows[0];
    // save the results into an OrderInfo object
    OrderInfo orderInfo;
    orderInfo.OrderID = Int32.Parse(orderRow["OrderID"].ToString());
    orderInfo.TotalAmount = Decimal.Parse(orderRow["TotalAmount"].ToString());
    orderInfo.DateCreated = orderRow["DateCreated"].ToString();
    orderInfo.DateShipped = orderRow["DateShipped"].ToString();
    orderInfo.Verified = bool.Parse(orderRow["Verified"].ToString());
    orderInfo.Completed = bool.Parse(orderRow["Completed"].ToString());
    orderInfo.Canceled = bool.Parse(orderRow["Canceled"].ToString());
    orderInfo.Comments = orderRow["Comments"].ToString();
    orderInfo.CustomerName = orderRow["CustomerName"].ToString();
    orderInfo.ShippingAddress = orderRow["ShippingAddress"].ToString();
    orderInfo.CustomerEmail = orderRow["CustomerEmail"].ToString();
    // return the OrderInfo object
    return orderInfo;
  }

  // Retrieve the order details (the products that are part of that order)
  public static DataTable GetDetails(string orderID)
  {
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "OrderGetDetails";
    // create a new parameter
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@OrderID";
    param.Value = orderID;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // return the results
    DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
    return table;
  }

  // Update an order
  public static void Update(OrderInfo orderInfo)
  {
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "OrderUpdate";
    // create a new parameter
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@OrderID";
    param.Value = orderInfo.OrderID;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // create a new parameter
    param = comm.CreateParameter();
    param.ParameterName = "@DateCreated";
    param.Value = orderInfo.DateCreated;
    param.DbType = DbType.DateTime;
    comm.Parameters.Add(param);
    // The DateShipped parameter is sent only if data is available
    if (orderInfo.DateShipped.Trim() != "")
    {
      param = comm.CreateParameter();
      param.ParameterName = "@DateShipped";
      param.Value = orderInfo.DateShipped;
      param.DbType = DbType.DateTime;
      comm.Parameters.Add(param);
    }
    // create a new parameter
    param = comm.CreateParameter();
    param.ParameterName = "@Verified";
    param.Value = orderInfo.Verified;
    param.DbType = DbType.Byte;
    comm.Parameters.Add(param);
    // create a new parameter
    param = comm.CreateParameter();
    param.ParameterName = "@Completed";
    param.Value = orderInfo.Completed;
    param.DbType = DbType.Byte;
    comm.Parameters.Add(param);
    // create a new parameter
    param = comm.CreateParameter();
    param.ParameterName = "@Canceled";
    param.Value = orderInfo.Canceled;
    param.DbType = DbType.Byte;
    comm.Parameters.Add(param);

    // create a new parameter
    param = comm.CreateParameter();
    param.ParameterName = "@Comments";
    param.Value = orderInfo.Comments;
    param.DbType = DbType.String;
    comm.Parameters.Add(param);
    // create a new parameter
    param = comm.CreateParameter();
    param.ParameterName = "@CustomerName";
    param.Value = orderInfo.CustomerName;
    param.DbType = DbType.String;
    comm.Parameters.Add(param);
    // create a new parameter
    param = comm.CreateParameter();
    param.ParameterName = "@ShippingAddress";
    param.Value = orderInfo.ShippingAddress;
    param.DbType = DbType.String;
    comm.Parameters.Add(param);
    // create a new parameter
    param = comm.CreateParameter();
    param.ParameterName = "@CustomerEmail";
    param.Value = orderInfo.CustomerEmail;
    param.DbType = DbType.String;
    comm.Parameters.Add(param);
    // return the results
    GenericDataAccess.ExecuteNonQuery(comm);
  }

  // Mark an order as verified
  public static void MarkVerified(string orderId)
  {
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "OrderMarkVerified";
    // create a new parameter
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@OrderID";
    param.Value = orderId;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // return the results
    GenericDataAccess.ExecuteNonQuery(comm);
  }

  // Mark an order as completed
  public static void MarkCompleted(string orderId)
  {
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "OrderMarkCompleted";
    // create a new parameter
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@OrderID";
    param.Value = orderId;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // return the results
    GenericDataAccess.ExecuteNonQuery(comm);
  }

  // Mark an order as canceled
  public static void MarkCanceled(string orderId)
  {
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "OrderMarkCanceled";
    // create a new parameter
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@OrderID";
    param.Value = orderId;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // return the results
    GenericDataAccess.ExecuteNonQuery(comm);
  }


}
