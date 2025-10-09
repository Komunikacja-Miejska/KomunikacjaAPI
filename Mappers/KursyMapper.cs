using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Kurs;
using api.Models;

namespace api.Mappers
{
    public static class KursyMapper
    {
        public static KursDto ToKursDto(this Kurs kursModel)
        {
            return new KursDto
            {
                Id = kursModel.Id,
                TrasaId = kursModel.TrasaId,
                KursyPrzystanki = kursModel.KursyPrzystanki.Select(kp => kp.ToKursyPrzystanekDto()).ToList()
            };
        }
    }
}