namespace Core.DTO
{
    public class EstablecimientoDestacadosDTO
    {
    
        public int IdEstablecimiento { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public string Direccion { get; set; }
        public string Barrio { get; set; }
        public sbyte Destacado { get; set; }
        
    }
}