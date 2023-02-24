using Microsoft.EntityFrameworkCore;

namespace Meetup.Event.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Domain.Entities.Event> Events { get; set; }
    }
}
