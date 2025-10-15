using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public class TrasaQuery
    {
        public int? KursId { get; set; } = null;
        public string? NazwaLinii { get; set; } = null;
        public string? Opis { get; set; } = null;
    }
}