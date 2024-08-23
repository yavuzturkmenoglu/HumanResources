using System.Diagnostics;

namespace HumanResources.Api.Utility.Middlewares
{
    public class RequestLoggerMiddleware
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;

        public RequestLoggerMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            _logger.LogInformation("Request started: {protocol} {method} {path}", httpContext.Request.Protocol, httpContext.Request.Method, httpContext.Request.Path);

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            await _next(httpContext);

            stopwatch.Stop();
            _logger.LogInformation("Request ended: {protocol} {method} {path}, responded {statusCode} in {time} ms", httpContext.Request.Protocol, httpContext.Request.Method, httpContext.Request.Path, httpContext.Response.StatusCode, stopwatch.ElapsedMilliseconds);
        }

    }
}



