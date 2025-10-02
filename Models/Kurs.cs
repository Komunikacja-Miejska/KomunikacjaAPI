using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Kurs
    {
        public int Id { get; set; }
        public int? TrasaId { get; set; }
        public Trasa? Trasa { get; set; }
        public List<KursyPrzystanek> Przystanki { get; set; } = new List<KursyPrzystanek>();
    }
}