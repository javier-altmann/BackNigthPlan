using DAL.Interfaces;
using DAL.Model;
using Core.DTO;
using Core.Interfaces;
using System.Collections.Generic;
using Core.Services.ResponseModels;
using System.Linq;
namespace Core.Services
{
    public class EstablecimientosService : IEstablecimientosService
    {
        private nightPlanContext context;
        public EstablecimientosService(nightPlanContext context)
        {
            this.context = context;
        }

        public OperationResult<IEnumerable<EstablecimientoDTO>> getEstablecimientosDestacados(int offset, int limit){
            
            var establecimientosDestacados = context.Establecimientos.Where(x=> x.Destacado == 1)
                                            .Select(y=> new EstablecimientoDTO{
                                                IdEstablecimiento = y.IdEstablecimiento,
                                                Nombre = y.Nombre,
                                                Imagen = y.Imagen,
                                                Direccion = y.Direccion,
                                                Destacado = y.Destacado
                                            }).OrderBy(ordenar=>ordenar.IdEstablecimiento)
                                            .Take(limit).Skip(offset).ToList();
            //Cambiar el harcode de Take y Skip. Hacer una clase paginacion
             var operationResult = new OperationResult<IEnumerable<EstablecimientoDTO>>();
          
            if(!establecimientosDestacados.Any()){
                return operationResult;
            }
            return operationResult;
        }
      
    }
}