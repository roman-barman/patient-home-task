namespace Patient.Api.Exceptions;

public sealed class SearchStringIsNullOrEmptyException : ApiException
{
    internal SearchStringIsNullOrEmptyException() : base("Search string is null or empty.") { }
}