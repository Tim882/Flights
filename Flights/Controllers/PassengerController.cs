using Flights.Data.Interfaces;
using Flights.Models;
using Microsoft.AspNetCore.Mvc;

namespace Flights.Controllers
{
    [Route("api/[controller]")]
    public class PassengerController : Controller
    {
        private readonly IPassengerDataService passengerDataService;

        public PassengerController(IPassengerDataService _passengerDataService)
        {
            passengerDataService = _passengerDataService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var result = await passengerDataService.GetAllByTicket(id);
                if (result == null) return NotFound();
                return Json(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Passenger model)
        {
            try
            {
                if (model == null) return BadRequest();
                var result = await passengerDataService.Update(model);
                if (result) return Ok();
                return StatusCode(500);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var result = await passengerDataService.Delete(id);
                if (result) return Ok();
                return StatusCode(500);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("/report/{id}")]
        public async Task<IActionResult> GetReport(long passengerId, DateTime periodStartDate, DateTime periodEndDate)
        {
            try
            {
                var result = await passengerDataService.GetReport(passengerId, periodStartDate, periodEndDate);
                if (result == null) return NotFound();
                return Json(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}

