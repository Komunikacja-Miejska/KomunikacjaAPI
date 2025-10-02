using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Trasa
{
    public class CreateTrasaDto
    {
        [Required]
        [MaxLength(50, ErrorMessage = "NazwaLinii Cannot be over 50 characters")]
        public string NazwaLinii { get; set; } = string.Empty;

        [MaxLength(100, ErrorMessage = "Opis Cannot be over 100 characters")]
        public string Opis { get; set; } = string.Empty;
    }
}