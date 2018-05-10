using System;
using System.Collections.Generic;

namespace DAL.Model
{
    public partial class UsuariosAdministradores
    {
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
    }
}
