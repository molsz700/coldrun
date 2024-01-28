using Coldrun.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Coldrun.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<Truck> Trucks { get; set; }
    }
}
