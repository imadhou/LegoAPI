using LegoApi.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Data.SqlClient;

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
                string message;
                var exceptionType = ex.GetType();

                if(exceptionType == typeof(InUseException))
                {
                    statuscode = HttpStatusCode.BadRequest;
                    //replace ex.Message
                    message = ex.Message;
                }

                if(exceptionType == typeof(RequiredFieldNotFoundException))
                {
                    statuscode = HttpStatusCode.BadRequest;
                    //replace ex.Message
                    message = ex.Message;
                }

                if(exceptionType == typeof(RessourceNotFoundException))
                {
                    statuscode = HttpStatusCode.NotFound;
                    //replace ex.Message
                    message = ex.Message;
                }

                if(exceptionType == typeof(LoginException))
                {
                    statuscode = HttpStatusCode.Forbidden;
                    //replace ex.Message
                    message = ex.Message;
                }

                if (env.IsDevelopment())
                {
                    response = new ApiError((int)statuscode, ex.Message, ex.StackTrace.ToString());
                }
                else
                {
                    response = new ApiError((int)statuscode, ex.Message);
                }
                //logger.LogError(ex.InnerException, ex.InnerException.Message);

                context.Response.StatusCode = (int)statuscode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(response.ToString());
            }
        }
    }
}
