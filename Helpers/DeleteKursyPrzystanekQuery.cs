using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public class DeleteKursyPrzystanekQuery
    {
        public int? KursId { get; set; } = null;
        public int? PrzystanekId { get; set; } = null;
    }
}