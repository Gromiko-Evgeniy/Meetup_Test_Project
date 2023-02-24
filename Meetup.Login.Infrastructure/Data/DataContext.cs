using Meetup.Login.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Meetup.Login.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
