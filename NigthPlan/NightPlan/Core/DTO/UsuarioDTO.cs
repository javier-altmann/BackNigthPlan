namespace Core.DTO
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string ImagenPerfil { get; set; }
        public string FechaNacimiento { get; set; }
    }
}