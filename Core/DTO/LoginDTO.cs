using System.ComponentModel.DataAnnotations;

namespace DomainLayer.DTO
{
    public class LoginDTO

    {
        [Required,EmailAddress]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public bool RememberMe { get; set; }
    }
}
