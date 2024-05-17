using Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Api.GlobalException;

public class GlobalExceptionHandler : IExceptionHandler
{
    public  async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        (int statusCode, string errorMessage) = exception switch
        {
            InvalidRatingException => (StatusCodes.Status406NotAcceptable, "Rating must be between 1 and 5, Please provide correct number"),
            UserNotFoundException => (StatusCodes.Status404NotFound, "Cannot find user, check user credentials"),
            CourseNotFoundException => (StatusCodes.Status404NotFound, "Cannot find course, check course credentials"),
            _ => (500, "Error occured, Try again.")
        }; ; 

        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsJsonAsync(errorMessage);
        return true;
    }
}
