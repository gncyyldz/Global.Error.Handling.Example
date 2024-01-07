using Microsoft.AspNetCore.Diagnostics;

namespace Global.Error.Handling.Example.New_Method
{
    public class ExceptionHandler(ILogger<ExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            string errorMessage = $"Bir hata oluştu. Hata mesajı :  {exception.Message}";
            logger.LogError(exception, errorMessage);

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(new
            {
                Title = "Server Error",
                Status = httpContext.Response.StatusCode,
                Message = errorMessage
            });

            return true;
        }
    }
}
