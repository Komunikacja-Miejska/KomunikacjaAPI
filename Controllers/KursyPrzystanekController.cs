using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.KursyPrzystanek;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

namespace api.Controllers
{
    [Route("api/kursyPrzystanek")]
    [ApiController]
    public class KursyPrzystanekController : ControllerBase
    {
        private readonly IKursyPrzystanekRepository _kursyPrzystanekRepo;
        private readonly IPrzystanekRepository _przystanekRepo;
        private readonly ITrasaRepository _trasaRepo;

        public KursyPrzystanekController(IKursyPrzystanekRepository kursyPrzystanekRepo, IPrzystanekRepository przystanekRepo, ITrasaRepository trasaRepo)
        {
            _kursyPrzystanekRepo = kursyPrzystanekRepo;
            _przystanekRepo = przystanekRepo;
            _trasaRepo = trasaRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] KursyPrzystanekQuery query)
        {
            var kursyPrzystanki = await _kursyPrzystanekRepo.GetAllAsync(query);
            return Ok(kursyPrzystanki.Select(k => k.ToKursyPrzystanekDto()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var kursyPrzystanekModel = await _kursyPrzystanekRepo.GetByIdAsync(id);

            if (kursyPrzystanekModel == null) return NotFound();

            return Ok(kursyPrzystanekModel.ToKursyPrzystanekDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateKursyPrzystanekDto kursyPrzystanekDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _przystanekRepo.PrzystanekExists(kursyPrzystanekDto.PrzystanekId))
            {
                return BadRequest("Przystanek does not exist");
            }

            // if (!await _trasaRepo.TrasaExists(kursyPrzystanekDto.))
            // {
            //     return BadRequest("Trasa does not exist");
            // }

            if (kursyPrzystanekDto.Godzina < DateTime.Now)
            {
                return BadRequest("Date cannot be earlier than now");
            }

            var kursyPrzystanekModel = kursyPrzystanekDto.ToKursyPrzystanekFromCreateDto();

            await _kursyPrzystanekRepo.CreateAsync(kursyPrzystanekModel);

            return CreatedAtAction(nameof(GetById), new { id = kursyPrzystanekModel.Id }, kursyPrzystanekModel.ToKursyPrzystanekDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var kursyPrzystanekModel = await _kursyPrzystanekRepo.DeleteAsync(id);

            if (kursyPrzystanekModel == null) return NotFound();

            return NoContent();
        }


    }
}