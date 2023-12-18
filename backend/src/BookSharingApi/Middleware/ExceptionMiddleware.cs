using BookSharing.Domain.CustomExceptions;
using BookSharingApi.DTO;

namespace BookSharingApi.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (BaseException ex)
        {
            httpContext.Response.StatusCode = 400;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(new ErrorDetails
                {
                    Code = ex.ErrorCode.ToString(),
                    Message = ex.Message
                }.ToString());
            
        }
        catch (Exception _)
        {
            httpContext.Response.StatusCode = 500;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(new ErrorDetails
            {
                Code = httpContext.Response.StatusCode.ToString(),
                Message = "Failed due to an internal server error. Please try again later."
            }.ToString()) ;
        }
    }
}

