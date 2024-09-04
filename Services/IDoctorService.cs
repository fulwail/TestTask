using TestTask.Dtos;
using TestTask.Dtos.Doctors;

namespace TestTask.Services;

public interface IDoctorService
{
    Task<Guid>  CreateItem(CreateOrUpdateDoctor item);

    Task<DoctorDto?> UpdateItem(CreateOrUpdateDoctor item, Guid id);

    Task DeleteItem(Guid id);

    Task<IEnumerable<DoctorListDto>> GetItemList(FilterDto dto);
    Task<DoctorDto?> GetItemById(Guid id);
}