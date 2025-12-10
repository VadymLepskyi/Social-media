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
        public DbSet<SkillCommunity> SkillCommunities {get;set;}
        public DbSet<CommunityPost> CommunityPosts {get;set;}
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
                entity.Property(u => u.SkillCommunityId);
            
            });
            modelBuilder.Entity<UserPost>(entity =>
            {
                 entity.HasKey(u =>u.PostId);
                 
                 entity.HasOne(u=>u.UserProfile)        // Each post belongs to one user
                 .WithMany(u => u.Posts)                // Each user can have many posts
                 .HasForeignKey(u => u.UserProfileId)   // UserProfileId is the foreign key in UserPost
                 .OnDelete(DeleteBehavior.Cascade);     // When a user is deleted, delete all their posts
                 
                 entity.Property(u=>u.PostContent).HasMaxLength(500);
                 entity.Property(u=>u.PostMediaUrl).HasMaxLength(255);
                 entity.Property( u=>u.CreatedAt).HasDefaultValueSql("NOW()");
                 entity.Property(u => u.UpdatedAt).HasDefaultValueSql("NOW()");
            });
           modelBuilder.Entity<SkillCommunity>(entity =>
            {
                
                entity.HasKey(c => c.Id);
                entity.HasIndex(c => c.Level);
                entity.Property(c => c.Name).IsRequired().HasMaxLength(100);

                entity.HasMany(c => c.Members)
                    .WithOne(u => u.SkillCommunity)
                    .HasForeignKey(u => u.SkillCommunityId);
                 

                entity.HasMany(c => c.CommunityPosts)
                    .WithOne(p => p.SkillCommunity)
                    .HasForeignKey(p => p.SkillCommunityId)
                    .OnDelete(DeleteBehavior.Restrict);
                 
                    

                entity.Property(c => c.CreatedAt).HasDefaultValueSql("NOW()");
            });

            modelBuilder.Entity<CommunityPost>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.HasOne(c => c.UserProfile)
                    .WithMany(u => u.CommunityPosts)
                    .HasForeignKey(c => c.UserProfileId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(c => c.SkillCommunity)
                    .WithMany(c => c.CommunityPosts)
                    .HasForeignKey(c => c.SkillCommunityId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(c => c.Content).HasMaxLength(2000);
                entity.Property(c => c.MediaUrl).HasMaxLength(500);
                entity.Property(c => c.CreatedAt).HasDefaultValueSql("NOW()");

            });

        }
        
    }
}