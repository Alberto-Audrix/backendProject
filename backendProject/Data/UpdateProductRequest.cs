using System.ComponentModel.DataAnnotations;

namespace backendProject.Data
{
    public class UpdateProductRequest
    {
        [Required]
        public string Category { get; set; }
    }
}
