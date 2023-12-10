using DomainLayer.DTO;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DomainLayer.Models.Enums;

namespace DomainLayer.Models
{
    public class ApplicationUser:IdentityUser
    {
        public ApplicationUser() { }
       
        public byte[]? ImageData { get; set; }
        public string? FirstName { get; set; }
       
        public string? LastName { get; set; }
        
        
        public Gender? gender { get; set; }
      
        public DateTime? DateOfBirth { get; set; }
        public Role role { get; set; }

        [ForeignKey("doctor")]
        public string? DoctorId { get; set; }
        public virtual Doctor doctor{ get; set; }

        [ForeignKey("patient")]
        public string? patientId { get; set; }
        public virtual Patient patient { get; set; }
        //mandatory for user

        //[ ForeignKey("imageDetails")]
        // public int imageDetailsId { get; set; }
        // public ImageDetails imageDetails { get; set; }
    }
}
