using AutoMapper;
using TestTask.Dtos.Patients;
using TestTask.Models;

namespace TestTask.Profiles;

public class PatientProfile: Profile
{
    public PatientProfile()
    {
        CreateMap<Patient, PatientDto>();
        CreateMap<Patient, PatientListDto>().ForMember(dest=>dest.SectorNumber,opt=>opt.MapFrom(src=>src.Sector.Number));
    }
}