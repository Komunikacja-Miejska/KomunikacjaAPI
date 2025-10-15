using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("KursyPrzystanki")]
    public class KursyPrzystanek
    {
        public int? KursId { get; set; }
        public Kurs? Kurs { get; set; }
        public int? PrzystanekId { get; set; }
        public Przystanek? Przystanek { get; set; }
        public TimeSpan Godzina { get; set; }
    }
}