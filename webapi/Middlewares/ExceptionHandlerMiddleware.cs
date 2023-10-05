using ImageStorage.BLL.Exceptions;
using ImageStorage.BLL.Exeptions;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception ex)
        {
            switch (ex.GetType())
            {
                case Type exType when 
                exType == typeof(AccountAlreadyExistsException) ||
                exType == typeof(AccountDoesNotExistException) ||
                exType == typeof(AccountLoginFailedException) ||
                exType == typeof(AccountUsesGoogleAuthException):

                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync(ex.Message);

                    _logger.Log(LogLevel.Error, 1, exType + ex.Message);
                    break;

                case Type exType when exType == typeof(NullReferenceException):
                    context.Response.StatusCode = 400;
                    _logger.Log(LogLevel.Critical, 1, exType + ex.Message);
                    break;

                default:
                    _logger.Log(LogLevel.Critical, ex.Message);
                    break;
            }
        }
    }
}