using TestTask.Dtos;
using TestTask.Dtos.Doctors;
using TestTask.Models;

namespace TestTask.Repositories;

public interface IDoctorRepository
{
    Task<Guid> CreateItem(CreateOrUpdateDoctor item);
    Task<Doctor?> UpdateItem(CreateOrUpdateDoctor item, Guid id);

    Task DeleteItem(Guid id);
    Task<IEnumerable<Doctor>> GetItemList(FilterDto filters);
    Task<Doctor?> GetItemById(Guid id);
}