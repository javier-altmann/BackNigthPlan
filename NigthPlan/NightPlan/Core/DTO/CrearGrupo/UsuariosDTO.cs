using System.ComponentModel.DataAnnotations;

namespace Core.DTO.CrearGrupo
{
     
    public class UsuariosGrupoDTO
    {
        [Required(ErrorMessage="No se está enviando ningún idUsuario")]
        public int IdUsuario { get; set; }
    }
}