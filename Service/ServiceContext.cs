using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class ServiceContext : DbContext
    {
        public DbSet<RouteSheet> RouteSheets { get; set; }
        public DbSet<RoutePoint> RoutePoints { get; set; }
        public DbSet<RouteMark> RouteMarks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=server");
        }
    }
}