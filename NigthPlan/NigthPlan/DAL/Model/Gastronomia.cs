using System;
using System.Collections.Generic;

namespace DAL.Model
{
    public partial class Gastronomia
    {
        public Gastronomia()
        {
            EstablecimientosGastronomia = new HashSet<EstablecimientosGastronomia>();
        }

        public int IdGastronomia { get; set; }
        public string Nombre { get; set; }

        public ICollection<EstablecimientosGastronomia> EstablecimientosGastronomia { get; set; }
    }
}
