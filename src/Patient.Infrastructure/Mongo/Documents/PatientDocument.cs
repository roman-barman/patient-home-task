using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Patient.Infrastructure.Mongo.Documents;

[BsonIgnoreExtraElements]
public sealed class PatientDocument
{
    [BsonElement("name")]
    public NameDocument Name { get; set; } = null!;

    [BsonElement("gender")]
    public string Gender { get; set; } = null!;

    [BsonElement("birthDate")]
    [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
    public DateTime BirthDate { get; set; }

    [BsonElement("active")]
    public bool Active { get; set; }
}