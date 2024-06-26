using MediatR;
using Patient.Application.DTO;
using Patient.Application.Exceptions;
using Patient.Application.Services;

namespace Patient.Application.Queries.Handlers;

public sealed class GetPatientHandler : IRequestHandler<GetPatientQuery, PatientDTO>
{
    private readonly IPatientRepository repository;

    public GetPatientHandler(IPatientRepository repository) => this.repository = repository;
    public async Task<PatientDTO> Handle(GetPatientQuery query, CancellationToken cancellationToken)
    {
        var patient = await repository.GetAsync(query.Id);

        if (patient == null)
        {
            throw new PatientNotFoundException(query.Id);
        }

        return patient.AsDto();
    }
}