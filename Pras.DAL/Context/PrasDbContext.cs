using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pras.DAL.Entities;

namespace Pras.DAL.Context
{
    public class PrasDbContext : IdentityDbContext<ApplicationUser>
    {
        public PrasDbContext(DbContextOptions<PrasDbContext> options)
            : base(options)
        {
        }

        public DbSet<Audio> Audios { get; set; }
        public DbSet<Information> Informations { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public int Commit()
        {
            return SaveChanges();
        }
    }
}
