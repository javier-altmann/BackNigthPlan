using DAL.Interfaces;
using DAL.Model;
using Core.DTO;
using Core.Interfaces;
using System.Collections.Generic;
using Core.Services.ResponseModels;
using System.Linq;
using System;
using Core.DTO.CrearEstablecimientos;

namespace Core.Services
{
    public class EstablecimientosService : IEstablecimientosService
    {
        private nightPlanContext context;
        public EstablecimientosService(nightPlanContext context)
        {
            this.context = context;
        }


        public OperationResult<IEnumerable<EstablecimientoDTO>> getEstablecimientosDestacados(int limit, int offset)
        {
            var establecimientosDestacados = context.Establecimientos.Where(x => x.Destacado == 1)
                                            .Select(y => new EstablecimientoDTO
                                            {
                                                IdEstablecimiento = y.IdEstablecimiento,
                                                Nombre = y.Nombre,
                                                Imagen = y.Imagen,
                                                Direccion = y.Direccion,
                                                Destacado = y.Destacado
                                            }).OrderBy(ordenar => ordenar.IdEstablecimiento)
                                            .Take(limit).Skip(offset).ToList();
            //Cambiar el harcode de Take y Skip. Hacer una clase paginacion
            var operationResult = new OperationResult<IEnumerable<EstablecimientoDTO>>();

            if (!establecimientosDestacados.Any())
            {
                return operationResult;
            }
            return operationResult;
        }

        public IEnumerable<GastronomiaDTO> GetGastronomia()
        {
            var gastronomia = context.Gastronomia.Select(x => new GastronomiaDTO()
            {
                IdGastronomia = x.IdGastronomia,
                Nombre = x.Nombre
            }).ToList();
            return gastronomia;
        }

        public IEnumerable<BarrioDTO> GetBarrios()
        {
            var barrios = context.Barrios.Select(x => new BarrioDTO()
            {
                IdBarrio = x.IdBarrio,
                Nombre = x.Nombre
            }).ToList();

            return barrios;
        }

        public IEnumerable<CaracteristicasDTO> GetCaracteristicas()
        {
            var caracteristicas = context.Caracteristicas.Select(x => new CaracteristicasDTO()
            {
                IdCaracteristicas = x.IdCaracteristica,
                Nombre = x.Nombre
            }).ToList();
            return caracteristicas;
        }

        public PostResult<CrearEstablecimientosDTO> CrearEstablecimientos(CrearEstablecimientosDTO establecimiento)
        {

             try
            {
            var datosDelEstablecimiento = new Establecimientos
            {
                Nombre = establecimiento.Establecimiento.Nombre,
                Direccion = establecimiento.Establecimiento.Direccion,
                Imagen = establecimiento.Establecimiento.Imagen,
                Destacado = establecimiento.Establecimiento.Destacado
            };
            context.Establecimientos.Add(datosDelEstablecimiento);
            
            
            var listaBarrios = establecimiento.Barrio.IdBarrio.ToList();
            List<EstablecimientoBarrios> barrios = new List<EstablecimientoBarrios>();
            
            foreach (var item in listaBarrios)
            {
                EstablecimientoBarrios establecimientoBarrio = new EstablecimientoBarrios();

                establecimientoBarrio.IdEstablecimiento = datosDelEstablecimiento.IdEstablecimiento;
                establecimientoBarrio.IdBarrio = item;
                barrios.Add(establecimientoBarrio);
            }
            
           

            var listaCaracteristicas = establecimiento.Caracteristicas.IdCaracteristica.ToList();

            List<EstablecimientoCaracteristicas> caracteristicas = new List<EstablecimientoCaracteristicas>();

            foreach (var item in listaCaracteristicas)
            {
                EstablecimientoCaracteristicas establecimientoCaracteristica = new EstablecimientoCaracteristicas();

                establecimientoCaracteristica.IdEstablecimiento = datosDelEstablecimiento.IdEstablecimiento;
                establecimientoCaracteristica.IdCaracteristica = item;
                caracteristicas.Add(establecimientoCaracteristica);
            }

            
            var listaGastronomia = establecimiento.Gastronomia.IdGastronomia.ToList();
            List<EstablecimientosGastronomia> gastronomia = new List<EstablecimientosGastronomia>();
            foreach (var item in listaGastronomia)
            {
                EstablecimientosGastronomia establecimientoGastronomia = new EstablecimientosGastronomia();

                establecimientoGastronomia.IdEstablecimiento = datosDelEstablecimiento.IdEstablecimiento;
                establecimientoGastronomia.IdGastronomia = item;
                gastronomia.Add(establecimientoGastronomia);
            }

            context.EstablecimientoBarrios.AddRange(barrios);
            context.EstablecimientosGastronomia.AddRange(gastronomia);
            context.EstablecimientoCaracteristicas.AddRange(caracteristicas);

            context.SaveChanges();
            var responseEstablecimiento = new PostResult<CrearEstablecimientosDTO>
            {
                ObjectResult = establecimiento,
            };

            return responseEstablecimiento;
        }
         catch (Exception ex)
         {
             var responseEstablecimiento = new PostResult<CrearEstablecimientosDTO>
             {
                 MensajePersonalizado = ex.Message
             };
             return responseEstablecimiento;
         }
        

    }

}
//}