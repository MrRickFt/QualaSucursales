using BackEndSucursales.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndSucursales.Persistence.Context
{
    public class AplicationDbContext:DbContext 
    {
        public DbSet<Moneda> Monedas_Quala{ get; set; }
        public DbSet<Usuario> Usuarios_Quala { get; set; }
        public DbSet<Sucursal> Sucursal_Quala { get; set; }
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
    }
}
