using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TypographicBlogger.Models;

namespace TypographicBlogger.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Analytics> Analytics { get; set; }

    }
}
