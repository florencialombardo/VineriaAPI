using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Mail { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "La contraseña debe tener mínimo 8 caracteres")]
        public string Password { get; set; }
    }
}
