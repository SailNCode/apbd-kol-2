using Kolos2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolos2.Controllers;


[Route("api/[controller]")]
[ApiController]
public class SomethingController : ControllerBase
{
    private readonly IService _service;
    public SomethingController(IService service)
    {
        _service = service;
    }

    // [HttpGet("{id}")]
    // public async Task<IActionResult> GetPatientDetails(int id)
    // {
    //     try
    //     {
    //         //PatientDetailsResponseDTO patientDetails = await _dbService.GetPatientDetails(id);
    //         return Ok(/*patientDetails*/);
    //     }
    //     catch (BadRequestException e)
    //     {
    //         return BadRequest(e.Message);
    //     }
    //     catch (NotFoundException e)
    //     {
    //         return NotFound(e.Message);
    //     }
    //     catch (ConflictException e)
    //     {
    //         return Conflict(e.Message);
    //     }
    //     catch (InternalServerException e)
    //     {
    //         return StatusCode(500, e.Message);
    //     }
    // }
}