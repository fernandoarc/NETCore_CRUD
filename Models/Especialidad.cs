using System.ComponentModel.DataAnnotations;
namespace CRUD_NetCore.Models
{
    public class Especialidad
    {
        [Key]
        public int IdEspecialidad { get; set; }
        public string Descripcion { get; set; }
    }
}