using Meetup.Event.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Meetup.Event.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=events;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        public DbSet<Entities.Event> Events { get; set; }
        //public DbSet<User> Users { get; set; }
    }
}
