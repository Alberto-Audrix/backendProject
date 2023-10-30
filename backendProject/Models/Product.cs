using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendProject.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [MaxLength(255)]
        public string Category { get; set; }
    }
}
