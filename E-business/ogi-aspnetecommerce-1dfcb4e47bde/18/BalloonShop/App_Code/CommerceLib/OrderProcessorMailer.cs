
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
  }
}
