using LegoApi.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LegoApi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;
        private readonly IHostEnvironment env;

        public ExceptionMiddleware(RequestDelegate next,
                    ILogger<ExceptionMiddleware> logger,
                    IHostEnvironment env)
        {
            this.next = next;
            this.logger = logger;
            this.env = env;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch(Exception ex)
            {
                ApiError response;
                HttpStatusCode statuscode = HttpStatusCode.InternalServerError;
                if (env.IsDevelopment())
                {
                    response = new ApiError((int)statuscode, ex.Message, ex.StackTrace.ToString());
                }
                else
                {
                    response = new ApiError((int)statuscode, ex.Message);
                }
                logger.LogError(ex, ex.Message);

                context.Response.StatusCode = (int)statuscode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(response.ToString());
            }
        }
    }
}
