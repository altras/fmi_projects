using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebAspUni.DAL
{
    class ConfigurationDALException : Exception
    {
        public ConfigurationDALException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
}
