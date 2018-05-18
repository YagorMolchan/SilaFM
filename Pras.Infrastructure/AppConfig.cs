using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Pras.BLL.Services;
using Pras.BLL.Services.Interfaces;
using Pras.DAL.Context;
using Pras.DAL.Entities;
using Pras.DAL.Interfaces;
using Pras.DAL.Repositories;

namespace Pras.Infrastructure
{
    public static class AppConfig
    {
        public static void RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext
            services.AddDbContext<PrasDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PrasDB")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<PrasDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<PrasDbContext>();

            // Add application services.
            services.AddTransient<IRepository<Entity>, Repository<Entity>>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //services.AddScoped<PrasDbContext>(x => new ApplicationContext(configuration["Data:ApplicationContext:ConnectionString"]));

            //// Repositories
            //var repositoryAssembly = typeof(BootstrapRepository).Assembly;
            //var repositoryRegistrations = repositoryAssembly
            //    .GetExportedTypes()
            //    .Where(type => type.Namespace == RepositoryNamespace && type.GetInterfaces().Any())
            //    .Select(type => new
            //    {
            //        Interface = type.GetInterfaces().Single(),
            //        Implementation = type
            //    });
            //foreach (var reg in repositoryRegistrations)
            //{
            //    services.AddTransient(reg.Interface, reg.Implementation);
            //}

            //// Services
            //var serviceAssembly = typeof(BootstrapService).Assembly;
            //var serviceRegistrations = serviceAssembly
            //    .GetExportedTypes()
            //    .Where(type => type.Namespace == ServiceNamespace && type.GetInterfaces().Any())
            //    .Select(type => new
            //    {
            //        Interface = type.GetInterfaces().Single(),
            //        Implementation = type
            //    });
            //foreach (var reg in serviceRegistrations)
            //{
            //    services.AddTransient(reg.Interface, reg.Implementation);
            //}

            var provider = services.BuildServiceProvider();
            try
            {
                var userManager = provider.GetRequiredService<UserManager<ApplicationUser>>();
                var rolesManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
                DatabaseInitializer.InitializeAsync(userManager, rolesManager).Wait();
            }
            catch (Exception ex)
            {
                var logger = provider.GetRequiredService<ILogger<DatabaseInitializer>>();
                logger.LogError(ex, "An error occurred while seeding the database.");
            }
        }
    }
}
