using TestTask.Dtos;
using TestTask.Dtos.Patients;
using TestTask.Models;

namespace TestTask.Repositories;

public interface IPatientRepository
{
    Task<Guid> CreateItem(CreateOrUpdatePatient item);
    Task<Patient?> UpdateItem(CreateOrUpdatePatient item, Guid id);

    Task DeleteItem(Guid id);
    Task<IEnumerable<Patient>> GetItemList(FilterDto filters);
    Task<Patient?> GetItemById(Guid id);
}