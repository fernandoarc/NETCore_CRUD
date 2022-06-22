using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NETCore_CRUD.Models
{
    public class Paciente
    {
        [Key]
        public int IdPaciente { get; set; }
        
        [Display(Name="Nombre")]
        [Required(ErrorMessage="Campo obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage="Campo obligatorio")]
        public string Apellido { get; set; }

        [Required(ErrorMessage="Campo obligatorio")]
        [Display(Name="Dirección")]
        public string Direccion { get; set; }

        [Range(11111111,99999999)]
        [Required(ErrorMessage="Campo obligatorio")]
        public int Telefono { get; set; }

        [Required(ErrorMessage="Campo obligatorio")]
        [EmailAddress(ErrorMessage="Debe ingresar un mail válido")]
        public string Email { get; set; }

        public List<Turno> Turno { get; set; }
    }
}