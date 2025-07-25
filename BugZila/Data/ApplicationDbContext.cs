using BugZila.Models;
using Microsoft.EntityFrameworkCore;

namespace BugZila.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Bugs> Bugs { get; set; }
        public DbSet<ProjectUser> ProjectUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bugs>()
              .HasIndex(b => new { b.ProjectID, b.Title })
              .IsUnique();
            modelBuilder.Entity<ProjectUser>()
                .HasKey(ep => new { ep.UserID, ep.ProjectID });

            modelBuilder.Entity<ProjectUser>().
                HasOne(ep => ep.User)
                .WithMany(e => e.ProjectUsers)
                .HasForeignKey(ep => ep.UserID)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<ProjectUser>().
                HasOne(ep => ep.Project)
                .WithMany(e => e.ProjectUsers)
                .HasForeignKey(ep => ep.ProjectID)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Bugs>()
               .HasOne(b => b.Creator)
               .WithMany(u => u.CreatedBugs)
               .HasForeignKey(b => b.CreatorID)
               .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<Projects>()
           .HasOne(p => p.Manager)
           .WithMany(u => u.ManagedProjects)
           .HasForeignKey(p => p.ManagerID)
           .OnDelete(DeleteBehavior.SetNull); // ✅

            modelBuilder.Entity<Bugs>()
         .HasOne(b => b.Developer)
         .WithMany(u => u.DeveloperBugs)
         .HasForeignKey(b => b.DeveloperID)
         .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
