using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLog.Web;
using Pras.BLL.Services;
using Pras.BLL.Services.Interfaces;
using Pras.Infrastructure;
using Pras.Infrastructure.Identity;
using Pras.Infrastructure.Identity.Interfaces;
using Pras.InfrastructureSt;
using Pras.Shared.Config;
using Pras.Web.Filters;
using Pras.Web.Mappers;
using Pras.Web.Middleware;
using Pras.Web.RewriteRules;

namespace Pras.Web
{
    public class Startup
    {
        private readonly ILoggerFactory _loggerFactory;
        private ILogger _logger;

        public Startup(IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
            this._loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger("Startup");

            _logger.LogInformation(env.EnvironmentName);
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
            var settingsSection = Configuration.GetSection("AppSettings");
            var settings = settingsSection.Get<AppSettings>();

            // Add application services.
            services.RegisterApplicationServices(Configuration, settings);

            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IAppUserManager, AppUserManager>();
            services.AddTransient<IAudioService, AudioService>();
            services.AddTransient<IVideoService, VideoService>();
            services.AddTransient<ISpeakersService, SpeakersService>();
            services.AddTransient<IPeopleService, PeopleService>();
            services.AddTransient<IInformationService, InformationService>();
            services.AddTransient<IReviewsService, ReviewsService>();
            services.AddTransient<ISettingsService, SettingsService>();
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMvc()
                .AddMvcOptions(o =>
                {
                    o.Filters.Add(new GlobalExceptionFilter(_loggerFactory));
                    o.RespectBrowserAcceptHeader = true;
                    o.OutputFormatters.Add(new XmlSerializerOutputFormatter());
                })
                .AddXmlSerializerFormatters()
                .AddXmlDataContractSerializerFormatters();

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(10);
            });
            services.ConfigureApplicationCookie(options =>
                {
                    options.LoginPath = "/login";
                    options.Cookie.Expiration = TimeSpan.FromHours(10);
                }).AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => { options.Cookie.Expiration = TimeSpan.FromHours(10); });
            
            services.AddDataProtection()
                .SetApplicationName("SilaFM")
                .PersistKeysToFileSystem(new DirectoryInfo("\\machinekeys"))
                .SetDefaultKeyLifetime(TimeSpan.FromDays(14));

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            env.ConfigureNLog("NLog.config");
            _loggerFactory.AddNLog();
            _logger.LogInformation(Configuration
                .GetConnectionString("PrasDB"));
            _logger.LogInformation(env.EnvironmentName);

            var locale = Configuration.GetSection("Localization:Culture").Value;
            var localeUI = Configuration.GetSection("Localization:UICulture").Value;
            RequestLocalizationOptions localizationOptions = new RequestLocalizationOptions
            {
                SupportedCultures = new List<CultureInfo> { new CultureInfo(locale) },
                SupportedUICultures = new List<CultureInfo> { new CultureInfo(localeUI) },
                DefaultRequestCulture = new RequestCulture(locale)
            };
            app.UseRequestLocalization(localizationOptions);

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                // обработка ошибок HTTP
                app.UseStatusCodePagesWithReExecute("/error", "?code={0}");
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseCheckIP();

            app.UseAuthentication();
            app.AddNLogWeb();

            var options = new RewriteOptions();
            options.Rules.Add(new NonWwwRule());
            options.Rules.Add(new NonSlashRule());
            app.UseRewriter(options);


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
