using DB.Models;
using Microsoft.EntityFrameworkCore;
 
namespace DB.DB_Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Advertisement> Advertisements { get; set; }
        
        public DbSet<Expense> Expenses { get; set; }
        
        public DbSet<Organization> Organizations { get; set; }
        
        public DbSet<OrganizationMember> OrganizationMembers { get; set; }
        
        public DbSet<User> Users { get; set; }

        public DbSet<VolonteerInfo> VolonteerInfos { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}