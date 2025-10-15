using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class UpdatePrzystanekDto
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Nazwa cannot be over 50 characters")]
        public string Nazwa { get; set; } = string.Empty;
        [MaxLength(200, ErrorMessage = "Nazwa cannot be over 200 characters")]
        public string Opis { get; set; } = string.Empty;
        [Required]
        public string Latitude { get; set; } = string.Empty;
        [Required]
        public string Longitude { get; set; } = string.Empty;
    }
}