using System;
using System.Collections.Generic;

namespace DAL.Model
{
    public partial class Caracteristicas
    {
        public Caracteristicas()
        {
            EstablecimientoCaracteristicas = new HashSet<EstablecimientoCaracteristicas>();
        }

        public int IdCaracteristica { get; set; }
        public string Nombre { get; set; }

        public ICollection<EstablecimientoCaracteristicas> EstablecimientoCaracteristicas { get; set; }
    }
}
