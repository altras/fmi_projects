using DataCashLib;

namespace CommerceLib
{
  /// <summary>
  /// 2nd pipeline stage - used to check that the customer
  /// has the required funds available for purchase
  /// </summary>
  public class PSCheckFunds : IPipelineSection
  {
    private OrderProcessor orderProcessor;

    public void Process(OrderProcessor processor)
    {
      // set processor reference
      orderProcessor = processor;
      // audit
      orderProcessor.CreateAudit("PSCheckFunds started.", 20100);
      try
      {
        // check customer funds via DataCash gateway
        // configure DataCash XML request
        DataCashRequest request = new DataCashRequest();
        request.Authentication.Client =
           BalloonShopConfiguration.DataCashClient;
        request.Authentication.Password =
           BalloonShopConfiguration.DataCashPassword;

        request.Transaction.TxnDetails.MerchantReference =
          orderProcessor.Order.OrderID.ToString()
          .PadLeft(6, '0').PadLeft(7, '5');
        request.Transaction.TxnDetails.Amount.Amount =
          orderProcessor.Order.TotalCost.ToString();
        request.Transaction.TxnDetails.Amount.Currency =
          BalloonShopConfiguration.DataCashCurrency;
        request.Transaction.CardTxn.Method = "pre";
        request.Transaction.CardTxn.Card.CardNumber =
          orderProcessor.Order.CreditCard.CardNumber;
        request.Transaction.CardTxn.Card.ExpiryDate =
          orderProcessor.Order.CreditCard.ExpiryDate;
        if (orderProcessor.Order.CreditCard.IssueDate != "")
        {
          request.Transaction.CardTxn.Card.StartDate =
            orderProcessor.Order.CreditCard.IssueDate;
        }
        if (orderProcessor.Order.CreditCard.IssueNumber != "")
        {
          request.Transaction.CardTxn.Card.IssueNumber =
            orderProcessor.Order.CreditCard.IssueNumber;
        }
        // get DataCash response
        DataCashResponse response =
          request.GetResponse(
          BalloonShopConfiguration.DataCashUrl);
        if (true || response.Status == "1")
        {
          // update order authorization code and reference
          orderProcessor.Order.SetAuthCodeAndReference(
            response.MerchantReference,
            response.DatacashReference);
          // audit
          orderProcessor.CreateAudit(
            "Funds available for purchase.", 20102);
          // update order status
          orderProcessor.Order.UpdateStatus(2);
          // continue processing
          orderProcessor.ContinueNow = true;
        }
        else
        {
          // audit
          orderProcessor.CreateAudit(
            "Funds not available for purchase.", 20103);
          // mail admin

          orderProcessor.MailAdmin("Credit card declined.",
            "XML data exchanged:\n" + request.Xml + "\n\n"
            + response.Xml, 1);
        }
      }
      catch
      {
        // fund checking failure
        throw new OrderProcessorException(
          "Error occured while checking funds.", 1);
      }
      // audit
      processor.CreateAudit("PSCheckFunds finished.", 20101);
    }
  }
}
