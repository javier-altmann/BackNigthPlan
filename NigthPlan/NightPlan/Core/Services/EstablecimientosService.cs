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

        public IEnumerable<GastronomiaDTO> GetGastronomia()
        {
            var gastronomia = context.Gastronomia.Select(x=> new GastronomiaDTO(){
                IdGastronomia = x.IdGastronomia,
                Nombre = x.Nombre
            }).ToList();
            return gastronomia;
        }

        public IEnumerable<BarrioDTO> GetBarrios()
        {
            var barrios = context.Barrios.Select(x=> new BarrioDTO(){
                IdBarrio = x.IdBarrio,
                Nombre = x.Nombre
            }).ToList();

            return barrios;
        }

        public IEnumerable<CaracteristicasDTO> GetCaracteristicas()
        {
            var caracteristicas = context.Caracteristicas.Select(x=> new CaracteristicasDTO(){
                IdCaracteristicas = x.IdCaracteristica,
                Nombre = x.Nombre
            }).ToList();
            return caracteristicas;
        }

       



    }
}