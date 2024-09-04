using TestTask.Enums;

namespace TestTask.Models;

public class Patient: Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ThirdName { get; set; }
    public string Address { get; set; }
    public DateTime BirthDate { get; set; }
    public GenderType Gender { get; set; }
    public Guid SectorId { get; set; }
    public Sector Sector { get; set; }
}