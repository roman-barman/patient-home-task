using MediatR;
using Patient.Application.DTO;
using Patient.Application.Searches;

namespace Patient.Application.Queries;

public sealed class GetPatientByBirthDateQuery : IRequest<IReadOnlyCollection<PatientDTO>>
{
    internal SearchOperation Operation { get; }
    internal DateSearch Date { get; }

    public GetPatientByBirthDateQuery(SearchOperation operation, DateSearch date)
    {
        Operation = operation;
        Date = date;
    }
}