using MediatR;
using Patient.Application.DTO;

namespace Patient.Application.Commands;

public sealed class AddPatientCommand : IRequest<Guid>
{
    internal PatientDTO Patient { get; }

    public AddPatientCommand(PatientDTO patient) => Patient = patient;
}