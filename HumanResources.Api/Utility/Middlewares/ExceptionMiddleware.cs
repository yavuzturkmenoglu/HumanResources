using FluentValidation;
using HumanResources.Data.Internal.Response;
using HumanResources.Data.Internal.Response.Enums;
using System.Net;
using System.Text.Json;

namespace HumanResources.Api.Utility.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var errorCode = ErrorCode.GenericError;
            switch (exception)
            {
                case UnauthorizedAccessException:
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;

                case ValidationException:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorCode = ErrorCode.NotValid;

                    break;

                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.ContentType = "application/json";
            _logger.LogError(exception, "An unhandled error occured");

            await context.Response.WriteAsync(JsonSerializer.Serialize(Result<object>.CreateErrorResult(errorCode)));
        }
    }
}