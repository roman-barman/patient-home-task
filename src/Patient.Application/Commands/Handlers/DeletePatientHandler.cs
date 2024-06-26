using MediatR;
using Patient.Application.Exceptions;
using Patient.Application.Services;

namespace Patient.Application.Commands.Handlers;

public sealed class DeletePatientHandler : IRequestHandler<DeletePatientCommand>
{
    private readonly IPatientRepository repository;

    public DeletePatientHandler(IPatientRepository repository) => this.repository = repository;

    public async Task Handle(DeletePatientCommand command, CancellationToken cancellationToken)
    {
        if (!await repository.ExistsAsync(command.Id))
        {
            throw new PatientNotFoundException(command.Id);
        }

        await repository.DeleteAsync(command.Id);
    }
}