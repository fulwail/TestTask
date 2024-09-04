using Microsoft.AspNetCore.Mvc;
using TestTask.Dtos;
using TestTask.Dtos.Doctors;
using TestTask.Services;

namespace TestTask.Controllers;
[ApiController]
[Route("doctors")]
public class DoctorController: ControllerBase
{
    private readonly IDoctorService _services;

    public DoctorController(IDoctorService services)
    {
        _services = services;
    }

    /// <summary>
    /// Создает новый экземпляр доктора
    /// </summary>
    /// <response code="200">Ok</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server error</response>
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateDoctor([FromBody] CreateOrUpdateDoctor item)
    {
        var id=await _services.CreateItem(item);
        return Ok(id);
    }

    /// <summary>
    /// Обновляет данные у доктора по Id
    /// </summary>
    /// <response code="200">Ok</response>
    /// <response code="400">Bad Request</response>
    /// <response code="404">Not found</response>
    /// <response code="500">Internal Server error</response>
    [HttpPut("{id}")]
    public async Task<ActionResult<DoctorDto>> UpdateDoctorById(Guid id, [FromBody] CreateOrUpdateDoctor item)
    {
        var doctor = await _services.UpdateItem(item, id);
        if (doctor == null)
            return NotFound("Доктор не найден");
        
        return Ok();
    }

    /// <summary>
    /// Удаляет доктора по Id
    /// </summary>
    /// <response code="200">Ok</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server error</response>
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteDoctor(Guid id)
    {
        await _services.DeleteItem(id);
        return Ok();
    }

    /// <summary>
    /// Получает список всех докторов
    /// </summary>
    /// <response code="200">Ok</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server error</response>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DoctorListDto>>> GetDoctors([FromQuery] FilterDto dto)
    {
        var items = await _services.GetItemList(dto);
        return Ok(items);
    }

    /// <summary>
    /// Получает доктора по Id
    /// </summary>
    /// <response code="200">Ok</response>
    /// <response code="400">Bad Request</response>
    /// <response code="404">Not found</response>
    /// <response code="500">Internal Server error</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<DoctorDto>> GetDoctorById(Guid id)
    {
        var item = await _services.GetItemById(id);
        if (item == null)
            return NotFound("Доктор не найден");
        
        return Ok(item);
    }
}