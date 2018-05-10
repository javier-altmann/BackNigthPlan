using System;

namespace Core.Services.Mock
{
    public class VotacionesMock
    {
         public int IdVotacion { get; set; }
        public int? IdGrupo { get; set; }
        public int? IdEstablecimiento { get; set; }
        public DateTime? FechaDeRespuesta { get; set; }

        public EstablecimientosMock IdEstablecimientoNavigation { get; set; }
        public GruposMock IdGrupoNavigation { get; set; }
    }
}