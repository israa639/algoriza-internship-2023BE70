using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    internal class PatientDTO
    {
        [Required, EmailAddress]
        public string email { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string gender { get; set; }

    }
}
