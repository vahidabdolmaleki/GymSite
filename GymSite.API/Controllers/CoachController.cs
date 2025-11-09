using ApplicationService.DTOs;
using ApplicationService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymSite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        private readonly ICoachService _coachService;

        public CoachController(ICoachService coachService)
        {
            _coachService = coachService;
        }
        /// <summary>
        /// 📋 دریافت لیست همه مربیان
        /// </summary>
        [HttpGet("GetAll")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var result = await _coachService.GetAllAsync();
            return Ok(result);
        }

        /// <summary>
        /// 🔍 دریافت اطلاعات یک مربی بر اساس شناسه
        /// </summary>
        [HttpGet("GetById/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _coachService.GetByIdAsync(id);
            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        /// <summary>
        /// ➕ افزودن مربی جدید
        /// </summary>
        [HttpPost("Create")]
        //[Authorize(Roles = "Admin")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CoachCreateDto dto)
        {
            var result = await _coachService.CreateAsync(dto);
            return Ok(result);
        }

        /// <summary>
        /// ✏️ ویرایش اطلاعات مربی
        /// </summary>
        [HttpPut("Update")]
        //[Authorize(Roles = "Admin")]
        [AllowAnonymous]
        public async Task<IActionResult> Update([FromBody] CoachUpdateDto dto)
        {
            var result = await _coachService.UpdateAsync(dto);
            return Ok(result);
        }

        /// <summary>
        /// ❌ حذف مربی
        /// </summary>
        [HttpDelete("Delete/{id}")]
        //[Authorize(Roles = "Admin")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _coachService.DeleteAsync(id);
            return Ok(result);
        }
    }
}
