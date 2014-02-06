using System;

namespace CommerceLib
{
  /// <summary>
  /// Standard exception for order processor
  /// </summary>
  public class OrderProcessorException : ApplicationException
  {
    private int sourceStage;

    public OrderProcessorException(string message, int exceptionSourceStage) : base(message)
    {
      sourceStage = exceptionSourceStage;
    }

    public int SourceStage
    {
      get
      {
        return sourceStage;
      }
    }
  }
}
