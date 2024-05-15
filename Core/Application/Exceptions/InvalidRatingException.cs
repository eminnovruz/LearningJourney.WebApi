namespace Application.Exceptions;

public class InvalidRatingException : Exception
{
    public InvalidRatingException(string? message) : base(message)
    {
    }

    public InvalidRatingException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
