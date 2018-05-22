namespace Core.DTO.CrearGrupo
{
    public class GruposDTO
    {
        public string NombreDelGrupo { get; set; }
        public string Imagen { get; set; }
        public UsuariosGrupoDTO[] usuarios { get; set; }

    }
}