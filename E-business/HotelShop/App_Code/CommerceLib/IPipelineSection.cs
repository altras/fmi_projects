namespace CommerceLib
{
  /// <summary>
  /// Standard interface for pipeline sections
  /// </summary>
  public interface IPipelineSection
  {
    void Process(OrderProcessor processor);
  }
}
