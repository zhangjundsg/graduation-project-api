using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Sys.Common;
using Sys.Model;
using System.Threading.Tasks;

namespace Sys.CoreApi.Filter
{
    public class SystemExceptionFilter : IAsyncExceptionFilter
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {
            if (context.ExceptionHandled == false)
            {
                context.Result = new ContentResult
                {
                    Content = JsonConvert.SerializeObject(new { Code = ResponseCode.CodeError, Msg = context.Exception.Message }),
                    StatusCode = StatusCodes.Status200OK,
                    ContentType = "application/json;charset=utf-8"
                };
                NLogHelp.ErrorLog(context.Exception.Message, context.Exception);
            }
            context.ExceptionHandled = true;
            return Task.CompletedTask;
        }
    }
}
