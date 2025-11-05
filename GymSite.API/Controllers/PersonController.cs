
using ApplicationService.DTOs.Person;
using ApplicationService.DTOs.Token;
using ApplicationService.Interfaces;
using Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymSite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly ILogger<PersonController> _logger;

        public PersonController(IPersonService personService, ILogger<PersonController> logger)
        {
            _personService = personService;
            _logger = logger;
        }
        // ✅ دریافت تمام کاربران
        [HttpGet]
        [Authorize(Roles = "Admin,Trainer")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _personService.GetAllAsync();
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }
        // ✅ دریافت کاربر براساس شناسه
        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _personService.GetByIdAsync(id);
            if (!result.IsSuccess)
                return NotFound(result.Message);

            return Ok(result);
        }
        [HttpPost("RefreshToken")]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto dto)
        {
            var result = await _personService.RefreshTokenAsync(dto);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        //✅ (Login) ورود کاربر
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            var result = await _personService.LoginAsync(dto);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
        // ✅ بروزرسانی اطلاعات کاربر
        [HttpPut("{id:int}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] PersonUpdateDto dto)
        {
            if (id != dto.Id)
                return BadRequest(ExceptionMessage.UserIdDoesNotMatch);

            var result = await _personService.UpdateAsync(dto);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }
        // ✅ حذف کاربر
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _personService.DeleteAsync(id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }
        // ✅ ثبت کاربر
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] PersonRegisterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _personService.RegisterAsync(dto);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }
        [HttpPost("forgot-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
        {
            var result = await _personService.ForgotPasswordAsync(dto);
            return Ok(result);
        }

        [HttpPost("verify-code")]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyCode([FromBody] VerifyCodeDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _personService.VerifyCodeAsync(dto);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost("reset-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            var result = await _personService.ResetPasswordAsync(dto);
            return Ok(result);
        }
        [Authorize]
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout([FromBody] LogoutRequestDto dto)
        {
            var result = await _personService.LogoutAsync(dto.AccessToken);
            return Ok(result);
        }


    }
}
