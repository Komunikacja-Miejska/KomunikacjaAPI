using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Przystanki")]
    public class Przystanek
    {
        public int Id { get; set; }
        public string Nazwa { get; set; } = string.Empty;
        public string Opis { get; set; } = string.Empty;
        public List<KursyPrzystanek> KursyPrzystanki { get; set; } = new List<KursyPrzystanek>();
    }
}