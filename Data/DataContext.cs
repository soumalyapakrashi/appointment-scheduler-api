using appointment_scheduler_api.Models;
using Microsoft.EntityFrameworkCore;

namespace appointment_scheduler_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users => Set<User>();
    }
}