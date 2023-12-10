using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    [Table("patients")]
    public class Patient: BaseUser
    {


        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
