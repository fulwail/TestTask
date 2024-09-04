namespace TestTask.Dtos.Patients;

public class PatientDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ThirdName { get; set; }
    public string Address { get; set; }
    public DateOnly BirthDate { get; set; }
    public Guid SectorId { get; set; }
}