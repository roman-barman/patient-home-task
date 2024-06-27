using Patient.Application.Services;
using Patient.Infrastructure.Mongo.Documents;
using Patient.Infrastructure.Mongo.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Patient.Application.Searches;

namespace Patient.Infrastructure.Mongo.Repositories;

public sealed class PatientMongoRepository : IPatientRepository
{
    private readonly IMongoCollection<PatientDocument> patientsCollection;

    public PatientMongoRepository(IOptions<PatientMongoRepositorySetting> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionURI);
        var database = client.GetDatabase(settings.Value.DatabaseName);
        patientsCollection = database.GetCollection<PatientDocument>(settings.Value.CollectionName);
    }

    public async Task AddAsync(Core.Entities.Patient patient) => await patientsCollection.InsertOneAsync(patient.AsDocument());

    public async Task DeleteAsync(Guid id)
    {
        var filter = CreateFilterForId(id);

        await patientsCollection.DeleteOneAsync(filter);
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        var filter = CreateFilterForId(id);

        return await patientsCollection.CountDocumentsAsync(filter) != 0;
    }

    public async Task<Core.Entities.Patient?> GetAsync(Guid id)
    {
        var filter = CreateFilterForId(id);

        return (await patientsCollection.FindAsync(filter)).FirstOrDefault()?.AsDomain();
    }

    public async Task UpdateAsync(Core.Entities.Patient patient)
    {
        var filter = CreateFilterForId(patient.Name.Id);

        await patientsCollection.ReplaceOneAsync(filter, patient.AsDocument());
    }

    public async Task<IReadOnlyCollection<Core.Entities.Patient>> SearchByDate(SearchOperation operation, DateSearch date)
    {
        var filter = date.IsDateOnly ? CreateFilterForBirthDate(operation, date.GetDateOnly()) : CreateFilterForBirthDate(operation, date.GetDateTime());

        return (await patientsCollection.FindAsync(filter))
            .ToList()
            .Select(x => x.AsDomain())
            .ToList();
    }

    private static FilterDefinition<PatientDocument> CreateFilterForBirthDate(SearchOperation operation, DateOnly date) => operation switch
    {
        SearchOperation.Eq or SearchOperation.Ap => Builders<PatientDocument>.Filter.Gte(x => x.BirthDate, date.ToDateTime(TimeOnly.MinValue)) & Builders<PatientDocument>.Filter.Lt(x => x.BirthDate, date.AddDays(1).ToDateTime(TimeOnly.MinValue)),
        SearchOperation.Ne => Builders<PatientDocument>.Filter.Lt(x => x.BirthDate, date.ToDateTime(TimeOnly.MinValue)) | Builders<PatientDocument>.Filter.Gte(x => x.BirthDate, date.AddDays(1).ToDateTime(TimeOnly.MinValue)),
        SearchOperation.Lt or SearchOperation.Eb => Builders<PatientDocument>.Filter.Lt(x => x.BirthDate, date.ToDateTime(TimeOnly.MinValue)),
        SearchOperation.Gt or SearchOperation.Sa => Builders<PatientDocument>.Filter.Gte(x => x.BirthDate, date.AddDays(1).ToDateTime(TimeOnly.MinValue)),
        SearchOperation.Ge => Builders<PatientDocument>.Filter.Gte(x => x.BirthDate, date.ToDateTime(TimeOnly.MinValue)),
        SearchOperation.Le => Builders<PatientDocument>.Filter.Lte(x => x.BirthDate, date.ToDateTime(TimeOnly.MaxValue)),
        _ => throw new ArgumentOutOfRangeException(nameof(operation))
    };

    private static FilterDefinition<PatientDocument> CreateFilterForBirthDate(SearchOperation operation, DateTime date) => operation switch
    {
        SearchOperation.Eq or SearchOperation.Ap => Builders<PatientDocument>.Filter.Eq(x => x.BirthDate, date),
        SearchOperation.Ne => Builders<PatientDocument>.Filter.Ne(x => x.BirthDate, date),
        SearchOperation.Lt or SearchOperation.Eb => Builders<PatientDocument>.Filter.Lt(x => x.BirthDate, date),
        SearchOperation.Gt or SearchOperation.Sa => Builders<PatientDocument>.Filter.Gt(x => x.BirthDate, date),
        SearchOperation.Ge => Builders<PatientDocument>.Filter.Gte(x => x.BirthDate, date),
        SearchOperation.Le => Builders<PatientDocument>.Filter.Lte(x => x.BirthDate, date),
        _ => throw new ArgumentOutOfRangeException(nameof(operation))
    };

    private static FilterDefinition<PatientDocument> CreateFilterForId(Guid id) => Builders<PatientDocument>.Filter.Eq(x => x.Name.Id, id.ToString());
}