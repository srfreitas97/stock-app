
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using stock_app.Exceptions;
using stock_app.Models;

namespace stock_app.Middlewares
{

    public class ErrorMiddleware
    {
        private const string APPLICATION_JSON = "application/json";
        private readonly RequestDelegate next;

        public ErrorMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {

            if (exception is BadRequestException badRequestException)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
            else if(exception is ProductNotFoundException productNotFoundException)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
            }
            else{
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            }

            context.Response.ContentType = APPLICATION_JSON;

            await context.Response.WriteAsync(JsonConvert.SerializeObject(new BaseResponse()
            {
                Status = context.Response.StatusCode,
                Message = exception.Message
            },
            //setting serializer options to camel case to fit Http conventions
            new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }));
        }
    }

}