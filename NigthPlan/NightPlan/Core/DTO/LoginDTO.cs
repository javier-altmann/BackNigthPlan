using System.ComponentModel.DataAnnotations;

namespace Core.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage="Falta ingresar el usuario")]
        public string Username { get; set; }
        [Required(ErrorMessage="Falta ingresar la contraseña")]
        public string Password { get; set; }
    }
}