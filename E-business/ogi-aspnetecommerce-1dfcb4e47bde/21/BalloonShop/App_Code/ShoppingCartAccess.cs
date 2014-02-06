using System;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Web.Security;

/// <summary>
/// Supports Shopping Cart functionality
/// </summary>
public class ShoppingCartAccess
{
  public ShoppingCartAccess()
  {
    //
    // TODO: Add constructor logic here
    //
  }

  // returns the shopping cart ID for the current user
  private static string shoppingCartId
  {
    get
    {
      // get the current HttpContext
      HttpContext context = HttpContext.Current;
      // check if the cart ID exists as a cookie
      if (context.Request.Cookies["BalloonShop_CartID"] != null)
      {
        // return the id
        return context.Request.Cookies["BalloonShop_CartID"].Value;
      }
      else
      // if the cart ID doesn't exist in the cookie as well, generate a new ID
      {
        // generate a new GUID
        string cartId = Guid.NewGuid().ToString();
        // create the cookie object and set its value
        HttpCookie cookie = new HttpCookie("BalloonShop_CartID", cartId);
        // set the cookie's expiration date
        int howManyDays = BalloonShopConfiguration.CartPersistDays;
        DateTime currentDate = DateTime.Now;
        TimeSpan timeSpan = new TimeSpan(howManyDays, 0, 0, 0);
        DateTime expirationDate = currentDate.Add(timeSpan);
        cookie.Expires = expirationDate;
        // set the cookie on the client's browser
        context.Response.Cookies.Add(cookie);
        // return the CartID
        return cartId.ToString();
      }

    }
  }

  // Add a new shopping cart item
  public static bool AddItem(string productId, string attributes)
  {
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "ShoppingCartAddItem";
    // create a new parameter
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@CartID";
    param.Value = shoppingCartId;
    param.DbType = DbType.String;
    param.Size = 36;
    comm.Parameters.Add(param);
    // create a new parameter
    param = comm.CreateParameter();
    param.ParameterName = "@ProductID";
    param.Value = productId;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // create a new parameter
    param = comm.CreateParameter();
    param.ParameterName = "@Attributes";
    param.Value = attributes;
    param.DbType = DbType.String;
    comm.Parameters.Add(param);
    // returns true in case of success or false in case of an error
    try
    {
      // execute the stored procedure and return true if it executes
      // successfully, or false otherwise
      return (GenericDataAccess.ExecuteNonQuery(comm) != -1);
    }
    catch
    {
      // prevent the exception from propagating, but return false to
      // signal the error
      return false;
    }
  }

  // Update the quantity of a shopping cart item
  public static bool UpdateItem(string productId, int quantity)
  {
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "ShoppingCartUpdateItem";
    // create a new parameter
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@CartID";
    param.Value = shoppingCartId;
    param.DbType = DbType.String;
    param.Size = 36;
    comm.Parameters.Add(param);
    // create a new parameter
    param = comm.CreateParameter();
    param.ParameterName = "@ProductID";
    param.Value = productId;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // create a new parameter
    param = comm.CreateParameter();
    param.ParameterName = "@Quantity";
    param.Value = quantity;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // returns true in case of success or false in case of an error
    try
    {
      // execute the stored procedure and return true if it executes
      // successfully, or false otherwise
      return (GenericDataAccess.ExecuteNonQuery(comm) != -1);
    }
    catch
    {
      // prevent the exception from propagating, but return false to
      // signal the error
      return false;
    }
  }

  // Remove a shopping cart item
  public static bool RemoveItem(string productId)
  {
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "ShoppingCartRemoveItem";
    // create a new parameter
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@CartID";
    param.Value = shoppingCartId;
    param.DbType = DbType.String;
    param.Size = 36;
    comm.Parameters.Add(param);
    // create a new parameter
    param = comm.CreateParameter();
    param.ParameterName = "@ProductID";
    param.Value = productId;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // returns true in case of success or false in case of an error
    try
    {

      // execute the stored procedure and return true if it executes
      // successfully, or false otherwise
      return (GenericDataAccess.ExecuteNonQuery(comm) != -1);
    }
    catch
    {
      // prevent the exception from propagating, but return false to
      // signal the error
      return false;
    }
  }

