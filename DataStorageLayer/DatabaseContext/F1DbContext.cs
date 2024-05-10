using DataStorageLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataStorageLayer.DatabaseContext
{
    public class F1DbContext : DbContext
    {
        public DbSet<Pilot> Pilots { get; set; }

        public DbSet<Team> Teams { get; set; }

        public F1DbContext(DbContextOptions<F1DbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        //    optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=F1Project;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}