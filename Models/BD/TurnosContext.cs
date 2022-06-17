using Microsoft.EntityFrameworkCore;
using NETCore_CRUD.Models;

namespace NETCore_CRUD.Models.BD
{
    public class TurnosContext : DbContext
    {
        public TurnosContext(DbContextOptions<TurnosContext> opciones) : base(opciones)
        {

        }
        public DbSet<Especialidad> Especialidad { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Medico> Medico { get; set; }
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
            modelBuilder.Entity<Paciente>(entidad => {
                entidad.ToTable("Paciente");
                entidad.HasKey(p => p.IdPaciente);
                entidad.Property(p => p.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entidad.Property(p => p.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entidad.Property(p => p.Direccion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entidad.Property(p => p.Email)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entidad.Property(p => p.Telefono)
                    .IsRequired();
            });
        }

        
    }
}