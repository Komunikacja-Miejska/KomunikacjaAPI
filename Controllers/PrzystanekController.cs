using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.Extensions.Msal;
using Microsoft.OpenApi.Validations;

namespace api.Controllers
{
    [Route("api/przystanek")]
    [ApiController]
    public class PrzystanekController : ControllerBase
    {
        private readonly IPrzystanekRepository _przystanekRepo;
        private readonly IKursyPrzystanekRepository _kursyPrzystanekRepo;

        public PrzystanekController(IPrzystanekRepository przystanekRepository, IKursyPrzystanekRepository kursyPrzystanekRepo)
        {
            _przystanekRepo = przystanekRepository;
            _kursyPrzystanekRepo = kursyPrzystanekRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PrzystanekQuery query)
        {
            var przystanki = await _przystanekRepo.GetAllAsync(query);

            var przystankiDto = przystanki.Select(p => p.ToPrzystanekDto());

            return Ok(przystankiDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var przystanek = await _przystanekRepo.GetByIdAsync(id);

            if (przystanek == null) return NotFound();

            return Ok(przystanek.ToPrzystanekDto());
        }

        [HttpGet("odjazdy/{id:int}")]
        public async Task<IActionResult> GetDeparturesById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var przystanekModel = await _przystanekRepo.GetByIdAsync(id);

            if (przystanekModel == null)
            {
                return NotFound();
            }

            return Ok(przystanekModel.KursyPrzystanki);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePrzystanekDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var przystanekModel = await _przystanekRepo.UpdateAsync(id, updateDto);

            if (przystanekModel == null) return NotFound();

            return Ok(przystanekModel.ToPrzystanekDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePrzystanekDto przystanekDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var przystanekModel = przystanekDto.ToPrzystanekFromCreateDto();
            await _przystanekRepo.CreateAsync(przystanekModel);
            return CreatedAtAction(nameof(GetById), new { id = przystanekModel.Id }, przystanekModel.ToPrzystanekDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _kursyPrzystanekRepo.DeleteByFkAsync(new DeleteKursyPrzystanekQuery { PrzystanekId = id });

            var przystanekModel = await _przystanekRepo.DeleteAsync(id);

            if (przystanekModel == null) return NotFound();

            return NoContent();
        }
    }
}