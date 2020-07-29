using Microsoft.EntityFrameworkCore;
using MindPalace.Server.Entities;

namespace MindPalace.Server.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Link> Links { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LinkTag>()
                .HasKey(t => new { t.LinkId, t.TagId});

            modelBuilder.Entity<LinkTag>()
                .HasOne(lt => lt.Link)
                .WithMany(l => l.LinkTags)
                .HasForeignKey(lt => lt.LinkId);

            modelBuilder.Entity<LinkTag>()
                .HasOne(lt => lt.Tag)
                .WithMany(t => t.LinkTags)
                .HasForeignKey(lt => lt.TagId);
        }
    }
}