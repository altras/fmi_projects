using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebAspUni.DAL
{
    class VideoCardDALException : Exception
    {
        public VideoCardDALException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
}
