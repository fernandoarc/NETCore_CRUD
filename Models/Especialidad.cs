using System.ComponentModel.DataAnnotations;
namespace NETCore_CRUD.Models
{
    public class Especialidad
    {
        [Key]
        public int IdEspecialidad { get; set; }
        public string Descripcion { get; set; }
    }
}