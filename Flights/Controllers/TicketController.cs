using Flights.Data.Interfaces;
using Flights.Models;
using Microsoft.AspNetCore.Mvc;

namespace Flights.Controllers
{
    [Route("api/[controller]")]
    public class TicketController : Controller
    {
        private readonly ITicketDataService ticketDataService;

        public TicketController(ITicketDataService _ticketDataService)
        {
            ticketDataService = _ticketDataService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await ticketDataService.GetAll();
                if (result == null) return NotFound();
                return Json(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await ticketDataService.GetItem(id);
                if (result == null) return NotFound();
                return Json(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        //[HttpPost]
        //[Route("/api/add")]
        //public async Task<IActionResult> Post([FromBody] Ticket model)
        //{
        //    try
        //    {
        //        if (model == null) return StatusCode(500);
        //        var result = await ticketDataService.Create(model);
        //        if (result) return Ok();
        //        return StatusCode(500);
        //    }
        //    catch
        //    {
        //        return StatusCode(500);
        //    }
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Ticket model)
        {
            try
            {
                model.ArrivalDate = model.ArrivalDate.ToUniversalTime();
                model.DepartureDate = model.DepartureDate.ToUniversalTime();
                model.RegistrationDate = model.RegistrationDate.ToUniversalTime();
                if (model == null) return StatusCode(500);
                var result = await ticketDataService.Update(model);
                if (result) return Ok();
                return StatusCode(500);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await ticketDataService.Delete(id);
                if (result) return Ok();
                return StatusCode(500);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}

