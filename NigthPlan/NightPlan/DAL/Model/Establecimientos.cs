using System;
using System.Collections.Generic;

namespace DAL.Model
{
    public partial class Establecimientos
    {
        public Establecimientos()
        {
            EstablecimientoBarrios = new HashSet<EstablecimientoBarrios>();
            EstablecimientoCaracteristicas = new HashSet<EstablecimientoCaracteristicas>();
            EstablecimientosGastronomia = new HashSet<EstablecimientosGastronomia>();
            Votaciones = new HashSet<Votaciones>();
        }

        public int IdEstablecimiento { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Imagen { get; set; }
        public sbyte Destacado { get; set; }

        public ICollection<EstablecimientoBarrios> EstablecimientoBarrios { get; set; }
        public ICollection<EstablecimientoCaracteristicas> EstablecimientoCaracteristicas { get; set; }
        public ICollection<EstablecimientosGastronomia> EstablecimientosGastronomia { get; set; }
        public ICollection<Votaciones> Votaciones { get; set; }
    }
}
