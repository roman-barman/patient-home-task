using MediatR;
using Patient.Application.DTO;
using Patient.Application.Services;

namespace Patient.Application.Queries.Handlers;

public sealed class GetPatientByBirthDateHandler : IRequestHandler<GetPatientByBirthDateQuery, IReadOnlyCollection<PatientDTO>>
{
    private readonly IPatientRepository repository;

    public GetPatientByBirthDateHandler(IPatientRepository repository) => this.repository = repository;

    public async Task<IReadOnlyCollection<PatientDTO>> Handle(GetPatientByBirthDateQuery query, CancellationToken cancellationToken)
    {
        return (await repository.SearchByDate(query.Operation, query.Date))
            .Select(x => x.AsDto())
            .ToList();
    }
}