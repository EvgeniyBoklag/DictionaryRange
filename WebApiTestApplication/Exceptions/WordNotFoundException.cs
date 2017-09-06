using System;
using System.Web;

namespace WebApiTestApplication.Exceptions
{
    [Serializable]
    public class WordNotFoundException : HttpException
    {
        public WordNotFoundException(string message) : base(message)
        {
        }
    }
}