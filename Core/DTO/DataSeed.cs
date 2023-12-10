using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static DomainLayer.Models.Enums;

namespace DomainLayer.DTO
{
    public class DataSeed
    {
        static string _AdminUserId;
        static string _AdminRoleId;
        static string _DoctorRoleId;
        static string _PatientRoleId;
        static ModelBuilder builder;
        public DataSeed(ModelBuilder Builder)
        {
            builder = Builder;
            _AdminUserId = Guid.NewGuid().ToString();
            _AdminRoleId = Guid.NewGuid().ToString();
            _DoctorRoleId = Guid.NewGuid().ToString();
            _PatientRoleId = Guid.NewGuid().ToString();
        }
        public void seedRoles()
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = _AdminRoleId, Name = Role.Admin.ToString() },
               new IdentityRole { Id = _DoctorRoleId, Name = Role.Doctor.ToString() },
             new IdentityRole { Id = _PatientRoleId, Name = Role.Patient.ToString() });

        }
        public static async Task SeedAdminUser()
        {
            var hasher = new PasswordHasher<IdentityUser>();
            ApplicationUser user = new ApplicationUser()
            {

                Email = "admin@email.com",
                Id = _AdminUserId,
                PasswordHash = hasher.HashPassword(null, "Pa$$w0rd"),
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            builder.Entity<ApplicationUser>().HasData(user);
            builder.Entity<IdentityUserRole<String>>().HasData(
                           new IdentityUserRole<string> { UserId = _AdminUserId, RoleId = _AdminRoleId });

        }

    }



}







