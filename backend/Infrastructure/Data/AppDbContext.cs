
using Microsoft.EntityFrameworkCore;
using backend.Domain.Entities;

namespace backend.Infrastructure.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
           base(options)
           {}
   
        public DbSet<User> Users { get; set; }
        protected override  void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Username).HasMaxLength(255);
                entity.Property(u => u.SkillLevel).IsRequired();
                entity.Property(u => u.ProfilePhotoUrl).HasMaxLength(255);
                entity.Property(u => u.CreatedAt).HasDefaultValueSql("NOW()");
                entity.Property(u => u.UpdatedAt).HasDefaultValueSql("NOW()");
            });
        }
    }
}