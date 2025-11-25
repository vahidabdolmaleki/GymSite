using ApplicationService.DTOs.UserMemberShip;
using ApplicationService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;

[Route("api/[controller]")]
[ApiController]
public class MembershipController : ControllerBase
{
    private readonly IUserMembershipService _service;

    public MembershipController(IUserMembershipService service)
    {
        _service = service;
    }

    [HttpPost]
    [AllowAnonymous]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromBody] UserMembershipCreateDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        return Ok(result);
    }

    [HttpGet("person/{personId}")]
    [AllowAnonymous]
    //[Authorize]
    public async Task<IActionResult> GetForPerson(int personId)
    {
        var result = await _service.GetForPersonAsync(personId);
        return Ok(result);
    }

    [HttpGet]
    [AllowAnonymous]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }
}
