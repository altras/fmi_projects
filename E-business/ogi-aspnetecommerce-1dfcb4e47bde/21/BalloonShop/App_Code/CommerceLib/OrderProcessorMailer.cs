using System.Web.Security;

namespace CommerceLib
{
  /// <summary>
  /// Mailing utilities for OrderProcessor
  /// </summary>
  public static class OrderProcessorMailer
  {
    public static void MailAdmin(int orderID, string subject,
      string message, int sourceStage)
    {
      // Send mail to administrator
      string to = BalloonShopConfiguration.ErrorLogEmail;
      string from = BalloonShopConfiguration.OrderProcessorEmail;
      string body = "Message: " + message
         + "\nSource: " + sourceStage.ToString()
         + "\nOrder ID: " + orderID.ToString();
      Utilities.SendMail(from, to, subject, body);
    }

    public static void MailCustomer(MembershipUser customer, string subject, string body)
    {
      // Send mail to customer
      string to = customer.Email;
      string from = BalloonShopConfiguration.CustomerServiceEmail;
      Utilities.SendMail(from, to, subject, body);
    }

    public static void MailSupplier(string subject, string body)
    {
      // Send mail to supplier
      string to = BalloonShopConfiguration.SupplierEmail;
      string from = BalloonShopConfiguration.OrderProcessorEmail;
      Utilities.SendMail(from, to, subject, body);
    }
  }
}
