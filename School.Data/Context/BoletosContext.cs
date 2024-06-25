

using Microsoft.EntityFrameworkCore;
using School.Data.Entities;

namespace School.Data.Context
{
    public class BoletosContext : DbContext
    {
        public BoletosContext(DbContextOptions<BoletosContext> options) : base(options)
        {
                
        }

        public DbSet<Asiento> Asientos { get; set; }
    }
}
