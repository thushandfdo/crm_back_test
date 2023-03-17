using crm_back_test.Models;
using Microsoft.EntityFrameworkCore;

namespace crm_back_test.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<LoginUser> LoginUsers { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Enduser> Endusers { get; set; }
    }
}
