namespace TestTask.Dtos.Patients;

public class PatientListDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ThirdName { get; set; }
    public string Address { get; set; }
    public DateOnly BirthDate { get; set; }
    public int SectorNumber { get; set; }
}