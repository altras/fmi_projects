using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommerceLib
{
  /// <summary>
  /// Summary description for PSDummy
  /// </summary>
  public class PSDummy : IPipelineSection
  {
    public void Process(OrderProcessor processor)
    {
      processor.CreateAudit("PSDoNothing started.", 99999);
      processor.CreateAudit("Customer: "
        + processor.Order.Customer.UserName, 99999);
      processor.CreateAudit("First item in order: "
        + processor.Order.OrderDetails[0].ItemAsString, 99999);
      processor.MailAdmin("Test.", "Test mail from PSDummy.", 99999);
      processor.CreateAudit("PSDoNothing finished.", 99999);
    }
  }
}
