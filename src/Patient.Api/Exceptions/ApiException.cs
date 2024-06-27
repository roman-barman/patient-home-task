namespace Patient.Api.Exceptions;

public class ApiException : Exception
{
    protected ApiException(string message) : base(message) { }
}