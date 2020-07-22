namespace PetsLostAndFoundSystem.Statistics.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;
    using Models;

    public class StatisticsDbContext : DbContext
    {
        public StatisticsDbContext(DbContextOptions<StatisticsDbContext> options)
            : base(options)
        {
        }

        public DbSet<ReportView> ReportViews { get; set; }

        public DbSet<Statistics> Statistics { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
