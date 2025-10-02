using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.KursyPrzystanek
{
    public class CreateKursyPrzystanekDto
    {
        public int Id { get; set; }
        [Required]
        public int KursId { get; set; }
        [Required]
        public int PrzystanekId { get; set; }
        [Required]
        public DateTime Godzina { get; set; }
    }
}