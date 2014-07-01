using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebAspUni.DAL
{
    class BoxSetDALException : Exception
    {
        public BoxSetDALException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
}
