using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class KursyPrzystanek
    {
        public int Id { get; set; }
        public int? KursId { get; set; }
        public Kurs? Kurs { get; set; }
        public int? PrzystanekId { get; set; }
        public Przystanek? Przystanek { get; set; }
        public DateTime Godzina { get; set; }
    }
}