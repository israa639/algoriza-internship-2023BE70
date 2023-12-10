using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Specialization
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Column(Order = 1)]
        public  int  Id{ get; set; }
        [Required]
        public string Name { get; set; }
       
        public string ArabicName { get; set; }
        public int requestsNum { get; set; }
        public virtual ICollection<Doctor> doctors { get; set; }
    }
}
