namespace CommerceLib
{
  /// <summary>
  /// 7th pipeline stage - after confirmation that supplier has
  /// shipped goods
  /// </summary>
  public class PSShipOK : IPipelineSection
  {
    private OrderProcessor orderProcessor;

    public void Process(OrderProcessor processor)
    {
      // set processor reference
      orderProcessor = processor;
      // audit
      orderProcessor.CreateAudit("PSShipOK started.", 20600);
      // set order shipment date
      orderProcessor.Order.SetDateShipped();
      // audit
      orderProcessor.CreateAudit("Order dispatched by supplier.", 20602);
      // update order status
      orderProcessor.Order.UpdateStatus(7);
      // continue processing
      orderProcessor.ContinueNow = true;
      // audit
      processor.CreateAudit("PSShipOK finished.", 20601);
    }
  }
}
