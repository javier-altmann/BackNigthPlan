using DAL.Interfaces;
using Core.DTO;
using Core.Services.ResponseModels;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IEstablecimientosService
    {
         OperationResult<IEnumerable<EstablecimientoDTO>> getEstablecimientosDestacados(int offset, int limit);
         IEnumerable<CaracteristicasDTO> GetCaracteristicas();
         IEnumerable<BarrioDTO> GetBarrios();
         IEnumerable<GastronomiaDTO> GetGastronomia();
    }
}