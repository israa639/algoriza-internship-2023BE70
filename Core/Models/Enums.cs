using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Enums
    {
        public enum Gender
        {
           Female=0,male=1
        }
        public enum DiscountType
        {
             Percentage=0,
             Value=1
        }
        public enum Day
        {
            Saturday=0,
             Sunday=1,
            Monday= 2,
            Tuesday=3,
            Wednesday=4,
           Thursday=5,
           Friday=6

                }
        public enum BookingStatus
        {
            completed=0,
            available=1,
            booked=2

        }
      [Flags]
        public  enum Role
        {
            Admin=0,
            Doctor=1,
            Patient=2

        };
        


    }
}
