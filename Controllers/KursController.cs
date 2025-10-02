using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/kurs")]
    [ApiController]
    public class KursController : ControllerBase
    {
        private readonly ITrasaRepository _trasaRepo;
        private readonly IKursRepository _kursRepo;

        public KursController(ITrasaRepository trasaRepo, IKursRepository kursRepo)
        {
            _trasaRepo = trasaRepo;
            _kursRepo = kursRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var kursy = await _kursRepo.GetAllAsync();
            return Ok(kursy);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var kursModel = await _kursRepo.GetByIdAsync(id);

            if (kursModel == null) return NotFound();

            return Ok(kursModel);
        }

        [HttpPost("{trasaId:int}")]
        public async Task<IActionResult> Create([FromRoute] int trasaId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _trasaRepo.TrasaExists(trasaId))
            {
                return BadRequest("Trasa does not exist");
            }

            var kursModel = new Kurs { TrasaId = trasaId };

            await _kursRepo.CreateAsync(kursModel);
            return CreatedAtAction(nameof(GetById), new { id = kursModel.Id }, kursModel);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var kursModel = await _kursRepo.DeleteAsync(id);

            if (kursModel == null) return NotFound();

            return NoContent();
        }
    }
}