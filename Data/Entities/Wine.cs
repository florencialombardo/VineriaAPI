using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Wine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Variety { get; set; } = string.Empty;

        [Required]
        public int Year { get; set; }

        [Required]
        public string Region { get; set; } = string.Empty;
 
        [Required]
        public int Stock { get; set; }

        public decimal Price { get; set; }

        public List<Cata> Catas { get; set; } = new List<Cata>();


    }

}
