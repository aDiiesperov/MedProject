using MedProject.Shared.Exceptions;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace MedProject.Web.Filters
{
    public class MedExceptionFilter: ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
           if(context.Exception is MedException exception)
            {
                context.Response = context.Request.CreateErrorResponse((HttpStatusCode)exception.StatusCode, exception.Message);
            }
        }
    }
}