using System;
using System.Collections.Generic;

namespace DAL.Model
{
    public partial class Barrios
    {
        public Barrios()
        {
            EstablecimientoBarrios = new HashSet<EstablecimientoBarrios>();
        }

        public int IdBarrio { get; set; }
        public string Nombre { get; set; }

        public ICollection<EstablecimientoBarrios> EstablecimientoBarrios { get; set; }
    }
}
