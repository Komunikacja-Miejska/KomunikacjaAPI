using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Trasa
    {
        public int Id { get; set; }
        public string NazwaLinii { get; set; } = string.Empty;
        public string Opis { get; set; } = string.Empty;
        public List<Kurs> Kursy { get; set; } = new List<Kurs>();
    }
}