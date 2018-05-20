using System;
using System.Collections.Generic;

namespace DAL.Model
{
    public partial class EstadoDePreferencias
    {
        public int IdEstadoDePreferencias { get; set; }
        public int? IdGrupo { get; set; }
        public int? ContadorPreferenciasElegidas { get; set; }
        public int? CantidadUsuariosPorGrupo { get; set; }

        public Grupos IdGrupoNavigation { get; set; }
    }
}
