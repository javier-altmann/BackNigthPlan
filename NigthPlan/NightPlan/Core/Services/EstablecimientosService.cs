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


        public OperationResult<IEnumerable<EstablecimientoDTO>> getEstablecimientosDestacados(int offset, int limit)
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

                EstablecimientoBarrios establecimientoBarrio = new EstablecimientoBarrios
                {
                    IdBarrio = establecimiento.Barrio.IdBarrio,
                    IdEstablecimiento = datosDelEstablecimiento.IdEstablecimiento
                };

                EstablecimientoCaracteristicas establecimientoCaracteristica = new EstablecimientoCaracteristicas
                {
                    IdCaracteristica = establecimiento.Caracteristicas.IdCaracteristica,
                    IdEstablecimiento = datosDelEstablecimiento.IdEstablecimiento
                };

                EstablecimientosGastronomia establecimientoGastronomia = new EstablecimientosGastronomia
                {
                    IdGastronomia = establecimiento.Gastronomia.IdGastronomia,
                    IdEstablecimiento = datosDelEstablecimiento.IdEstablecimiento
                };
                context.EstablecimientoBarrios.Add(establecimientoBarrio);
                context.EstablecimientoCaracteristicas.Add(establecimientoCaracteristica);
                context.EstablecimientosGastronomia.Add(establecimientoGastronomia);
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
}