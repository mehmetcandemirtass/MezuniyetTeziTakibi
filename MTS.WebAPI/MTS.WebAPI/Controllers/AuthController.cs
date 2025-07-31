using Microsoft.AspNetCore.Mvc;
using MTS.Application.DTOs.Students;
using MTS.Application.DTOs.Advisors;
using MTS.Application.Interfaces.Services;
using MTS.Application.Services.Students;

namespace MTS.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IAdvisorService _advisorService;

        public AuthController(IStudentService studentService, IAdvisorService advisorService)
        {
            _studentService = studentService;
            _advisorService = advisorService;
        }

        [HttpPost("student/login")]
        public async Task<IActionResult> StudentLogin([FromBody] StudentLoginDto dto)
        {
            try
            {
                var student = await _studentService.AuthenticateAsync(dto.StudentNumber, dto.Password);

                return Ok(student);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message }); // 401 hatası mantıklı olur
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Sunucu hatası: " + ex.Message });
            }
        }


        // Danışman girişi  
        [HttpPost("advisor/login")]
        public async Task<IActionResult> AdvisorLogin([FromBody] AdvisorLoginDto dto)
        {
            try
            {
                var advisor = await _advisorService.AuthenticateAsync(dto.Email, dto.Password);

                return Ok(advisor);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message }); // 401 hatası mantıklı olur
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Sunucu hatası: " + ex.Message });
            }
        }
    }
}
