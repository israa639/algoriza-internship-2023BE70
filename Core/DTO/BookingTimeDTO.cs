using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    
    public class BookingTimeDTO
    {
        [Required]
        [RegularExpression("^(2[0-3]|[01]?[0-9]):([0-5]?[0-9])", ErrorMessage = "enter a valid 24-hour time")]
        public string time { get; set; }
    }
}
