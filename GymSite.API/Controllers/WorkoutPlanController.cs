using ApplicationService.DTOs.WorkoutPlan;
using ApplicationService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutPlanController : ControllerBase
    {
        private readonly IWorkoutPlanService _service;

        public WorkoutPlanController(IWorkoutPlanService service)
        {
            _service = service;
        }

        // =========================================================
        // ✔ ایجاد برنامه جدید
        // =========================================================
        [HttpPost]
        //[Authorize(Roles = "Coach,Admin")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] WorkoutPlanCreateDto dto)
        {
            var result = await _service.CreateWorkoutPlanAsync(dto);
            return Ok(result);
        }

        // =========================================================
        // ✔ اضافه کردن آیتم به برنامه
        // =========================================================
        [HttpPost("AddItem")]
        //[Authorize(Roles = "Coach,Admin")]
        [AllowAnonymous]

        public async Task<IActionResult> AddItem([FromBody] WorkoutPlanItemCreateDto dto)
        {
            var result = await _service.AddItemAsync(dto);
            return Ok(result);
        }

        // =========================================================
        // ✔ حذف یک آیتم از برنامه
        // =========================================================
        [HttpDelete("Item/{itemId}")]
        //[Authorize(Roles = "Coach,Admin")]
        [AllowAnonymous]

        public async Task<IActionResult> RemoveItem(int itemId)
        {
            var result = await _service.RemoveItemAsync(itemId);
            return Ok(result);
        }

        // =========================================================
        // ✔ حذف کل برنامه تمرینی
        // =========================================================
        [HttpDelete("{planId}")]
        //[Authorize(Roles = "Coach,Admin")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int planId)
        {
            var result = await _service.DeleteWorkoutPlanAsync(planId);
            return Ok(result);
        }

        // =========================================================
        // ✔ دریافت برنامه یک دانشجو (بر اساس PersonId)
        // =========================================================
        [HttpGet("Student/{studentId}")]
        //[Authorize]
        [AllowAnonymous]
        public async Task<IActionResult> GetByStudent(int studentId)
        {
            var result = await _service.GetWorkoutPlansByStudentAsync(studentId);
            return Ok(result);
        }

        // =========================================================
        // ✔ دریافت جزئیات یک برنامه تمرینی
        // =========================================================
        [HttpGet("{planId}")]
        //[Authorize]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int planId)
        {
            var result = await _service.GetByIdAsync(planId);
            return Ok(result);
        }
    }
}
