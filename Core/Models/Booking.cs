using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DomainLayer.Models.Enums;

namespace DomainLayer.Models
{
   public class Booking: BaseEntity
    {
        
        [Required]
        [RegularExpression("^(2[0-3]|[01]?[0-9]):([0-5]?[0-9])", ErrorMessage = "enter a valid 24-hour time")]
        public string bookingTime { get; set; }
        public BookingStatus status { get; set; }
        [ForeignKey("appointment")]
        public string appointmentId { get; set; }
        public virtual Appointment appointment { get; set; }
        
       
        public string? patientId { get; set; }
        [ForeignKey("patientId")]
        public virtual Patient? patient { get; set; }
    }
}
