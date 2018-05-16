using System;
using System.Collections.Generic;

namespace DAL.Model
{
    public partial class GruposUsuarios
    {
        public int IdGruposUsuarios { get; set; }
        public int? IdUsuarios { get; set; }
        public int? IdGrupo { get; set; }

        public Grupos IdGrupoNavigation { get; set; }
        public Usuarios IdUsuariosNavigation { get; set; }
    }
}
