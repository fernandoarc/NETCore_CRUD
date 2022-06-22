using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace NETCore_CRUD.Models
{
    public class Especialidad
    {
        [Key]
        public int IdEspecialidad { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]//indicar que el campo es obligatorio
        [StringLength(200, ErrorMessage="Máximo 200 caracteres")]//indicar largo máximo permitido del campo
        [Display(Name = "Descripción", Prompt = "Ingrese una descripción")]//alias a mostrar al usuario
        public string Descripcion { get; set; }
        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }
    }
}