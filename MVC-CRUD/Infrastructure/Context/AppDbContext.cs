using Microsoft.EntityFrameworkCore;
using MVC_CRUD.Infrastructure.EntityTypeConfiguration.Concrete;
using MVC_CRUD.Models.Entities.Concrete;

namespace MVC_CRUD.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
