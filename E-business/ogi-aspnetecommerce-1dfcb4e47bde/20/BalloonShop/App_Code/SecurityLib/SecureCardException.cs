using System;

namespace SecurityLib
{
  public class SecureCardException : Exception
  {
    public SecureCardException(string message)
      : base(message)
    {
    }
  }
}
