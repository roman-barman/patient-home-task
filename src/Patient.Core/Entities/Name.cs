using Patient.Core.Exceptions;

namespace Patient.Core.Entities;

public sealed class Name
{
    public Guid Id { get; }
    public string? Use { get; }
    public string Family { get; }
    public IReadOnlyCollection<string>? Given { get; }

    public Name(Guid? id, string? family, string? use, IReadOnlyCollection<string>? given)
    {
        if (string.IsNullOrWhiteSpace(family))
        {
            throw new FamilyIsNullOrEmptyException();
        }

        Id = id.HasValue ? id.Value : Guid.NewGuid();
        Use = use;
        Family = family;
        Given = given;
    }
}