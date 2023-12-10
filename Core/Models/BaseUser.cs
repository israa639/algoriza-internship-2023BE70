using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class BaseUser:BaseEntity
    {

        [ForeignKey("applicationUser")]
        public string applicationUserId { get; set; }
        public virtual ApplicationUser applicationUser { get; set; }
        public BaseUser() { }
    }
}
