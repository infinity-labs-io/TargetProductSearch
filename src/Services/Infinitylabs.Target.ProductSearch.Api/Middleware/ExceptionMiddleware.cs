using System;
using System.Net;
using System.Threading.Tasks;
using InfinityLabs.Target.ProductSearch.Api.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace InfinityLabs.Target.ProductSearch.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            if (exception is NotFoundException)
            {
                response.StatusCode = StatusCodes.Status404NotFound;
                response.ContentType = "application/json";
                var data = JsonConvert.SerializeObject(new {
                    message = exception.Message
                });
                await response.WriteAsync(data);
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}