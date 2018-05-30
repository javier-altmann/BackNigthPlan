using System.ComponentModel.DataAnnotations;

namespace Core.DTO
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        [Required(ErrorMessage="El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage="El nombre es obligatorio")]
        public string Apellido { get; set; }
        [Required(ErrorMessage="El mail es obligatorio")]
        public string Mail { get; set; }
        public string ImagenPerfil { get; set; }
        [Required(ErrorMessage="La fecha de nacimiento es obligatoria")]
        public string FechaNacimiento { get; set; }
    }
}