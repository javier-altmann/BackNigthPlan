using System.Collections.Generic;

namespace Core.DTO
{
    public class PreferenciasDTO
    {
   
    public bool Response { get; set; }
    public List<int> IdsBarrios { get; set; }
    public List<int> IdsGastronomia { get; set; }
    public List<int> IdsCaracteristicas { get; set; }

    }
}