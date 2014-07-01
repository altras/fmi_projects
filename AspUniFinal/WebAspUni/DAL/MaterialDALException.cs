using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebAspUni.DAL
{
    class MaterialDALException : Exception
    {
        public MaterialDALException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
}
