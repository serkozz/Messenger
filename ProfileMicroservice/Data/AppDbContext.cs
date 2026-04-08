using Microsoft.EntityFrameworkCore;
using ProfileMicroservice.Data.Models;

namespace ProfileMicroservice.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<UserProfileModel> UserProfiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserProfileModel>(entity =>
        {
            entity.HasIndex(e => e.UserId)
                .IsUnique();

            entity.HasIndex(e => e.Username)
                .IsUnique();

            entity.HasIndex(e => e.PhoneNumber)
                .IsUnique();
        });
    }
}