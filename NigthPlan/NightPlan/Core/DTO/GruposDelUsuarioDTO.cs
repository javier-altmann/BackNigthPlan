using System.ComponentModel.DataAnnotations;

namespace Core.DTO
{
    public class GruposDelUsuarioDTO
    {
        [Required]
        public int IdGrupo { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string ImagenPerfil { get; set; }
        [Required]
        public string FechaCreacion { get; set; }

        
       
    }
}