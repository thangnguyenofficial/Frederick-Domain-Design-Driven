using System.Net;
using FrederickNguyen.DomainLayer.Exceptions;
using FrederickNguyen.WebApi.Infrastructure.ActionResults;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace FrederickNguyen.WebApi.Infrastructure.Filters
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment _env;
        private readonly ILogger<HttpGlobalExceptionFilter> _logger;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public HttpGlobalExceptionFilter(IHostingEnvironment env, ILogger<HttpGlobalExceptionFilter> logger)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            _env = env;
            _logger = logger;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public void OnException(ExceptionContext context)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        {
            _logger.LogError(new EventId(context.Exception.HResult), context.Exception, context.Exception.Message);
            if (context.Exception.GetType() == typeof(CustomerDomainException))
            {
                var json = new JsonErrorResponse
                {
                    Messages = new[] { context.Exception.Message }
                };

                // Result asigned to a result object but in destiny the response is empty. This is a known bug of .net core 1.1
                //It will be fixed in .net core 1.1.2. See https://github.com/aspnet/Mvc/issues/5594 for more information
                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                var json = new JsonErrorResponse
                {
                    Messages = new[] { "An error occur.Try it again." }
                };

                if (_env.IsDevelopment())
                {
                    json.DeveloperMessage = context.Exception;
                }

                // Result asigned to a result object but in destiny the response is empty. This is a known bug of .net core 1.1
                // It will be fixed in .net core 1.1.2. See https://github.com/aspnet/Mvc/issues/5594 for more information
                context.Result = new InternalServerErrorObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            context.ExceptionHandled = true;
        }

        private class JsonErrorResponse
        {
            /// <summary>
            /// Gets or sets the messages.
            /// </summary>
            /// <value>The messages.</value>
            public string[] Messages { get; set; }

            /// <summary>
            /// Gets or sets the developer message.
            /// </summary>
            /// <value>The developer message.</value>
            public object DeveloperMessage { get; set; }
        }
    }
}
