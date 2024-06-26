using Patient.Core.Entities;

namespace Patient.Infrastructure.Mongo.Documents;

internal static class NameExtensions
{
    internal static NameDocument AsDocument(this Name name) => new NameDocument
    {
        Id = name.Id.ToString(),
        Use = name.Use,
        Family = name.Family,
        Given = name.Given
    };

    internal static Name AsDomain(this NameDocument name)
        => new Name(Guid.Parse(name.Id), name.Family, name.Use, name.Given);
}