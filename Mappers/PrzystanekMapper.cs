using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class PrzystanekMapper
    {
        public static PrzystanekDto ToPrzystanekDto(this Przystanek przystanekModel)
        {
            return new PrzystanekDto
            {
                Id = przystanekModel.Id,
                Nazwa = przystanekModel.Nazwa,
                Opis = przystanekModel.Opis,
                KursyPrzystanki = przystanekModel.KursyPrzystanki.Select(k => k.ToKursyPrzystanekDto()).ToList()
            };
        }

        public static Przystanek ToPrzystanekFromCreateDto(this CreatePrzystanekDto przystanekDto)
        {
            return new Przystanek
            {
                Nazwa = przystanekDto.Nazwa,
                Opis = przystanekDto.Opis
            };
        }
    }
}