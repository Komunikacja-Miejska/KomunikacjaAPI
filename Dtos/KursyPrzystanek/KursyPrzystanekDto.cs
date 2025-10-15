using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos.KursyPrzystanek
{
    public class KursyPrzystanekDto
    {
        public int? KursId { get; set; }
        public int? PrzystanekId { get; set; }
        public TimeSpan Godzina { get; set; }
    }
}