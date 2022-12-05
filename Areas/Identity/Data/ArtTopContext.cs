using ArtTop.Areas.Identity.Data;
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
        builder.Entity<ContactItem>().ToTable("ContactItem");
        builder.Entity<SocialMedia>().ToTable("SocialMedia");
        builder.Entity<About>().ToTable("About");
        builder.Entity<OurGoles>().ToTable("OurGoles");
        builder.Entity<OurValues>().ToTable("OurValues");
        builder.Entity<ServiceSlider>().ToTable("ServiceSlider");
        builder.Entity<SubService>().ToTable("SubServices");
        builder.Entity<Office>().ToTable("Office");
        builder.Entity<OfficeSlider>().ToTable("OfficeSlider");
        builder.Entity<OfficeSubServices>().ToTable("OfficeSubServices");
        builder.Entity<OfficeSocialMedia>().ToTable("OfficeSocialMedias");
    }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<NewsLetter> NewsLetters { get; set; }

    public DbSet<Project> Projects { get; set; }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<SiteSetting> SiteSettings { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<ContactItem> ContactItem { get; set; }
    public DbSet<SocialMedia> SocialMedia { get; set; }
    public DbSet<About> Abouts { get; set; }
    public DbSet<OurGoles> OurGoles { get; set; }
    public DbSet<OurValues> OurValues { get; set; }
    public DbSet<ArtTop.Models.ServiceSlider> ServiceSlider{ get; set; }
    public DbSet<ArtTop.Models.SubService> SubServices { get; set; }
    public DbSet<Office> Offices { get; set; }
    public DbSet<OfficeSlider> OfficeSliders { get; set; }
    public DbSet<OfficeSubServices> OfficeSubServices { get; set; }
    public DbSet<OfficeSocialMedia> OfficeSocialMedias { get; set; }


}
internal class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(x => x.FullName).HasMaxLength(250);

    }
}
