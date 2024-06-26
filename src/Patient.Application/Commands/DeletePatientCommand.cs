using MediatR;

namespace Patient.Application.Commands;

public sealed class DeletePatientCommand : IRequest
{
    internal Guid Id { get; }

    public DeletePatientCommand(Guid id) => Id = id;
}