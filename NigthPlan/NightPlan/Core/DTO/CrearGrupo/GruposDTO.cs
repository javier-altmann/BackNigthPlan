using System.ComponentModel.DataAnnotations;

namespace Core.DTO.CrearGrupo
{
    public class GruposDTO
    {
        [Required]
        public string NombreDelGrupo { get; set; }
        public string Imagen { get; set; }

        [Required(ErrorMessage="El campo idUsuario es obligatorio")]
        public UsuariosGrupoDTO[] usuarios { get; set; }

    }
}