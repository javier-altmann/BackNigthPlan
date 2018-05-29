using System.ComponentModel.DataAnnotations;

namespace Core.DTO.CrearGrupo
{
    public class GruposDTO
    {
        [Required]
        public string NombreDelGrupo { get; set; }
        public string Imagen { get; set; }
        [Required]
        public UsuariosGrupoDTO[] usuarios { get; set; }

    }
}