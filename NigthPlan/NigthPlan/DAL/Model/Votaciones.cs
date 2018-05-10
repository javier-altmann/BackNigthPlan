using System;
using System.Collections.Generic;

namespace DAL.Model
{
    public partial class Votaciones
    {
        public int IdVotacion { get; set; }
        public int? IdGrupo { get; set; }
        public int? IdEstablecimiento { get; set; }
        public DateTime? FechaDeRespuesta { get; set; }

        public Establecimientos IdEstablecimientoNavigation { get; set; }
        public Grupos IdGrupoNavigation { get; set; }
    }
}
