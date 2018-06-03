using Core.DTO;
using Core.Services.ResponseModels;
using System.Collections.Generic;
using Core.DTO.CrearEstablecimientos;

namespace Core.Interfaces
{
    public interface IEstablecimientosService
    {
         OperationResult<IEnumerable<EstablecimientoDestacadosDTO>> getEstablecimientosDestacados(int limit,int offset);
         IEnumerable<CaracteristicasDTO> GetCaracteristicas();
         IEnumerable<BarrioDTO> GetBarrios();
         IEnumerable<GastronomiaDTO> GetGastronomia();
         PostResult<CrearEstablecimientosDTO> CrearEstablecimientos(CrearEstablecimientosDTO establecimiento);
    }
}