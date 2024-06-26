namespace Patient.Core.Exceptions;

public sealed class FamilyIsNullOrEmptyException : DomainException
{
    internal FamilyIsNullOrEmptyException() : base("Family is null or empty.") { }
}