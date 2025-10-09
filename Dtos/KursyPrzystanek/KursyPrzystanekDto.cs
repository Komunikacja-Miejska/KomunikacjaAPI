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
        public DateTime Godzina { get; set; }
    }
}