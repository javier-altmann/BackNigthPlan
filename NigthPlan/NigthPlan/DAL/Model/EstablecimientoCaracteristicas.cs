using System;
using System.Collections.Generic;

namespace DAL.Model
{
    public partial class EstablecimientoCaracteristicas
    {
        public int IdEstablecimientosCaracteristicas { get; set; }
        public int? IdCaracteristica { get; set; }
        public int? IdEstablecimiento { get; set; }

        public Caracteristicas IdCaracteristicaNavigation { get; set; }
        public Establecimientos IdEstablecimientoNavigation { get; set; }
    }
}
