using System.Collections.Generic;
using DAL.Model;

namespace Core.Services.ResponseModels
{
    public class ResponseCrearGrupoDTO
    {
        public Grupos Grupos { get; set; }
        public IEnumerable<GruposUsuarios> GruposDelUsuario { get; set; }
        public EstadoDePreferencias EstadoDePreferencias { get; set; }
        public string Message { get; set; }
        public bool Succes { get; set; }
    }
}