using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class CataDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Date { get; set; }
        public List<WineDTO> Vinos { get; set; } = new List<WineDTO>();
        public List<UserDTO> Guests { get; set; } = new List<UserDTO>();
    }
}
