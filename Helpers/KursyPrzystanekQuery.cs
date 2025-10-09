using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public class KursyPrzystanekQuery
    {
        public int? KursId { get; set; } = null;
        public string Nazwa { get; set; } = string.Empty;
        public string Opis { get; set; } = string.Empty;
    }
}