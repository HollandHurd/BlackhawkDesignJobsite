using Microsoft.EntityFrameworkCore;
using BlackhawkDesign.Data.Models;

namespace BlackhawkDesign.Data;
[Coalesce]
public class AppDbContext : DbContext
{
    /*
    public DbSet<Application> Applications => Set<Application>();
    public DbSet<Job> Jobs => Set<Job>();*/
    
    public DbSet<Application> Applications => Set<Application>();
    public DbSet<JobApplication> JobApplications => Set<JobApplication>();
    public DbSet<Job> Jobs => Set<Job>();

    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Application>()
            .ToTable("Applications")
            .HasOne(c => c.AttachmentContent)
            .WithOne()
            .HasForeignKey<ApplicationAttachmentContent>(c => c.NormalizedName);

        builder.Entity<ApplicationAttachmentContent>()
            .ToTable("Applications")
            .HasKey(d => d.NormalizedName);

        // Remove cascading deletes.
        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }

}
