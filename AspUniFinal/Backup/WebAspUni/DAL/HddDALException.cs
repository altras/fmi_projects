using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebAspUni.DAL
{
    class HddDALException : Exception
    {
        public HddDALException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
}
