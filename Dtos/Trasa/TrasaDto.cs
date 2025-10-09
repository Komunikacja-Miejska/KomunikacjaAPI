using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.KursyPrzystanek;
using api.Models;

namespace api.Dtos.Trasa
{
    public class TrasaDto
    {
        public string NazwaLinii { get; set; } = string.Empty;
        public string Opis { get; set; } = string.Empty;
        public List<Models.Kurs> Kursy { get; set; } = new();
    }
}