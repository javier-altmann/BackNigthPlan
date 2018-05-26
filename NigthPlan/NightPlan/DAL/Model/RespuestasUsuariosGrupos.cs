using System;
using System.Collections.Generic;

namespace DAL.Model
{
    public partial class RespuestasUsuariosGrupos
    {
        public int IdRespuestasUsuario { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdGrupo { get; set; }
        public string Respuestas { get; set; }
        public bool Respondio { get; set; }

        public Grupos IdGrupoNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
    }
}
