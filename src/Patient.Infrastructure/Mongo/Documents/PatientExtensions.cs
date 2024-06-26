using Patient.Core.ValueObjects;

namespace Patient.Infrastructure.Mongo.Documents;

internal static class PatientExtensions
{
    internal static PatientDocument AsDocument(this Core.Entities.Patient patient) => new PatientDocument
    {
        Name = patient.Name.AsDocument(),
        Gender = patient.Gender.ToString(),
        BirthDate = patient.BirthDate,
        Active = patient.Active
    };

    internal static Core.Entities.Patient AsDomain(this PatientDocument patient)
        => new Core.Entities.Patient(patient.Name.AsDomain(), (Gender)Enum.Parse(typeof(Gender), patient.Gender, true), patient.BirthDate, patient.Active);
}