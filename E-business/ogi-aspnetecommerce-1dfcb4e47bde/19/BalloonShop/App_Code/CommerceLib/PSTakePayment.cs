namespace CommerceLib
{
  /// <summary>
  /// 5th pipeline stage – takes funds from customer
  /// </summary>
  public class PSTakePayment : IPipelineSection
  {
    private OrderProcessor orderProcessor;


    public void Process(OrderProcessor processor)
    {
      // set processor reference
      orderProcessor = processor;
      // audit
      orderProcessor.CreateAudit("PSTakePayment started.", 20400);
      try
      {
        // take customer funds 
        // assume success for now
        // audit
        orderProcessor.CreateAudit(
          "Funds deducted from customer credit card account.", 20402);
        // update order status
        orderProcessor.Order.UpdateStatus(5);
        // continue processing
        orderProcessor.ContinueNow = true;
      }
      catch
      {
        // fund checking failure
        throw new OrderProcessorException(
          "Error occured while taking payment.", 4);
      }
      // audit
      processor.CreateAudit("PSTakePayment finished.", 20401);
    }
  }
}
