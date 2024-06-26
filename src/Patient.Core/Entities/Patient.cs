using Patient.Core.Exceptions;
using Patient.Core.ValueObjects;

namespace Patient.Core.Entities;

public sealed class Patient
{
    public Name Name { get; }
    public Gender Gender { get; }
    public DateTime BirthDate { get; }
    public bool Active { get; }

    public Patient(Name? name, Gender? gender, DateTime? birthdate, bool active)
    {
        Name = name ?? throw new NameIsNullException();
        Gender = gender ?? Gender.Unknown;
        BirthDate = birthdate ?? throw new BirthDateIsNullException();
        Active = active;
    }
}