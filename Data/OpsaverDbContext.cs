using Microsoft.EntityFrameworkCore;
using opsaver.Models;

namespace opsaver.Data
{
    public class OpsaverDbContext : DbContext
    {
        public OpsaverDbContext(DbContextOptions<OpsaverDbContext> options)
        : base(options)
        {
        }

        public DbSet<Medico> Medicos { get; set; }

        public DbSet<Clinica> Clinicas { get; set; }
    }
}
