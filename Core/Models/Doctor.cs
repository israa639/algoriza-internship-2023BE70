using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    [Table("Doctors")]
    public class Doctor: BaseUser
    {
       
       public int numOfRequests { get; set; }
        
        public int specializationId { get; set; }
        [ForeignKey("specializationId")]
        public virtual Specialization specialization { get; set; }

        public virtual ICollection<Appointment> appointments { get; set; }

    }
}
