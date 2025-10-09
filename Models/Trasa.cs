using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Trasy")]
    public class Trasa
    {
        public int Id { get; set; }
        public string NazwaLinii { get; set; } = string.Empty;
        public string Opis { get; set; } = string.Empty;
        public List<Kurs> Kursy { get; set; } = new List<Kurs>();
    }
}