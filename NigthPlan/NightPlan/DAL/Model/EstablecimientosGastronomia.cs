using System;
using System.Collections.Generic;

namespace DAL.Model
{
    public partial class EstablecimientosGastronomia
    {
        public int IdEstablecimientosGastronomia { get; set; }
        public int? IdGastronomia { get; set; }
        public int? IdEstablecimiento { get; set; }

        public Establecimientos IdEstablecimientoNavigation { get; set; }
        public Gastronomia IdGastronomiaNavigation { get; set; }
    }
}
