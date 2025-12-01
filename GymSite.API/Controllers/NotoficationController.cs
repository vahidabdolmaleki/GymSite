using ApplicationService.DTOs;
using ApplicationService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class NotificationController : ControllerBase
{
    private readonly INotificationService _service;

    public NotificationController(INotificationService service)
    {
        _service = service;
    }

    [HttpPost]
    [AllowAnonymous]
    //[Authorize(Roles = "Admin,Coach")]
    public async Task<IActionResult> Send([FromBody] NotificationCreateDto dto)
    {
        return Ok(await _service.SendAsync(dto));
    }

    [HttpGet("User/{personId}")]
    [AllowAnonymous]
    //[Authorize]
    public async Task<IActionResult> GetForUser(int personId)
    {
        return Ok(await _service.GetForUserAsync(personId));
    }

    [HttpGet("UnreadCount/{personId}")]
    [AllowAnonymous]
    //[Authorize]
    public async Task<IActionResult> UnreadCount(int personId)
    {
        return Ok(await _service.GetUnreadCountAsync(personId));
    }

    [HttpPut("MarkRead/{id}")]
    [AllowAnonymous]
    //[Authorize]
    public async Task<IActionResult> MarkRead(int id)
    {
        return Ok(await _service.MarkAsReadAsync(id));
    }
    [HttpPost("TestPush")]
    public async Task<IActionResult> TestPush(string token)
    {
        var ok = await _service.SendPushAsync(token, "🔥 سلام", "سهراب جونم چطوره");
        return Ok(ok);
    }

}
