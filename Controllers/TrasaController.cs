using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using api.Data;
using api.Dtos.Trasa;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace api.Controllers
{
    [Route("api/trasa")]
    [ApiController]
    public class TrasaController : ControllerBase
    {
        private readonly ITrasaRepository _trasaRepo;
        public TrasaController(ITrasaRepository trasaRepo, IKursRepository kursRepo)
        {
            _trasaRepo = trasaRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] TrasaQuery query)
        {
            var trasy = await _trasaRepo.GetAllAsync(query);
            var trasyDto = trasy.Select(t => t.ToTrasaDto());

            return Ok(trasy);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var trasaModel = await _trasaRepo.GetByIdAsync(id);

            if (trasaModel == null) return NotFound();

            return Ok(trasaModel.ToTrasaDto());
        }

        [HttpGet]
        [Route("courses/{id:int}")]
        public async Task<IActionResult> GetCoursesById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var kursy = await _trasaRepo.GetKursyById(id);

            return Ok(kursy.Select(k => k.ToKursDto()));
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTrasaDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var trasaModel = await _trasaRepo.UpdateAsync(id, updateDto);

            if (trasaModel == null) return NotFound();

            return Ok(trasaModel.ToTrasaDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTrasaDto createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var trasaModel = createDto.ToTrasaFromCreateDto();
            await _trasaRepo.CreateAsync(trasaModel);
            return CreatedAtAction(nameof(GetById), new { id = trasaModel.Id }, trasaModel.ToTrasaDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);        

            var trasaModel = await _trasaRepo.DeleteAsync(id);

            if (trasaModel == null) return NotFound();

            return NoContent();
        }
    }
}