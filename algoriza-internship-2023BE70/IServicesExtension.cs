using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepository;
using RepositoryLayer.Repositories;
using ServicesLayer.Services;

namespace vezeeta
{
    public static class IServicesExtension
    {



           public static void configureDbContext(this IServiceCollection Services, IConfiguration configuration) {
            Services.AddDbContext<Entities>(optionBuilder => { optionBuilder.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("DevelopmentConnectionString")); });
        }

        public static void AddIdentity(this IServiceCollection Services)
            {
           Services.AddIdentity<ApplicationUser, IdentityRole>(
         options => {
        options.User.AllowedUserNameCharacters = "";
        options.User.AllowedUserNameCharacters = null;
        options.User.RequireUniqueEmail = true;
                }).AddEntityFrameworkStores<Entities>();
        }
            public static void AddDependencies(this IServiceCollection Services)
        {
           Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
             Services.AddScoped(typeof(IServices<>), typeof(UserServices<>));
            Services.AddScoped<IAccountService, AccountService > ();
          Services.AddScoped<IAppointmentServices, AppointmentServices>();
            Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            Services.AddScoped<IDoctorServices, DoctorServices>();
            Services.AddScoped<IDoctorRepository, DoctorRepository>();

        }
    }
}
