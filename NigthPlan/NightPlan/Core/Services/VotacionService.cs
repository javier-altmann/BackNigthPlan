using System;
using Core.DTO;
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
                var votoDelUsuario = new Votaciones()
                {
                    IdGrupo = votacion.IdGrupo,
                    IdEstablecimiento = votacion.IdEstablecimiento,
                    FechaDeRespuesta = votacion.FechaDeRespuesta
                };

                context.Votaciones.Add(votoDelUsuario);
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
    }
}