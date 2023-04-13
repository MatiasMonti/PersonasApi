using PeoplesApi.Models;
using System.Data.Entity;
using System.Reflection.Emit;

namespace PeoplesApi.Aplication
{
    public class AplicationDBContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public DbSet<People> People { get; set; }
    }
}
