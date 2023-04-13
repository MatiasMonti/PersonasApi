using Microsoft.EntityFrameworkCore;
using PeoplesApi.Tables;

namespace PeoplesApi.Aplication
{
    public class AplicationDBContext : DbContext
    {

        public AplicationDBContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>().HasData(
                new People { ID = 1, Name = "Matias", Surname = "Monti" },
                new People { ID = 2, Name = "Juan", Surname = "Perez" },
                new People { ID = 3, Name = "Mario", Surname = "Lopez" }
            );
        }

        public DbSet<People> People { get; set; }
    }
}
