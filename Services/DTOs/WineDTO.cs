using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class WineDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Name { get; set; }

        [Required]
        [Range(1900, 2100, ErrorMessage = "El año debe estar entre 2024 y 2030")]
        public int Year { get; set; }

        [Required(ErrorMessage = "La variedad es obligatoria")]
        public string Variety { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El precio no puede ser negativo")]
        public decimal Price { get; set; }

        [Required]
        public string Region { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
        public int Stock { get; set; }
    }
}
