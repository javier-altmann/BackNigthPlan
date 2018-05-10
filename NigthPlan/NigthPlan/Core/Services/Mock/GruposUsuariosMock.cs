namespace Core.Services.Mock
{
    public class GruposUsuariosMock
    {
        public int IdGruposUsuarios { get; set; }
        public int? IdUsuarios { get; set; }
        public int? IdGrupo { get; set; }

        public GruposMock IdGrupoNavigation { get; set; }
        public UsuariosMock IdUsuariosNavigation { get; set; }
    }
}