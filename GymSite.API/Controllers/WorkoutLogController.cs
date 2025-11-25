using ApplicationService.DTOs.WorkoutLog;
using ApplicationService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class WorkoutLogController : ControllerBase
{    
    private readonly IWorkoutLogService _service;

    public WorkoutLogController(IWorkoutLogService service)
    {
        _service = service;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] WorkoutLogCreateDto dto)
    {
        return Ok(await _service.CreateAsync(dto));
    }

    [HttpGet("Person/{personId}")]
    [Authorize]
    public async Task<IActionResult> GetByPerson(int personId)
    {
        return Ok(await _service.GetLogsForPersonAsync(personId));
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Coach,Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _service.DeleteAsync(id));
    }
}
