namespace Patient.Feeder.Models;

public sealed record Patient
{
    public Name Name { get; set; } = null!;
    public string Gender { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public bool Active { get; set; }
}