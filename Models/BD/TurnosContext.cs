using Microsoft.EntityFrameworkCore;
namespace CRUD_NetCore.Models.BD
{
    public class TurnosContext : DbContext
    {
        public TurnosContext(DbContextOptions<TurnosContext> opciones) : base(opciones)
        {

        }
        public DbSet<Especialidad> Especialidad { get; set; }
    }
}