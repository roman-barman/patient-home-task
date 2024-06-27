namespace Patient.Api.Exceptions;

public sealed class InvalidSearchStringException : ApiException
{
    internal InvalidSearchStringException() : base("Search string is invalid.") { }
}