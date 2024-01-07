using Microsoft.AspNetCore.Diagnostics;

namespace Global.Error.Handling.Example.New_Method
{
    public class DivideByZeroExceptionHandler(ILogger<DivideByZeroExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not DivideByZeroException)
                return false;

            string errorMessage = $"Bir hata oluştu. Hata mesajı :  {exception.Message}";
            logger.LogError(exception, errorMessage);

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(new
            {
                Title = exception.GetType().ToString(),
                Status = httpContext.Response.StatusCode,
                Message = errorMessage
            });

            return true;
        }
    }
}
