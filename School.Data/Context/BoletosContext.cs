

using Microsoft.EntityFrameworkCore;
using School.Data.Entities;

namespace School.Data.Context
{
    public class BoletosContext : DbContext
    {
        public BoletosContext(DbContextOptions<BoletosContext> options) : base(options)
        {
                
        }
        public BoletosContext()
        {
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("BoletoBus");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Asiento> Asientos { get; set; }
    }
}
