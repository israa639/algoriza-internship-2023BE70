using DomainLayer.DTO;
using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Services
{
    public class AccountService : IAccountService
    {
        UserManager<ApplicationUser> _userManager;
        private IServices<Doctor> _DoctorService;
        private readonly IServices<Patient> _PatientService;

        public AccountService(UserManager<ApplicationUser> userManager, IServices<Patient> PatientService, IServices<Doctor> DoctorService)
        {
            _userManager = userManager;
            _PatientService = PatientService;
            _DoctorService = DoctorService;
        }
        public async Task<ApplicationUser> createPatientAsync(UserDTO userDTO)
        {
            ApplicationUser appUser = await createAppUserAsync(userDTO, Enums.Role.Patient);
            Patient patient = new Patient() { Id = Guid.NewGuid().ToString(), applicationUserId = appUser.Id };
            _PatientService.Insert(patient);
            appUser.patientId = patient.Id;
            await _userManager.UpdateAsync(appUser);
            return appUser;
        }
        public async Task<ApplicationUser> createDoctorAsync(DoctorDTO userDTO)
        {
            ApplicationUser appUser = await createAppUserAsync(userDTO, Enums.Role.Doctor);
            Doctor doctor = new Doctor() { Id = Guid.NewGuid().ToString(), applicationUserId = appUser.Id,specializationId=userDTO.specializationId,numOfRequests=0 };
            _DoctorService.Insert(doctor);
            appUser.DoctorId = doctor.Id;
            await _userManager.UpdateAsync(appUser);
            return appUser;

        }



        public async Task<ApplicationUser> createAppUserAsync(UserDTO userDTO, Enums.Role role)
        {
            ApplicationUser NewUser = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                Email = userDTO.Email,
                gender = userDTO.gender,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                DateOfBirth = userDTO.DateOfBirth,
                UserName = userDTO.UserName,
                PasswordHash = userDTO.password,
                role = role

            };

            try
            {
                await _userManager.CreateAsync(NewUser, userDTO.password);
               // await _userManager.AddToRoleAsync(NewUser, role.ToString());

            }
            catch (Exception ex) { }
            return NewUser;
        }
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> loginAsync(LoginDTO loginUser)
        {
            ApplicationUser applicationUser = await _userManager.FindByEmailAsync(loginUser.email);
            if (applicationUser != null)
            {
                bool found = await _userManager.CheckPasswordAsync(applicationUser, loginUser.password);
                if (found)
                {
                     return applicationUser;
                }
            }
            return null;
        }

        public async Task<IList<Claim>> GetClaims(ApplicationUser applicationUser)
        {
            IList<Claim> Claims = new List<Claim>();
            
            Claims.Add(new Claim(ClaimTypes.Role, applicationUser.role.ToString()));
            if (applicationUser.DoctorId != null)
                Claims.Add(new Claim("DoctorId", applicationUser.DoctorId));
            if (applicationUser.patientId != null)
               Claims.Add(new Claim("PatientId", applicationUser.patientId));


            return Claims;
        }
    }
}