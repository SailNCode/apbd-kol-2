using Kolos2.DTOs.Request;
using Kolos2.Exceptions;
using Kolos2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolos2.Controllers;

[Route("api/track-races")]
[ApiController]
public class TrackRacesControllr : ControllerBase
{
    private readonly IService _service;
    public TrackRacesControllr(IService service)
    {
        _service = service;
    }

    [HttpPost("participants")]
    public async Task<IActionResult> AddParticipantToRace(AssignRacerRequestDTO assignRacerRequestDTO)
    {
        try
        {
            await _service.AddRacersToRaces(assignRacerRequestDTO);
            return NoContent();
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