  // Retrieve shopping cart items
  public static DataTable GetItems()
  {
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "ShoppingCartGetItems";
    // create a new parameter
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@CartID";
    param.Value = shoppingCartId;
    param.DbType = DbType.String;
    param.Size = 36;
    comm.Parameters.Add(param);
    // return the result table
    DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
    return table;
  }

  // Retrieve shopping cart items
  public static decimal GetTotalAmount()
  {
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "ShoppingCartGetTotalAmount";
    // create a new parameter
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@CartID";
    param.Value = shoppingCartId;
    param.DbType = DbType.String;
    param.Size = 36;
    comm.Parameters.Add(param);
    // return the result table
    return Decimal.Parse(GenericDataAccess.ExecuteScalar(comm));
  }

  // Counts old shopping carts
  public static int CountOldCarts(byte days)
  {
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "ShoppingCartCountOldCarts";
    // create a new parameter
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@Days";
    param.Value = days;
    param.DbType = DbType.Byte;
    comm.Parameters.Add(param);

    // execute the procedure and return number of old shopping carts
    try
    {
      return Byte.Parse(GenericDataAccess.ExecuteScalar(comm));
    }
    catch
    {
      return -1;
    }
  }

  // Deletes old shopping carts
  public static bool DeleteOldCarts(byte days)
  {
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "ShoppingCartDeleteOldCarts";
    // create a new parameter
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@Days";
    param.Value = days;
    param.DbType = DbType.Byte;
    comm.Parameters.Add(param);
    // execute the procedure and return true if no problem occurs
    try
    {
      GenericDataAccess.ExecuteNonQuery(comm);
      return true;
    }
    catch
    {
      return false;
    }
  }

  // Create a new order from the shopping cart
  public static string CreateOrder()
  {
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "CreateOrder";
    // create a new parameter
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@CartID";
    param.Value = shoppingCartId;
    param.DbType = DbType.String;
    param.Size = 36;
    comm.Parameters.Add(param);
    // return the result table
    return GenericDataAccess.ExecuteScalar(comm);
  }

  // gets product recommendations for the shopping cart
  public static DataTable GetRecommendations()
  {
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "CatalogGetCartRecommendations";
    // create a new parameter
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@CartID";
    param.Value = shoppingCartId;
    param.DbType = DbType.String;
    param.Size = 36;
    comm.Parameters.Add(param);
    // create a new parameter
    param = comm.CreateParameter();
    param.ParameterName = "@DescriptionLength";
    param.Value = BalloonShopConfiguration.ProductDescriptionLength;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // execute the stored procedure
    return GenericDataAccess.ExecuteSelectCommand(comm);
  }

  public static string CreateCommerceLibOrder(int shippingId, int taxId)
  {
    // get a configured DbCommand object
    DbCommand comm = GenericDataAccess.CreateCommand();
    // set the stored procedure name
    comm.CommandText = "CreateCustomerOrder";
    // create parameters
    DbParameter param = comm.CreateParameter();
    param.ParameterName = "@CartID";
    param.Value = shoppingCartId;
    param.DbType = DbType.String;
    param.Size = 36;
    comm.Parameters.Add(param);
    // create a new parameter
    param = comm.CreateParameter();
    param.ParameterName = "@CustomerId";
    param.Value =
       Membership.GetUser(
       HttpContext.Current.User.Identity.Name)
       .ProviderUserKey;
    param.DbType = DbType.Guid;
    param.Size = 16;
    comm.Parameters.Add(param);
    // create a new parameter
    param = comm.CreateParameter();
    param.ParameterName = "@ShippingId";
    param.Value = shippingId;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // create a new parameter
    param = comm.CreateParameter();
    param.ParameterName = "@TaxId";
    param.Value = taxId;
    param.DbType = DbType.Int32;
    comm.Parameters.Add(param);
    // return the result table
    return GenericDataAccess.ExecuteScalar(comm);
  }

}
