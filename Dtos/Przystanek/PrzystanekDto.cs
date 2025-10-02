using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.KursyPrzystanek;
using api.Models;

namespace api.Dtos
{
    public class PrzystanekDto
    {
        public int Id { get; set; }
        public string Nazwa { get; set; } = string.Empty;
        public string Opis { get; set; } = string.Empty;
        public List<KursyPrzystanekDto> KursyPrzystanki { get; set; } = new();
    }
}