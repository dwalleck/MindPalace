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
    }
}