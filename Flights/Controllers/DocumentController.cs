using Flights.Data.Interfaces;
using Flights.Models;
using Microsoft.AspNetCore.Mvc;

namespace Flights.Controllers
{
    [Route("api/[controller]")]
    public class DocumentController : Controller
    {
        private readonly IDocumentDataService documentDataService;

        public DocumentController(IDocumentDataService _documentDataService)
        {
            documentDataService = _documentDataService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(long passagerId)
        {
            try
            {
                var result = await documentDataService.GetAllByPassenger(passagerId);
                if (result == null) return NotFound();
                return Json(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Document model)
        {
            try
            {
                if (model == null) return BadRequest();
                var result = await documentDataService.Update(model);
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
                var result = await documentDataService.Delete(id);
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

