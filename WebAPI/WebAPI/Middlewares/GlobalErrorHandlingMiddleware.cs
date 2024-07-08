using System.Net;
using System.Text.Json;

namespace WebAPI.Middlewares
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public GlobalErrorHandlingMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode;
            string stackTrace = string.Empty;
            string message = string.Empty;
            var exceptionType = exception.GetType();

            if (exceptionType == typeof(DataException))
            {
                message = exception.Message;
                statusCode = HttpStatusCode.BadRequest;
                stackTrace = exception.StackTrace;
            }
            else
            {
                message = exception.Message;
                statusCode = HttpStatusCode.InternalServerError;
                stackTrace = exception.StackTrace;
            }

            var result = JsonSerializer.Serialize(new { statusCode, message, stackTrace });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(result);
        }
    }
}
