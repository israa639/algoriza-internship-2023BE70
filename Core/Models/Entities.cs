using DomainLayer.Extensions;
using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using static DomainLayer.Models.Enums;

namespace DomainLayer.Models
{
    public class Entities:IdentityDbContext<ApplicationUser>
    {
       
        public DbSet<ApplicationUser> users;
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Specialization> specializations { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public Entities(DbContextOptions options) : base(options)
        {
         

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.seedRoles();
            builder.seedAdminData();
            builder.SeedSpecializationData();
            builder.cascadeDelete();

        }





    }
}


