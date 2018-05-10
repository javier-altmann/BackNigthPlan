using System.Collections.Generic;

namespace Core.Services.Mock
{
    public class GruposMock
    {
         public int IdGrupo { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public string FechaCreacion { get; set; }

        public ICollection<GruposUsuariosMock> GruposUsuarios { get; set; }
       // public ICollection<RespuestasUsuariosGruposMock> RespuestasUsuariosGrupos { get; set; }
        public ICollection<VotacionesMock> Votaciones { get; set; }
    }
}