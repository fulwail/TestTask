namespace TestTask.Dtos.Patients;

public class CreateOrUpdatePatient
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ThirdName { get; set; }
    public string Address { get; set; }
    public DateTime BirthDate { get; set; }
    public Guid SectorId { get; set; }
}