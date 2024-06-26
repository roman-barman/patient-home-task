using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Patient.Infrastructure.Mongo.Documents;

[BsonIgnoreExtraElements]
public sealed class NameDocument
{
    [BsonId]
    public string Id { get; set; } = null!;

    [BsonElement("use")]
    [BsonIgnoreIfNull]
    public string? Use { get; set; }

    [BsonElement("family")]
    public string Family { get; set; } = null!;

    [BsonElement("given")]
    [BsonIgnoreIfNull]
    public IReadOnlyCollection<string>? Given { get; set; }
}