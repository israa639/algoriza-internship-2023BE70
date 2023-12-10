using DomainLayer.DTO;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Services
{
   public interface IAccountService
    {
        public  Task<ApplicationUser> createPatientAsync(UserDTO userDTO);
        public Task<ApplicationUser> createDoctorAsync(DoctorDTO userDTO);
        public Task<ApplicationUser> loginAsync(LoginDTO loginUser);
        public Task DeleteAsync(int id);

        public Task<IList<Claim>> GetClaims(ApplicationUser user);
        

    }
}
