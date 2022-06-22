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
        public DbSet<MedicoEspecialidad> MedicoEspecialidad { get; set; }
        public DbSet<Turno> Turno { get;set; }
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
            modelBuilder.Entity<Medico>(medico => {
                medico.ToTable("Medico");
                medico.HasKey(m => m.IdMedico);
                medico.Property(m => m.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                medico.Property(m => m.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                medico.Property(m => m.Direccion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
                medico.Property(m => m.Telefono)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
                medico.Property(m => m.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                medico.Property(m => m.HorarioAtencionDesde)
                    .IsRequired()
                    .IsUnicode(false);
                medico.Property(m => m.HorarioAtencionHasta)
                    .IsRequired()
                    .IsUnicode(false);
            });
            modelBuilder.Entity<MedicoEspecialidad>().HasKey(me => new { me.IdMedico, me.IdEspecialidad });
            modelBuilder.Entity<MedicoEspecialidad>().HasOne(x => x.Medico)
                    .WithMany(p => p.MedicoEspecialidad)
                    .HasForeignKey(p => p.IdMedico);
            modelBuilder.Entity<MedicoEspecialidad>().HasOne(x => x.Especialidad)
                    .WithMany(p => p.MedicoEspecialidad)
                    .HasForeignKey(p => p.IdEspecialidad);
            modelBuilder.Entity<Turno>(turno => {
                turno.ToTable("Turno");
                turno.HasKey(m => m.IdTurno);
                turno.Property(m => m.IdPaciente)
                    .IsRequired()
                    .IsUnicode(false);
                turno.Property(m => m.IdMedico)
                    .IsRequired()
                    .IsUnicode(false);
                turno.Property(m => m.FechaHoraInicio)
                    .IsRequired()
                    .IsUnicode(false);
                turno.Property(m => m.FechaHoraFin)
                    .IsRequired()
                    .IsUnicode(false);
            });
            modelBuilder.Entity<Turno>().HasOne(x => x.Paciente)
                    .WithMany(t => t.Turno)
                    .HasForeignKey(t => t.IdPaciente);
            modelBuilder.Entity<Turno>().HasOne(x => x.Medico)
                    .WithMany(t => t.Turno)
                    .HasForeignKey(t => t.IdMedico);
        }

        
    }
}