using System;
using System.Collections.Generic;
using System.Linq;
using Core.DTO;
using Core.DTO.Votacion;
using Core.Interfaces;
using Core.Services.ResponseModels;
using DAL.Model;

namespace Core.Services
{
    public class VotacionService : IVotacionService
    {
        private nightPlanContext context;
        public VotacionService(nightPlanContext context)
        {
            this.context = context;
        }

        public PostResult<VotacionDTO> GuardarVotacion(VotacionDTO votacion)
        {
            try
            {
                votacion.FechaDeRespuesta = DateTime.Today;
                var votoDelUsuario = new Votaciones
                {
                    IdGrupo = votacion.IdGrupo,
                    IdEstablecimiento = votacion.IdEstablecimiento,
                    FechaDeRespuesta = votacion.FechaDeRespuesta
                };
                var estadoDeLosVotos = context.EstadoDePreferencias.Where(x => x.IdGrupo == votacion.IdGrupo)
                                      .FirstOrDefault();
                var actualizarContadorDeVotos = new EstadoDePreferencias{
                    ContadorDeVotos = ++estadoDeLosVotos.ContadorDeVotos
                };

                context.Votaciones.Add(votoDelUsuario);
                estadoDeLosVotos.ContadorDeVotos = actualizarContadorDeVotos.ContadorDeVotos;

                context.SaveChanges();

                var responseVotacion = new PostResult<VotacionDTO>
                {
                    ObjectResult = votacion,
                };

                return responseVotacion;

            }
            catch (Exception ex)
            {
                var responseVotacion = new PostResult<VotacionDTO>
                {
                    MensajePersonalizado = ex.Message,
                };
                return responseVotacion;
            }
        }

        private bool GetEstadoDeLaVotacion(int id_grupo)
        {
            var EstadoDeVotos = context.EstadoDePreferencias.Where(x => x.IdGrupo == 1)
                                                 .Select(x => new EstadoDeVotosDTO
                                                 {
                                                     CantidadDeUsuariosPorGrupo = x.CantidadUsuariosPorGrupo,
                                                     ContadorDeVotos = x.ContadorDeVotos
                                                 }).FirstOrDefault();
            if (EstadoDeVotos.CantidadDeUsuariosPorGrupo == EstadoDeVotos.CantidadDeUsuariosPorGrupo)
            {
                return true;
            }

            return false;

        }
        public OperationResult<List<SugerenciaDTO>> GetResultadoDeLaVotacion(int id_grupo)
        {
            if(GetEstadoDeLaVotacion(1)){
                var votos = context.Votaciones.Where(x=> x.IdGrupo == id_grupo).ToList();
                var agruparVotos =  votos.GroupBy(x=> x.IdEstablecimiento)
                .Select(c=> new SugerenciaDTO{
                    IdEstablecimiento = c.Key,
                    CantidadDeVotos = c.Count()
                }).
                OrderByDescending(x=> x.CantidadDeVotos).ToList();
                agruparVotos[0].gano = true;
                var operationResult = new OperationResult<List<SugerenciaDTO>>();
                operationResult.ObjectResult = agruparVotos;

                
                return operationResult;                 
            }
            return new OperationResult<List<SugerenciaDTO>>();
        }

    }
}
