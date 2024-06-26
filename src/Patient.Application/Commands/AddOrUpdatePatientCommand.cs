using MediatR;
using Patient.Application.DTO;

namespace Patient.Application.Commands;

public sealed class AddOrUpdatePatientCommand : IRequest<bool>
{
    internal PatientDTO Patient { get; }
    internal Guid Id { get; }

    public AddOrUpdatePatientCommand(PatientDTO patient, Guid id)
    {
        Patient = patient;
        Id = id;
    }
}