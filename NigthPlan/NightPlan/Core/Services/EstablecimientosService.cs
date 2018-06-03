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


        public OperationResult<IEnumerable<EstablecimientoDestacadosDTO>> getEstablecimientosDestacados(int limit, int offset)
        {
            var establecimientosDestacados = context.Establecimientos.Where(x => x.Destacado == true)
                                            .Select(y => new EstablecimientoDestacadosDTO
                                            {
                                                IdEstablecimiento = y.IdEstablecimiento,
                                                Nombre = y.Nombre,
                                                Imagen = y.Imagen,
                                                Direccion = y.Direccion,
                                                Destacado = y.Destacado
                                            }).OrderBy(ordenar => ordenar.IdEstablecimiento)
                                            .Take(limit).Skip(offset).ToList();
            //Cambiar el harcode de Take y Skip. Hacer una clase paginacion
            var operationResult = new OperationResult<IEnumerable<EstablecimientoDestacadosDTO>>();

            if (!establecimientosDestacados.Any())
            {
                return operationResult;
            }
            operationResult.ObjectResult = establecimientosDestacados;

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




        public void AddEstablecimientosBarrios(IEnumerable<int> idsBarrios, int IdEstablecimiento)
        {
            var establecimientosBarrios = idsBarrios.Select(idBarrio => new EstablecimientoBarrios()
            {
                IdEstablecimiento = IdEstablecimiento,
                IdBarrio = idBarrio
            }).ToList();

            context.EstablecimientoBarrios.AddRange(establecimientosBarrios);
        }
        /*  foreach (var item in listaCaracteristicas)
                {
                    EstablecimientoCaracteristicas establecimientoCaracteristica = new EstablecimientoCaracteristicas();

                    establecimientoCaracteristica.IdEstablecimiento = datosDelEstablecimiento.IdEstablecimiento;
                    establecimientoCaracteristica.IdCaracteristica = item;
                    caracteristicas.Add(establecimientoCaracteristica);
                }
                */

        public void AddEstablecimientosCaracteristicas(IEnumerable<int> idsCaracteristicas,int IdEstablecimiento)
        {
            var establecimientosCaracteristicas = idsCaracteristicas.Select(idsCaracteristica => new EstablecimientoCaracteristicas()
            {
                IdEstablecimiento = IdEstablecimiento,
                IdCaracteristica = idsCaracteristica
            }).ToList();

            context.EstablecimientoCaracteristicas.AddRange(establecimientosCaracteristicas);
        }

        public void AddEstablecimientosGastronomia(IEnumerable<int> idsGastronomia, int IdEstablecimiento)
        {
            var establecimientosGastronomias = idsGastronomia.Select(idGastronomia => new EstablecimientosGastronomia()
            {
                IdEstablecimiento = IdEstablecimiento,
                IdGastronomia = idGastronomia
            }).ToList();

            context.EstablecimientosGastronomia.AddRange(establecimientosGastronomias);
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
                
                AddEstablecimientosBarrios(listaBarrios,datosDelEstablecimiento.IdEstablecimiento);

                var listaGastronomia = establecimiento.Gastronomia.IdGastronomia.ToList();
                
                AddEstablecimientosGastronomia(listaGastronomia,datosDelEstablecimiento.IdEstablecimiento);

                var listaCaracteristicas = establecimiento.Caracteristicas.IdCaracteristica.ToList();
                AddEstablecimientosCaracteristicas(listaCaracteristicas,datosDelEstablecimiento.IdEstablecimiento);
             
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