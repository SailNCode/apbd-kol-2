using Kolos2.DTOs.Response;
using Kolos2.Exceptions;
using Kolos2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolos2.Controllers;


[Route("api/[controller]")]
[ApiController]
public class RacersController : ControllerBase
{
    private readonly IService _service;
    public RacersController(IService service)
    {
        _service = service;
    }

    [HttpGet("{id}/participations")]
    public async Task<IActionResult> GetRacersDetails(int id)
    {
        try
        {
            RacerParticipationResponseDTO racerParticipationResponseDto =
                await _service.GetRacerParticipationInfo(id);
            return Ok(racerParticipationResponseDto);
        }
        catch (BadRequestException e)
        {
            return BadRequest(e.Message);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ConflictException e)
        {
            return Conflict(e.Message);
        }
        catch (InternalServerException e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
}