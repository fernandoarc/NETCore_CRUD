using System.ComponentModel.DataAnnotations;

namespace NETCore_CRUD.Models
{
    public class Paciente
    {
        [Key]
        public int IdPaciente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        [Range(11111111,99999999)]
        public int Telefono { get; set; }
        public string Email { get; set; }
    }
}