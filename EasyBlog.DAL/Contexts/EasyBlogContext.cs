using EasyBlog.Core.Entities;
using EasyBlog.DAL.Mappings;
using Microsoft.EntityFrameworkCore;

namespace EasyBlog.DAL.Contexts
{
    public class EasyBlogContext : DbContext
    {
        // https://docs.microsoft.com/en-us/ef/core/miscellaneous/configuring-dbcontext
        public EasyBlogContext(DbContextOptions<EasyBlogContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new PostMap());

            // todo review
            //modelBuilder.Entity<User>().HasData(new User
            //{
            //    Email = "admin@example.com",
            //    Username = "admin@example.com",
            //    PasswordHash = "123456" // undone hashed password
            //});

            base.OnModelCreating(modelBuilder);
        }
    }
}
