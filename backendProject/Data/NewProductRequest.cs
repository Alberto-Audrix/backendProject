using System.ComponentModel.DataAnnotations;

namespace backendProject.Data
{
    public class NewProductRequest
    {
        [Required]
        public string Category { get; set; }
    }
}
