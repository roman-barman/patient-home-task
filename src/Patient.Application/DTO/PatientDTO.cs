namespace Patient.Application.DTO;

public sealed record PatientDTO
{
    public NameDto? Name { get; set; }
    public string? Gender { get; set; }
    public DateTime? BirthDate { get; set; }
    public bool Active { get; set; }
}