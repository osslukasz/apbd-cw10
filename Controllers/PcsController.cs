using WebApplication2.DTOs;
using WebApplication2.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PcsController : ControllerBase
    {
        private readonly IPcService _pcService;

        public PcsController(IPcService pcService)
        {
            _pcService = pcService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pcs = await _pcService.GetAllPcsAsync();
            return Ok(pcs);
        }

        [HttpGet("{id}/components")]
        public async Task<IActionResult> GetComponents(int id)
        {
            var pc = await _pcService.GetPcWithComponentsAsync(id);
            if (pc == null)
            {
                return NotFound();
            }
            return Ok(pc);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PcCreateUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdPc = await _pcService.AddPcAsync(dto);
            // Returns 201 Created Status
            return CreatedAtAction(nameof(GetComponents), new { id = createdPc.Id }, createdPc);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PcCreateUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await _pcService.UpdatePcAsync(id, dto);
            if (!success)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _pcService.DeletePcAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}