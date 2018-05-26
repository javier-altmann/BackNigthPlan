using DAL.Interfaces;
using Core.DTO;
using Core.Services.ResponseModels;
using System.Collections.Generic;
using Core.DTO.CrearEstablecimientos;

namespace Core.Interfaces
{
    public interface IEstablecimientosService
    {
         OperationResult<IEnumerable<EstablecimientoDTO>> getEstablecimientosDestacados(int offset, int limit);
         IEnumerable<CaracteristicasDTO> GetCaracteristicas();
         IEnumerable<BarrioDTO> GetBarrios();
         IEnumerable<GastronomiaDTO> GetGastronomia();

         PostResult<CrearEstablecimientosDTO> CrearEstablecimientos();
    }
}