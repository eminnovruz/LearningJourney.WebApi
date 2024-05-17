using Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;

namespace Api.GlobalException;

public class GlobalExceptionHandler : IExceptionHandler
{
    public  async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        (int statusCode, string errorMessage) = exception switch
        {
            InvalidRatingException => (StatusCodes.Status404NotFound, "Rating must be between 1 and 5, Please provide correct number."),
            UserNotFoundException => (StatusCodes.Status404NotFound, "Cannot find user, check user credentials."),
            CourseNotFoundException => (StatusCodes.Status404NotFound, "Cannot find course, check course credentials."),
            WrongPasswordException => (StatusCodes.Status404NotFound, "Wrong password, check your password and try again."),
            EmailUsedException => (StatusCodes.Status404NotFound, "There is an account related with this email, try different email."),
            BannedUserAttempException => (StatusCodes.Status404NotFound, "Banned account attemp"),
            _ => (500, "Error occured, Try again.")
        }; 

        Log.Error(errorMessage);
        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsJsonAsync(errorMessage);
        return true;
    }
}
