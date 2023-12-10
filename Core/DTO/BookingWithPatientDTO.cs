using DomainLayer.Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
   public class BookingWithPatientDTO
    {
     public Enums.Day day { get; set; }
        public Enums.BookingStatus status { get; set; }
        public  string  time { get; set; }
        public string Email { get; set; }
        
        public Enums.Gender gender { get; set; }
        public string phone { get; set; }

    }
}
