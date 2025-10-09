using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.KursyPrzystanek;

namespace api.Dtos.Kurs
{
    public class KursDto
    {
        public int Id { get; set; }
        public int? TrasaId { get; set; }
        public List<KursyPrzystanekDto> KursyPrzystanki { get; set; } = new();
    }
}