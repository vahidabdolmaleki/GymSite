using ApplicationService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class WorkoutController : ControllerBase
{
    private readonly IWorkoutService _service;

    public WorkoutController(IWorkoutService service)
    {
        _service = service;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> Get(int id) => Ok(await _service.GetByIdAsync(id));

    [HttpPost]
    [Authorize(Roles = "Admin,Coach")]
    public async Task<IActionResult> Create([FromBody] WorkoutCreateDto dto) => Ok(await _service.CreateAsync(dto));

    [HttpPut]
    [Authorize(Roles = "Admin,Coach")]
    public async Task<IActionResult> Update([FromBody] WorkoutUpdateDto dto) => Ok(await _service.UpdateAsync(dto));

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin,Coach")]
    public async Task<IActionResult> Delete(int id) => Ok(await _service.DeleteAsync(id));
}
