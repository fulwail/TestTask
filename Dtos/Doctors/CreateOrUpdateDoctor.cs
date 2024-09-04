namespace TestTask.Dtos.Doctors;

public class CreateOrUpdateDoctor
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ThirdName { get; set; }
    public Guid CabinetId { get; set; }
    public Guid SpecializationId { get; set; }
    public Guid? SectorId { get; set; }
}