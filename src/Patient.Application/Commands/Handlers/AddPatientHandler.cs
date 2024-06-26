using MediatR;
using Patient.Application.Exceptions;
using Patient.Application.Services;
using Patient.Application.DTO;

namespace Patient.Application.Commands.Handlers;

public sealed class AddPatientHandler : IRequestHandler<AddPatientCommand, Guid>
{
    private readonly IPatientRepository repository;

    public AddPatientHandler(IPatientRepository repository) => this.repository = repository;

    public async Task<Guid> Handle(AddPatientCommand command, CancellationToken cancellationToken)
    {
        var patient = command.Patient.AsDomain();

        if (await repository.ExistsAsync(patient.Name.Id))
        {
            throw new ResourceAlreadyExistsException(patient.Name.Id);
        }

        await repository.AddAsync(patient);

        return patient.Name.Id;
    }
}