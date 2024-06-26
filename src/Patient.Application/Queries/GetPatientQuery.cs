using MediatR;
using Patient.Application.DTO;

namespace Patient.Application.Queries;

public sealed class GetPatientQuery : IRequest<PatientDTO>
{
    internal Guid Id { get; }

    public GetPatientQuery(Guid id) => Id = id;
}