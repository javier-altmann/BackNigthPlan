using System;
using System.Collections.Generic;

namespace DAL.Model
{
    public partial class EstablecimientoBarrios
    {
        public int IdEstablecimientosBarrios { get; set; }
        public int? IdBarrio { get; set; }
        public int? IdEstablecimiento { get; set; }

        public Barrios IdBarrioNavigation { get; set; }
        public Establecimientos IdEstablecimientoNavigation { get; set; }
    }
}
