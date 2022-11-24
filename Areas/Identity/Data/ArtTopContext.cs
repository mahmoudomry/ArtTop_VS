using ArtTop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtTop.Data;

public class ArtTopContext : IdentityDbContext<ApplicationUser>
{
    public ArtTopContext(DbContextOptions<ArtTopContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.Entity<Client>().ToTable("Client");
        builder.Entity<Feature>().ToTable("Feature");
        builder.Entity<NewsLetter>().ToTable("NewsLetter");
        builder.Entity<Project>().ToTable("Project");
        builder.Entity<Slider>().ToTable("Slider");
        builder.Entity<SiteSetting>().ToTable("SiteSetting");
        builder.Entity<Service>().ToTable("Service");
    }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<NewsLetter> NewsLetters { get; set; }
    
    public DbSet<Project> Projects { get; set; }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<SiteSetting> SiteSettings { get; set; }
    public DbSet<Service> Services { get; set; }
}
internal class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(x => x.FullName).HasMaxLength(250);

    }
}
