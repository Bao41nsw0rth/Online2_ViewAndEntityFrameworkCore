using Microsoft.EntityFrameworkCore;
using Online2.Models;
using Online2.Models.Views;

namespace Online2.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Device> Devices { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        // Materialized views
        public DbSet<ViewServiceStatistics> ServiceStatistics { get; set; }
        public DbSet<ViewAssignmentUsageStatistics> AssignmentUsageStatistics { get; set; }
        public DbSet<ViewAssignmentsPerDevice> AssignmentsPerDevice { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ViewServiceStatistics>().HasNoKey().ToView("view_service_statistics","public");
            modelBuilder.Entity<ViewAssignmentUsageStatistics>().HasNoKey().ToView("view_assignment_usage_statistics","public");
            modelBuilder.Entity<ViewAssignmentsPerDevice>().HasNoKey().ToView("view_assignments_per_device","public");
        }
    }
}
