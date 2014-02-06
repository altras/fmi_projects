using System;

namespace CommerceLib
{
  /// <summary>
  /// Main class, used to obtain order information,
  /// run pipeline sections, audit orders, etc.
  /// </summary>
  public class OrderProcessor
  {
    internal IPipelineSection CurrentPipelineSection;
    internal bool ContinueNow;
    internal CommerceLibOrderInfo Order;

    public OrderProcessor(string orderID)
    {
      // get order
      Order = CommerceLibAccess.GetOrder(orderID);
    }

    public OrderProcessor(CommerceLibOrderInfo orderToProcess)
    {
      // get order
      Order = orderToProcess;
    }

    public void Process()
    {

      // configure processor
      ContinueNow = true;

      // log start of execution
      CreateAudit("Order Processor started.", 10000);

      // process pipeline section
      try
      {
        while (ContinueNow)
        {
          ContinueNow = false;
          GetCurrentPipelineSection();
          CurrentPipelineSection.Process(this);
        }
      }
      catch (OrderProcessorException ex)
      {
        MailAdmin("Order Processing error occurred.",
          ex.Message, ex.SourceStage);
        CreateAudit("Order Processing error occurred.", 10002);
        throw new OrderProcessorException(
          "Error occurred, order aborted. "
          + "Details mailed to administrator.", 100);
      }
      catch (Exception ex)
      {
        MailAdmin("Order Processing error occurred.", ex.Message,
          100);
        CreateAudit("Order Processing error occurred.", 10002);
        throw new OrderProcessorException(
          "Unknown error, order aborted. "
          + "Details mailed to administrator.", 100);
      }
      finally
      {
        CommerceLibAccess.CreateAudit(Order.OrderID,
          "Order Processor finished.", 10001);
      }
    }

    public void CreateAudit(string message, int messageNumber)
    {
      CommerceLibAccess.CreateAudit(Order.OrderID, message,
        messageNumber);
    }


    public void MailAdmin(string subject, string message,
      int sourceStage)
    {
      OrderProcessorMailer.MailAdmin(Order.OrderID, subject,
        message, sourceStage);
    }

    private void GetCurrentPipelineSection()
    {
      // select pipeline section to execute based on order status
      // for now just provide a dummy
      CurrentPipelineSection = new PSDummy();
    }
  }
}
