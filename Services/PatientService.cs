using AutoMapper;
using TestTask.Dtos;
using TestTask.Dtos.Patients;
using TestTask.Repositories;

namespace TestTask.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _repository;
    private readonly IMapper _mapper;
    public PatientService(IPatientRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Guid> CreateItem(CreateOrUpdatePatient item)
    {
       return await _repository.CreateItem(item);
    }

    public async Task<PatientDto?> UpdateItem(CreateOrUpdatePatient item, Guid id)
    {
        var patient =await _repository.UpdateItem(item,id);
        return _mapper.Map<PatientDto>(patient);
    }

    public async Task DeleteItem(Guid id)
    {
        await _repository.DeleteItem(id);
    }

    public async Task<IEnumerable<PatientListDto>> GetItemList(FilterDto filter)
    {
        var patients = await _repository.GetItemList(filter);
        return _mapper.Map<IEnumerable<PatientListDto>>(patients);
    }

    public async Task<PatientDto?> GetItemById(Guid id)
    {
        var patient = await _repository.GetItemById(id);
        return _mapper.Map<PatientDto>(patient);
    }
}