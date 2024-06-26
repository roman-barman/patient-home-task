namespace Patient.Application.Exceptions;

public sealed class PatientNotFoundException : Exception
{
    internal PatientNotFoundException(Guid id) : base($"Resource with id: {id} was not found.") { }
}