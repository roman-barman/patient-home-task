namespace Patient.Application.Exceptions;

public sealed class ResourceAlreadyExistsException : Exception
{
    internal ResourceAlreadyExistsException(Guid id) : base($"Resource with id: {id} already exists.") { }
}