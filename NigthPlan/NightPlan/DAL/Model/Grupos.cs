using System;
using System.Collections.Generic;

namespace DAL.Model
{
    public partial class Grupos
    {
        public Grupos()
        {
            EstadoDePreferencias = new HashSet<EstadoDePreferencias>();
            GruposUsuarios = new HashSet<GruposUsuarios>();
            RespuestasUsuariosGrupos = new HashSet<RespuestasUsuariosGrupos>();
            Votaciones = new HashSet<Votaciones>();
        }

        public int IdGrupo { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public string FechaCreacion { get; set; }

        public ICollection<EstadoDePreferencias> EstadoDePreferencias { get; set; }
        public ICollection<GruposUsuarios> GruposUsuarios { get; set; }
        public ICollection<RespuestasUsuariosGrupos> RespuestasUsuariosGrupos { get; set; }
        public ICollection<Votaciones> Votaciones { get; set; }
    }
}
