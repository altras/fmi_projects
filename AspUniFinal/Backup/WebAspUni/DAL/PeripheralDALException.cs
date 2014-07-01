using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebAspUni.DAL
{
    class PeripheralDALException : Exception
    {
        public PeripheralDALException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
}
