using TestTask.Dtos;
using TestTask.Dtos.Patients;

namespace TestTask.Services;

public interface IPatientService
{
    Task<Guid>  CreateItem(CreateOrUpdatePatient item);

    Task<PatientDto?> UpdateItem(CreateOrUpdatePatient item, Guid id);

    Task DeleteItem(Guid id);

    Task<IEnumerable<PatientListDto>> GetItemList(FilterDto dto);
    Task<PatientDto?> GetItemById(Guid id);
}