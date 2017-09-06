using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTestApplication.Exceptions
{
    [Serializable]
    public class InvalidWordRangeArgumentException : HttpException
    {
        public InvalidWordRangeArgumentException(string message) : base(message)
        {

        }
    }
}