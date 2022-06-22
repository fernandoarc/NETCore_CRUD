using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NETCore_CRUD.Models
{
    public class Medico
    {
        [Key]
        public int IdMedico { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Apellido { get; set; }

        [Display(Name="Dirección")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name="Teléfono")]
        public int Telefono { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [EmailAddress(ErrorMessage="Debe ingresar una casilla de correo válida")]
        public string Email { get; set; }
        
        [Display(Name="Horario desde")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString="{0:hh:mm tt}", ApplyFormatInEditMode=true)]
        public DateTime HorarioAtencionDesde { get; set; }
        
        [Display(Name="Horario hasta")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString="{0:hh:mm tt}", ApplyFormatInEditMode=true)]
        public DateTime HorarioAtencionHasta { get; set; }
        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }

        public List<Turno> Turno { get; set; }
    }
}