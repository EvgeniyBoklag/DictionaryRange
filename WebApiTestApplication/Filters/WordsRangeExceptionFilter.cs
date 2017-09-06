using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using WebApiTestApplication.Exceptions;

namespace WebApiTestApplication.Filters
{
    public class WordsRangeExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is WordNotFoundException || context.Exception is InvalidWordRangeArgumentException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(context.Exception.Message)
                };
            }
            else
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}