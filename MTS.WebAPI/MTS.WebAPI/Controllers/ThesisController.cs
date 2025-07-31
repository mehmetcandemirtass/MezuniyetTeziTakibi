using Microsoft.AspNetCore.Mvc;
using MTS.Application.DTOs.Theses;
using MTS.Application.Interfaces;
using MTS.Application.Interfaces.Services;
using System.Net.Mime;

[ApiController]
[Route("api/theses")]
[Produces(MediaTypeNames.Application.Json)]
public class ThesesController : ControllerBase
{
    private readonly IThesisService _thesisService;
    private readonly ILogger<ThesesController> _logger;

    public ThesesController(
        IThesisService thesisService,
        ILogger<ThesesController> logger)
    {
        _thesisService = thesisService;
        _logger = logger;
    }

    /// <summary>
    /// Öğrenci tez önerisi gönderir
    /// </summary>
    [HttpPost("proposals")]
    [ProducesResponseType(typeof(ThesisDto), StatusCodes.Status201Created)]

    

    private object GetThesisDetails()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Danışman tez durumunu günceller
    /// </summary>
    [HttpPatch("{id}/status")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateStatus(
        int id,
        [FromBody] UpdateThesisStatusDto dto)
    {
        try
        {
            await _thesisService.UpdateStatusAsync(id, dto);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { ex.Message });
        }
    }

    /// <summary>
    /// Jüri üyelerini atar
    /// </summary>
    [HttpPost("{id}/assign-jury")]
    public async Task<IActionResult> AssignJury(
        int id,
        [FromBody] AssignJuryDto dto)
    {
        try
        {
            await _thesisService.AssignJuryAsync(id, dto);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error assigning jury for thesis {id}");
            return StatusCode(500, new { Error = "Jüri atanamadı" });
        }
    }
}