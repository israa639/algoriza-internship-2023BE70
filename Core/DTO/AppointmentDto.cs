using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class AppointmentDto
    {
        [Column(TypeName = "decimal(18,4)")]
        public decimal price { get; set; }
        public IDictionary<Enums.Day, IList<BookingTimeDTO>> appointments { get; set; }

    }
}
