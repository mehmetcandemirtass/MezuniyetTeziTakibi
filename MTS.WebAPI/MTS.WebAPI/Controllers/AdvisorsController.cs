using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTS.Application.DTOs.Advisors;
using MTS.Application.DTOs.Students;
using MTS.Application.Interfaces.Services;
using System.Net.Mime;

namespace MTS.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class AdvisorsController : ControllerBase
    {
        private readonly IAdvisorService _advisorService;
        private readonly ILogger<AdvisorsController> _logger;

        public AdvisorsController(
            IAdvisorService advisorService,
            ILogger<AdvisorsController> logger)
        {
            _advisorService = advisorService;
            _logger = logger;
        }

        /// <summary>
        /// Tüm danışmanları listeler
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AdvisorDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var advisors = await _advisorService.GetAllAsync();
                return Ok(advisors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving advisors");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// ID'ye göre danışman getirir
        /// </summary>
        /// <param name="id">Danışman ID'si</param>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(AdvisorDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var advisor = await _advisorService.GetByIdAsync(id);
                return advisor == null ? NotFound() : Ok(advisor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving advisor with ID: {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Yeni danışman oluşturur
        /// </summary>
        /// <summary>
        /// Yeni danışman oluşturur
        /// </summary>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(AdvisorDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateAdvisorDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _advisorService.AddAsync(dto);
                return CreatedAtAction(
                    nameof(GetById),
                    new { id = result.Id },
                    result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating advisor");
                return StatusCode(500, "Internal server error");
            }
        }


        /// <summary>
        /// Danışman bilgilerini günceller
        /// </summary>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] UpdateAdvisorDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("ID mismatch");
            }

            try
            {
                await _advisorService.UpdateAsync(dto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating advisor with ID: {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Danışmanı siler
        /// </summary>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _advisorService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting advisor with ID: {id}");
                return StatusCode(500, "Internal server error");
            }
            [HttpGet("{advisorId}/students")]
            [ProducesResponseType(typeof(IEnumerable<StudentDto>), StatusCodes.Status200OK)]
             async Task<IActionResult> GetStudentsByAdvisorId(int advisorId)
            {
                try
                {
                    var students = await _advisorService.GetStudentsByAdvisorIdAsync(advisorId);
                    return Ok(students);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Danışmanın öğrencileri çekilemedi. ID: {advisorId}");
                    return StatusCode(500, "Internal server error");
                }
            }

        }
    }
}