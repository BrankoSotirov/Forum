using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Forum.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Thread = Forum.Infrastructure.Data.Models.Thread;

namespace Forum.Infrastructure.Data
{
    public class ForumDbContext : IdentityDbContext<IdentityUser>
    {
        public ForumDbContext(DbContextOptions<ForumDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Models.Thread> Threads { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships using Fluent API

            // Category -> Thread (One-to-Many)
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Threads)
                .WithOne(t => t.Category)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Thread -> Post (One-to-Many)
            modelBuilder.Entity<Thread>()
        .HasMany(t => t.Posts) // Ensure this matches the property name in Thread
        .  WithOne(p => p.Thread)
        .HasForeignKey(p => p.ThreadId)
        .OnDelete(DeleteBehavior.NoAction);
           
            // Post -> Comment (One-to-Many)
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            // User -> Category (One-to-Many)
            modelBuilder.Entity<Category>()
                .HasOne(c => c.Creator)
                .WithMany()
                .HasForeignKey(c => c.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

            // User -> Thread (One-to-Many)
            modelBuilder.Entity<Models.Thread>()
                .HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // User -> Post (One-to-Many)
            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // User -> Comment (One-to-Many)
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}