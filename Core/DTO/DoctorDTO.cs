using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class DoctorDTO:UserDTO
    {

      
       
       [ Required]
        public int specializationId { get; set; }
      
    }
}
