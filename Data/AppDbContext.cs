using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Data;

// EF Core DbContext - wired up for SQL Server in production.
// The demo uses InMemoryDataStore (see InMemoryDataStore.cs) seeded with fake data,
// but this context is included to demonstrate the EF Core mapping/clean-architecture intent.
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Attendance> Attendances => Set<Attendance>();
    public DbSet<LeaveRequest> LeaveRequests => Set<LeaveRequest>();
    public DbSet<PerformanceReview> PerformanceReviews => Set<PerformanceReview>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasKey(e => e.Id);
        modelBuilder.Entity<Department>().HasKey(d => d.Id);
        modelBuilder.Entity<Role>().HasKey(r => r.Id);
        modelBuilder.Entity<Attendance>().HasKey(a => a.Id);
        modelBuilder.Entity<LeaveRequest>().HasKey(l => l.Id);
        modelBuilder.Entity<PerformanceReview>().HasKey(p => p.Id);
    }
}
