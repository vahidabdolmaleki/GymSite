using ApplicationService.DTOs.Student;
using ApplicationService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymSite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Coach")] // فقط ادمین یا مربی اجازه مدیریت شاگرد دارد
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        /// <summary>
        /// ثبت شاگرد جدید
        /// </summary>
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] StudentRegisterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _studentService.RegisterAsync(dto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        /// <summary>
        /// ویرایش اطلاعات شاگرد
        /// </summary>
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] StudentUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _studentService.UpdateAsync(dto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        /// <summary>
        /// دریافت لیست شاگردان (اختیاری: فیلتر بر اساس CoachId)
        /// </summary>
        [HttpGet("List")]
        [AllowAnonymous] // برای تست باز گذاشتیم، بعداً می‌تونیم محدود کنیم
        public async Task<IActionResult> GetAll([FromQuery] int? coachId)
        {
            var result = await _studentService.GetAllAsync(coachId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        /// <summary>
        /// غیرفعال‌سازی شاگرد
        /// </summary>
        [HttpDelete("Deactivate/{id}")]
        public async Task<IActionResult> Deactivate(int id)
        {
            var result = await _studentService.DeactivateAsync(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
