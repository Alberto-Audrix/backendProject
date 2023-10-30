using System.ComponentModel.DataAnnotations;

namespace backendProject.Data
{
    public class NewAdminRequest
    {
        [Required]
        public string Nama { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Pass { get; set; }
    }
}
