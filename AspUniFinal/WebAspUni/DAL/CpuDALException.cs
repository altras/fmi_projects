using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebAspUni.DAL
{
    class CpuDALException : Exception
    {
        public CpuDALException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
}
