namespace Patient.Api.Exceptions;

public sealed class InvalidSearchOperationException : ApiException
{
    internal InvalidSearchOperationException(string operation) : base($"Search opearation is invalid: '{operation}'.") { }
}