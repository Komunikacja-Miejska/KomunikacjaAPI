using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Trasa;
using api.Models;

namespace api.Mappers
{
    public static class TrasaMapper
    {
        public static TrasaDto ToTrasaDto(this Trasa trasaModel)
        {
            return new TrasaDto
            {
                NazwaLinii = trasaModel.NazwaLinii,
                Opis = trasaModel.Opis,
            };
        }

        public static Trasa ToTrasaFromCreateDto(this CreateTrasaDto createDto)
        {
            return new Trasa
            {
                NazwaLinii = createDto.NazwaLinii,
                Opis = createDto.Opis
            };
        }
    }
}