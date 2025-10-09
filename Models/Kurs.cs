using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Kursy")]
    public class Kurs
    {
        public int Id { get; set; }
        public int? TrasaId { get; set; }
        public Trasa? Trasa { get; set; }
        public List<KursyPrzystanek> KursyPrzystanki { get; set; } = new List<KursyPrzystanek>();
    }
}