using AutoMapper;
using TestTask.Dtos.Doctors;
using TestTask.Models;

namespace TestTask.Profiles;

public class DoctorProfile: Profile
{
    public DoctorProfile()
    {
        CreateMap<Doctor, DoctorDto>();
        CreateMap<Doctor, DoctorListDto>()
            .ForMember(dest=>dest.SectorNumber,opt=>opt.MapFrom(src=>src.Sector.Number))
            .ForMember(dest=>dest.CabinetNumber,opt=>opt.MapFrom(src=>src.Cabinet.Number))
            .ForMember(dest=>dest.SpecializationName,opt=>opt.MapFrom(src=>src.Specialization.Name));
    }
}