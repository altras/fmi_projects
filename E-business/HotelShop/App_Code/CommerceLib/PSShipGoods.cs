namespace CommerceLib
{
  /// <summary>
  /// 6th pipeline stage – used to send a notification email to
  /// the supplier, stating that goods can be shipped
  /// </summary>

  public class PSShipGoods : IPipelineSection
  {
    private OrderProcessor orderProcessor;

    public void Process(OrderProcessor processor)
    {
      // set processor reference
      orderProcessor = processor;
      // audit
      orderProcessor.CreateAudit("PSShipGoods started.", 20500);
      try
      {
        // send mail to supplier
        orderProcessor.MailSupplier("BalloonShop ship goods.",
          GetMailBody());
        // audit
        orderProcessor.CreateAudit(
          "Ship goods e-mail sent to supplier.", 20502);
        // update order status
        orderProcessor.Order.UpdateStatus(6);
      }
      catch
      {
        // mail sending failure
        throw new OrderProcessorException(
          "Unable to send e-mail to supplier.", 5);
      }
      // audit
      processor.CreateAudit("PSShipGoods finished.", 20501);
    }

    private string GetMailBody()
    {
      // construct message body
      string mail =
        "Payment has been received for the following goods:\n\n"
        + orderProcessor.Order.OrderAsString
        + "\n\nPlease ship to:\n\n"
        + orderProcessor.Order.CustomerAddressAsString
        + "\n\nWhen goods have been shipped, please confirm via "
        + "http://www.example.com/AdminOrders.aspx"
        + "\n\nOrder reference number:\n\n"
        + orderProcessor.Order.OrderID.ToString();
      return mail;
    }
  }
}
