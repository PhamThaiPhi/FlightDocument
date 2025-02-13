using Intern_Alta.Data;
using Intern_Alta.Models;
using Intern_Alta.Services.Flights;
using Microsoft.AspNetCore.Mvc;

namespace Intern_Alta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;

        
        public FlightController(IFlightService flightService)
        {
            _flightService = flightService ?? throw new ArgumentNullException(nameof(flightService));
        }

     
        [HttpGet]
        public IActionResult GetAll()
        {
            var flights = _flightService.GetAllFlights();
            return Ok(flights);
        }

      
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var flight = _flightService.GetFlightById(id);
            if (flight != null)
            {
                return Ok(flight);
            }
            return NotFound(new { Message = $"Flight with ID {id} not found." });
        }

       
        [HttpPost]
        public IActionResult Create([FromBody] FlightModel flight)
        {
            if (flight == null)
            {
                return BadRequest(new { Message = "Invalid flight data." });
            }

            try
            {
                var createdFlight = _flightService.CreateFlight(flight);
                return CreatedAtAction(nameof(GetById), new { id = createdFlight.FlightsID }, createdFlight);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An error occurred: {ex.Message}" });
            }
        }

        
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Flight flight)
        {
            if (flight == null)
            {
                return BadRequest(new { Message = "Invalid flight data." });
            }

            try
            {
                var updatedFlight = _flightService.UpdateFlight(id, flight);
                return Ok(updatedFlight);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An error occurred: {ex.Message}" });
            }
        }

       
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var isDeleted = _flightService.DeleteFlight(id);
                if (isDeleted)
                {
                    return NoContent();
                }
                return NotFound(new { Message = $"Flight with ID {id} not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An error occurred: {ex.Message}" });
            }
        }
    }
}
