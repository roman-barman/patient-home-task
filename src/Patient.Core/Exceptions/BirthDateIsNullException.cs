namespace Patient.Core.Exceptions;

public sealed class BirthDateIsNullException : DomainException
{
    internal BirthDateIsNullException() : base("Birth date is null.") { }
}