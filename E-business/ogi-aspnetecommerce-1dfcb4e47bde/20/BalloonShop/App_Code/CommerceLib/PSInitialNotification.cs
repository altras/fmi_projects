namespace CommerceLib
{
  /// <summary>
  /// 1st pipeline stage - used to send a notification email to
  /// the customer, confirming that the order has been received
  /// </summary>
  public class PSInitialNotification : IPipelineSection
  {
    private OrderProcessor orderProcessor;

    public void Process(OrderProcessor processor)
    {
      // set processor reference
      orderProcessor = processor;
      // audit
      orderProcessor.CreateAudit("PSInitialNotification started.", 20000);

      try
      {
        // send mail to customer
        orderProcessor.MailCustomer("BalloonShop order received.", GetMailBody());
        // audit
        orderProcessor.CreateAudit(
          "Notification e-mail sent to customer.", 20002);
        // update order status
        orderProcessor.Order.UpdateStatus(1);
        // continue processing
        orderProcessor.ContinueNow = true;
      }
      catch
      {
        // mail sending failure
        throw new OrderProcessorException(
          "Unable to send e-mail to customer.", 0);
      }
      // audit
      processor.CreateAudit("PSInitialNotification finished.", 20001);
    }

    private string GetMailBody()
    {
      // construct message body
      string mail;
      mail = "Thank you for your order! The products you have "
           + "ordered are as follows:\n\n"
           + orderProcessor.Order.OrderAsString
           + "\n\nYour order will be shipped to:\n\n"
           + orderProcessor.Order.CustomerAddressAsString
           + "\n\nOrder reference number:\n\n"
           + orderProcessor.Order.OrderID.ToString()
           + "\n\nYou will receive a confirmation e-mail when this "
           + "order has been dispatched. Thank you for shopping "
           + "at BalloonShop!";
      return mail;
    }
  }
}
