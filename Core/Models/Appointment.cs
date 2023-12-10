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
    public class Appointment : BaseEntity { 
        [Required]
        public Day day { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal price { get; set; }

        public string doctorId { get; set; }
        [ForeignKey("doctorId")]
        public virtual Doctor doctor { get; set; }
        public virtual ICollection<Booking> slots { get; set; }

    }
}
