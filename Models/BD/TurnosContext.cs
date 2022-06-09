using Microsoft.EntityFrameworkCore;
namespace CRUD_NetCore.Models.BD
{
    public class TurnosContext : DbContext
    {
        public TurnosContext(DbContextOptions<TurnosContext> opciones) : base(opciones)
        {

        }
        public DbSet<Especialidad> Especialidad { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configuraciones a implementar al momento de crear tabla en el sql server
            modelBuilder.Entity<Especialidad>(entidad => {
                entidad.ToTable("Especialidad");//nombre de la tabla en sql server
                entidad.HasKey(e => e.IdEspecialidad);//especificando primary key
                entidad.Property(e => e.Descripcion)
                    .IsRequired()//campo obligatorio
                    .HasMaxLength(200)//largo maximo
                    .IsUnicode(false);//campo unicode
            });
        }
    }
}