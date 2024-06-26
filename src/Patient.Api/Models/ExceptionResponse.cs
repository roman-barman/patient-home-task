namespace Patient.Api.Models;

public sealed class ExceptionResponse
{
    public string Message { get; }
    public int StatusCode { get; }

    internal ExceptionResponse(string message, int statusCode)
    {
        Message = message;
        StatusCode = statusCode;
    }
}