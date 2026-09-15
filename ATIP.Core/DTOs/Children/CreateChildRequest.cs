namespace ATIP.Core.DTOs.Children;

public class CreateChildRequest
{
    public string FirstName { get; set; } = string.Empty;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = string.Empty;

    public DateTime? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? State { get; set; }

    public string? Lga { get; set; }

    public string? SchoolName { get; set; }

    public string? ClassLevel { get; set; }

    public DateTime? DiscoveryDate { get; set; }

    public string? DiscoveryLocation { get; set; }

    public string? DiscoveryNotes { get; set; }
}