using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace backendProject.Models
{
    [Table("Admins")]
    public class Admins
    {
        [Key]
        public Guid UserID { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nama { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set;}

        [Required]
        [MaxLength(255)]
        public string Pass { get; set;}
    }
}
