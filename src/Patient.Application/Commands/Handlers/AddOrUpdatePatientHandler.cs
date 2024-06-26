using MediatR;
using Patient.Application.DTO;
using Patient.Application.Services;

namespace Patient.Application.Commands.Handlers;

public sealed class AddOrUpdatePatientHandler : IRequestHandler<AddOrUpdatePatientCommand, bool>
{
    private readonly IPatientRepository repository;

    public AddOrUpdatePatientHandler(IPatientRepository repository) => this.repository = repository;
    public async Task<bool> Handle(AddOrUpdatePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = request.Patient.AsDomain(request.Id);

        if (await repository.ExistsAsync(patient.Name.Id))
        {
            await repository.UpdateAsync(patient);
            return true;
        }
        else
        {
            await repository.AddAsync(patient);
            return false;
        }
    }
}