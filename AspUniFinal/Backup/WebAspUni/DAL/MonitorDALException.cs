using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebAspUni.DAL
{
    class MonitorDALException : Exception
    {
        public MonitorDALException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
}
