using Patient.Core.Entities;

namespace Patient.Application.DTO;

internal static class NameExtensions
{
    internal static Name AsDomain(this NameDto name) => new Name(name.Id, name.Family, name.Use, name.Given);

    internal static Name AsDomain(this NameDto name, Guid id) => new Name(id, name.Family, name.Use, name.Given);

    internal static NameDto AsDto(this Name name) => new NameDto
    {
        Id = name.Id,
        Family = name.Family,
        Use = name.Use,
        Given = name.Given
    };
}