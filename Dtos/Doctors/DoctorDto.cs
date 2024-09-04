namespace TestTask.Dtos.Doctors;

public class DoctorDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ThirdName { get; set; }
    public Guid CabinetId { get; set; }
    public Guid SpecializationId { get; set; }
    public Guid? SectorId { get; set; }
}