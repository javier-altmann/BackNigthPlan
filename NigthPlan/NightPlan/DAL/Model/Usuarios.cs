using System;
using System.Collections.Generic;

namespace DAL.Model
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            GruposUsuarios = new HashSet<GruposUsuarios>();
            RespuestasUsuariosGrupos = new HashSet<RespuestasUsuariosGrupos>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string ImagenPerfil { get; set; }
        public string FechaNacimiento { get; set; }

        public ICollection<GruposUsuarios> GruposUsuarios { get; set; }
        public ICollection<RespuestasUsuariosGrupos> RespuestasUsuariosGrupos { get; set; }
    }
}
