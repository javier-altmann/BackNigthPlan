using System.ComponentModel.DataAnnotations;

namespace Core.DTO.CrearGrupo
{
     
    public class UsuariosGrupoDTO
    {
        [Required]
        public int IdUsuario { get; set; }
    }
}