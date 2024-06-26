namespace Patient.Application.Services;

public interface IPatientRepository
{
    Task<Core.Entities.Patient?> GetAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
    Task AddAsync(Core.Entities.Patient patient);
    Task UpdateAsync(Core.Entities.Patient patient);
    Task DeleteAsync(Guid id);
}