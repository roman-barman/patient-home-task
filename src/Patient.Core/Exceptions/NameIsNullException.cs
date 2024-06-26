namespace Patient.Core.Exceptions;

public sealed class NameIsNullException : DomainException
{
    internal NameIsNullException() : base("Name is null.") { }
}