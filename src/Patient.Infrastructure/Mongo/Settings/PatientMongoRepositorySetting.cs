namespace Patient.Infrastructure.Mongo.Settings;

public sealed record PatientMongoRepositorySetting
{
    public string ConnectionURI { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string CollectionName { get; set; } = null!;
}