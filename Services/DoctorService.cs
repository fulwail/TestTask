using AutoMapper;
using TestTask.Dtos;
using TestTask.Dtos.Doctors;
using TestTask.Repositories;

namespace TestTask.Services;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _repository;
    private readonly IMapper _mapper;
    public DoctorService(IDoctorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Guid> CreateItem(CreateOrUpdateDoctor item)
    {
       return await _repository.CreateItem(item);
    }

    public async Task<DoctorDto?> UpdateItem(CreateOrUpdateDoctor item, Guid id)
    {
        var doctor =await _repository.UpdateItem(item,id);
        return _mapper.Map<DoctorDto>(doctor);
    }

    public async Task DeleteItem(Guid id)
    {
        await _repository.DeleteItem(id);
    }

    public async Task<IEnumerable<DoctorListDto>> GetItemList(FilterDto filter)
    {
        var doctors = await _repository.GetItemList(filter);
        return _mapper.Map<IEnumerable<DoctorListDto>>(doctors);
    }

    public async Task<DoctorDto?> GetItemById(Guid id)
    {
        var doctor = await _repository.GetItemById(id);
        return _mapper.Map<DoctorDto>(doctor);
    }
}