using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace net_test.Models{
    public class ApplicationDBContext : IdentityDbContext<AspNetUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ASPNETUSERS
            modelBuilder.Entity<AspNetUser>().HasIndex(itemAspNetUser => new { itemAspNetUser.NormalizedUserName}).IsUnique(false);

        }

        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}