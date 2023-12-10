using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static DomainLayer.Models.Enums;

namespace DomainLayer.DTO
{
    public class UserDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required,DataType(DataType.Password)]
        public string password { get; set; }

        [Required,Compare("password"),DataType(DataType.Password)]
        public string confirmPassward { get; set; }
        [Required]
        public Gender gender { get; set; }
        
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [Phone]
        // [RegularExpression("^[0-9]",ErrorMessage ="please enter a valid phone number")]
        public string phoneNumber { get; set; }
      //  public IFormFile? Image { get; set; }

    }
}
