namespace Core.DTO
{
    public class GuardarPreferenciasDTO
    {
        public int IdUsuario { get; set; }
        public int IdGrupo { get; set; }
        public string Respuesta { get; set; }

        public int? ContadorDePreferencias { get; set; }

    }
}