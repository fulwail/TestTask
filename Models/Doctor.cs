namespace TestTask.Models;

public class Doctor:Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ThirdName { get; set; }
    public Guid CabinetId { get; set; }
    public Cabinet Cabinet { get; set; }
    public Guid SpecializationId { get; set; }
    public Specialization Specialization { get; set; }
    public Guid? SectorId { get; set; }
    public Sector? Sector { get; set; }
}