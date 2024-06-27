namespace Patient.Api.Exceptions;

public sealed class InvalidSearchDateException : ApiException
{
    internal InvalidSearchDateException(string date) : base($"Search date is invalid: '{date}'.") { }
}