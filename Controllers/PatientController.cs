using Microsoft.AspNetCore.Mvc;
using TestTask.Dtos;
using TestTask.Dtos.Patients;
using TestTask.Services;

namespace TestTask.Controllers;

[ApiController]
[Route("patients")]
public class PatientController : ControllerBase
{
    private readonly IPatientService _services;

    public PatientController(IPatientService services)
    {
        _services = services;
    }

    /// <summary>
    /// Создает новый экземпляр пациента
    /// </summary>
    /// <response code="200">Ok</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server error</response>
    [HttpPost]
    public async Task<ActionResult<Guid>> CreatePatient([FromBody] CreateOrUpdatePatient item)
    {
       var id= await _services.CreateItem(item);
        return Ok(id);
    }

    /// <summary>
    /// Обновляет данные у пациента по Id
    /// </summary>
    /// <response code="200">Ok</response>
    /// <response code="400">Bad Request</response>
    /// <response code="404">Not found</response>
    /// <response code="500">Internal Server error</response>
    [HttpPut("{id}")]
    public async Task<ActionResult<PatientDto>> UpdatePatientById(Guid id, [FromBody] CreateOrUpdatePatient item)
    {
        var pacient = await _services.UpdateItem(item, id);
        if (pacient == null)
            return NotFound("Пациент не найден");
        
        return Ok(pacient);
    }

    /// <summary>
    /// Удаляет пациента по Id
    /// </summary>
    /// <response code="200">Ok</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server error</response>
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePatient(Guid id)
    {
        await _services.DeleteItem(id);
        return Ok();
    }

    /// <summary>
    /// Получает список всех пациентов
    /// </summary>
    /// <response code="200">Ok</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server error</response>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PatientListDto>>> GetPatients([FromQuery] FilterDto dto)
    {
        var items = await _services.GetItemList(dto);
        return Ok(items);
    }

    /// <summary>
    /// Получает пациента по Id
    /// </summary>
    /// <response code="200">Ok</response>
    /// <response code="400">Bad Request</response>
    /// <response code="404">Not found</response>
    /// <response code="500">Internal Server error</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<PatientDto>> GetPatientById(Guid id)
    {
        var item = await _services.GetItemById(id);
        if (item == null)
            return NotFound("Пациент не найден");
        
        return Ok(item);
    }
}