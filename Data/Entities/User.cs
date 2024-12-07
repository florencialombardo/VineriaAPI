using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name {  get; set; } = string.Empty;

        [Required]
        public string Mail { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public List<Cata> Catas { get; set; } = new List<Cata>();
    }
}
