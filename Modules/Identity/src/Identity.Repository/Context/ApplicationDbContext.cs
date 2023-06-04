using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Identity.Repository.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
