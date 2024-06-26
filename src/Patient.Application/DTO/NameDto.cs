namespace Patient.Application.DTO;

public sealed record NameDto
{
    public Guid? Id { get; set; }
    public string? Use { get; set; }
    public string? Family { get; set; }
    public IReadOnlyCollection<string>? Given { get; set; }
}