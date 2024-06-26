using Patient.Application.Services;
using Patient.Infrastructure.Mongo.Documents;
using Patient.Infrastructure.Mongo.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

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

    private static FilterDefinition<PatientDocument> CreateFilterForId(Guid id) => Builders<PatientDocument>.Filter.Eq("name._id", id.ToString());
}