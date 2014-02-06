using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityLib
{
  public class StringEncryptorException : Exception
  {
    public StringEncryptorException(string message)
      : base(message)
    {
    }
  }
}
