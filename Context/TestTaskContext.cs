using Microsoft.EntityFrameworkCore;
using TestTask.Models;

namespace TestTask.Context;

public class TestTaskContext : DbContext
{
    public DbSet<Cabinet> Cabinets { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Sector> Sectors { get; set; }
    public DbSet<Specialization> Specializations { get; set; }
    
    public TestTaskContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>().
            Property(p => p.BirthDate)
            .HasColumnType("date");
    }
}
