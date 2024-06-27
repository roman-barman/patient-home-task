namespace Patient.Feeder.Models;

public sealed record Name
{
    public Guid? Id { get; set; }
    public string? Use { get; set; }
    public string Family { get; set; } = null!;
    public IReadOnlyCollection<string>? Given { get; set; }
}