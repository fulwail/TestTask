namespace TestTask.Dtos.Doctors;

public class DoctorListDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ThirdName { get; set; }
    public int CabinetNumber { get; set; }
    public string SpecializationName { get; set; }
    public int? SectorNumber { get; set; }
}