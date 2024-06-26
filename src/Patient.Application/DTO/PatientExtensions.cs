using Patient.Core.ValueObjects;

namespace Patient.Application.DTO;

internal static class PatientExtensions
{
    internal static Core.Entities.Patient AsDomain(this PatientDTO patient)
        => new Core.Entities.Patient(patient.Name?.AsDomain(), Enum.TryParse<Gender>(patient.Gender, true, out var outGender) ? outGender : null, patient.BirthDate, patient.Active);

    internal static Core.Entities.Patient AsDomain(this PatientDTO patient, Guid id)
        => new Core.Entities.Patient(patient.Name?.AsDomain(id), Enum.TryParse<Gender>(patient.Gender, true, out var outGender) ? outGender : null, patient.BirthDate, patient.Active);

    internal static PatientDTO AsDto(this Core.Entities.Patient patient) => new PatientDTO
    {
        Name = patient.Name.AsDto(),
        Gender = patient.Gender.ToString(),
        BirthDate = patient.BirthDate,
        Active = patient.Active
    };
}