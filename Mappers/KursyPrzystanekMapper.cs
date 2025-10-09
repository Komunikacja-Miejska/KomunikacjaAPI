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
                KursId = kursyPModel.KursId,
                PrzystanekId = kursyPModel.PrzystanekId,
                Godzina = kursyPModel.Godzina
            };
        }
    }
}