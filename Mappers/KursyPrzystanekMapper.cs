using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.KursyPrzystanek;
using api.Models;

namespace api.Mappers
{
    public static class KursyPrzystanekMapper
    {
        public static KursyPrzystanekDto ToKursyPrzystanekDto(this KursyPrzystanek kursyPModel)
        {
            return new KursyPrzystanekDto
            {
                Id = kursyPModel.Id,
                Godzina = kursyPModel.Godzina
            };
        }

        public static KursyPrzystanek ToKursyPrzystanekFromCreateDto(this CreateKursyPrzystanekDto kursyPrzystanekDto)
        {
            return new KursyPrzystanek
            {
                KursId = kursyPrzystanekDto.KursId,
                PrzystanekId = kursyPrzystanekDto.PrzystanekId,
                Godzina = kursyPrzystanekDto.Godzina
            };
        }
    }
}