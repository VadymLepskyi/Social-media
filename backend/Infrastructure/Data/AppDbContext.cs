using backend.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using backend.Domain.Entities;

namespace backend.Infrastructure.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
           base(options)
           {}
        
        public DbSet<UserProfile> UserProfiles {get;set;}
        public DbSet<UserPost> UserPosts { get; set;}
        protected override  void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // UserProfile table
            modelBuilder.Entity<UserProfile>(entity =>
            {   
                entity.HasKey(u => u.Id);
                entity.Property(u => u.KeycloakId)
                .IsRequired()
                .HasMaxLength(255);
                entity.Property(u => u.UserName).HasMaxLength(100);
                entity.Property(u => u.City).HasMaxLength(100);
                entity.Property(u => u.Bio).HasMaxLength(500);
                entity.Property(u => u.SkillLevel)
                .HasConversion<string>()
                .HasMaxLength(50)
                .HasDefaultValue(SkillLevel.Beginner);
                entity.Property(u => u.ProfilePhotoUrl).HasMaxLength(255);
                entity.Property(u => u.CreatedAt).HasDefaultValueSql("NOW()");
                entity.Property(u => u.UpdatedAt).HasDefaultValueSql("NOW()");
            });
            modelBuilder.Entity<UserPost>(entity =>
            {
                 entity.HasKey(u =>u.PostId);
                 entity.HasOne<UserProfile>()           // A post has one user
                 .WithMany(u => u.Posts)                          // A user can have many posts
                 .HasForeignKey(u => u.UserProfileId)   // Map foreign key column
                 .OnDelete(DeleteBehavior.Cascade);     // Optional: delete posts when user is deleted
                 entity.Property(u=>u.PostContent).HasMaxLength(500);
                 entity.Property(u=>u.PostMediaUrl).HasMaxLength(255);
                 entity.Property( u=>u.CreatedAt).HasDefaultValueSql("NOW()");
                 entity.Property(u => u.UpdatedAt).HasDefaultValueSql("NOW()");
            });
        }
        
    }
}