using System;
using System.ComponentModel.DataAnnotations;

namespace NETCore_CRUD.Models
{
    public class Turno
    {
        [Key]
        public int IdTurno { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }

        [Display(Name="Fecha Hora Inicio")]
        public DateTime FechaHoraInicio { get; set; }
        
        [Display(Name="Fecha Hora Inicio")]
        public DateTime FechaHoraFin { get; set; }
        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
    }
}