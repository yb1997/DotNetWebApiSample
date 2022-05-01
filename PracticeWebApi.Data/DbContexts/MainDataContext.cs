using Microsoft.EntityFrameworkCore;
using PracticeWebApi.Data.Entities;
using System.Reflection;

namespace PracticeWebApi.Data.DbContexts
{
    public class MainDataContext : DbContext
    {
        public MainDataContext(DbContextOptions<MainDataContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
