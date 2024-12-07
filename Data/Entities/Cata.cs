using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Cata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Date { get; set; }

        public List<User> Guests { get; set; } = new List<User>();

        
        public List<Wine> Vinos { get; set; } = new List<Wine>();
        


    }
}
