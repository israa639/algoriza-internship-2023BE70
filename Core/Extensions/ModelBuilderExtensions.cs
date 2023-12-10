using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DomainLayer.Models.Enums;

namespace DomainLayer.Extensions
{
  
   

   public static class ModelBuilderExtensions
    {

    static  string _adminId = Guid.NewGuid().ToString();
    static string _AdminRoleId = Guid.NewGuid().ToString();
    static string _DoctorRoleId = Guid.NewGuid().ToString();
    static string _PatientRoleId = Guid.NewGuid().ToString();

   
    public static void seedRoles(this ModelBuilder builder)
    {
        builder.Entity<IdentityRole>().HasData(
              new IdentityRole{ Id = _AdminRoleId, Name = Role.Admin.ToString(),NormalizedName="admin" },
              new IdentityRole { Id = _DoctorRoleId, Name = Role.Doctor.ToString(),NormalizedName="doctor" },
              new IdentityRole { Id = _PatientRoleId, Name = Role.Patient.ToString(),NormalizedName="patient" }  );
    }
    public static void seedAdminData(this ModelBuilder builder)
    {

            var hasher = new PasswordHasher<IdentityUser>();
            ApplicationUser admin = new ApplicationUser()
            {
                NormalizedEmail = "admin@email.com",
                Email = "admin@email.com",
                Id = _adminId,
                PasswordHash = hasher.HashPassword(null, "Algoriza"),
                EmailConfirmed = true,
                LockoutEnabled = false,
                role=Enums.Role.Admin
                
            };

            builder.Entity<ApplicationUser>().HasData(admin);
            builder.Entity<IdentityUserRole<String>>().HasData(
                           new IdentityUserRole<string> { UserId = _adminId, RoleId = _AdminRoleId });
       

        }


        public static void SeedSpecializationData(this ModelBuilder builder)
        {
            builder.Entity<Specialization>().HasData(
                new Specialization() {Id=1, Name = "cardiology",ArabicName="قلب" },
                new Specialization() { Id =2, Name = "Surgery", ArabicName = "جراحة" },
               new Specialization() { Id =3, Name = "Psychiatry", ArabicName = "نفسية" },
            new Specialization() { Id = 4,Name = "Immunology", ArabicName = "مناعة" },
            new Specialization() { Id =5, Name = "brain surgery", ArabicName = "جراحة مخ" },
              new Specialization() { Id = 7,Name = "Brain ", ArabicName = "مخ واعصاب" },
            new Specialization() { Id =9, Name = "Dermatology", ArabicName = "جلدية" });
        }
        public static void cascadeDelete(this ModelBuilder builder)
        {
           builder
       .Entity<Doctor>()
       .HasOne(e => e.applicationUser)
       .WithOne(e => e.doctor)
       .OnDelete(DeleteBehavior.ClientCascade);

            builder
      .Entity<Patient>()
      .HasOne(e => e.applicationUser)
      .WithOne(e => e.patient)
      .OnDelete(DeleteBehavior.ClientCascade);

           
        }
        

    }
    }

