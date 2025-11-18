using Microsoft.EntityFrameworkCore;
using UserSegment.Models;

namespace UserSegment.Data
{
    /// <summary>
    /// Application DbContext for user and related entities.
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Users table.
        /// </summary>
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ensure username is unique at the database level
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            // (Optional) enforce max lengths from annotations at the fluent level if desired:
            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .HasMaxLength(256)
                .IsRequired();
        }

        public DbSet<ClassEntryModel> ClassEntryModels { get; set; }
        public DbSet<CourseEntryModel> CourseEntryModels { get; set; }
        public DbSet<RoomEntryModel> RoomEntryModels { get; set; }
        public DbSet<StaffEntryModel> StaffEntryModels { get; set; }
    }
}