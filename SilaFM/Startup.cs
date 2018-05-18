using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pras.BLL.Services;
using Pras.BLL.Services.Interfaces;
using Pras.Infrastructure;
using Pras.Infrastructure.Identity;
using Pras.Infrastructure.Identity.Interfaces;
using Pras.Web.Mappers;

namespace Pras.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static string WebRootPath { get; private set; }

        public static string MapPath(string path, string basePath = null)
        {
            if (string.IsNullOrEmpty(basePath))
            {
                basePath = WebRootPath;
            }

            path = path.Replace("~/", "").TrimStart('/').Replace('/', '\\');
            return Path.Combine(basePath, path);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add application services.
            services.RegisterApplicationServices(Configuration);

            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IAppUserManager, AppUserManager>();
            services.AddTransient<IAudioService, AudioService>();
            services.AddTransient<IVideoService, VideoService>();
            services.AddTransient<ISpeakersService, SpeakersService>();
            services.AddTransient<IPeopleService, PeopleService>();
            services.AddTransient<IInformationService, InformationService>();

            services.AddMvc();
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
                );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            WebRootPath = env.WebRootPath;
            AutoMapperConfiguration.Configure();
        }
    }
}
