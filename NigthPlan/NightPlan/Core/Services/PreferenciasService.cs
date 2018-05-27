using System;
using System.Collections.Generic;
using System.Linq;
using Core.DTO;
using Core.Interfaces;
using Core.Services.ResponseModels;
using DAL.Model;

namespace Core.Services
{
    public class PreferenciasService : IPreferenciasService
    {

        /* Guardar un atributo en la tabla que contenga la cantidad de usuarios
         que responden la preferencia
        en el grupo. Hacer una query que agarre ese atributo y le sume 1 cuando el nuevo usuario
         responde.
        EJ: Atributo tiene 1. El método busca que hay 1, le suma 1 y inserta 2. 
        Esto se hace cada vez que un usuario elige sus preferencias. 
        ---id_grupo contador_preferencias_elegidas  cantidad_usuarios_por_grupo---
        También cuando se crea un grupo guardo la cantidad de persona que hay en la misma tabla. 
       */

        private nightPlanContext context;
        public PreferenciasService(nightPlanContext context)
        {
            this.context = context;
        }

        public PostResult<GuardarPreferenciasDTO> GuardarPreferencias(GuardarPreferenciasDTO preferenciasUsuario)
        {
            try
            {
                var response = @"{ ""IdsBarrios"": [5,6,7],""IdsGastronomia"":[1,2,3],""IdsCaracteristicas"":[4,2,1]
								}";
                var estadoDeLasPreferencias = context.EstadoDePreferencias.Where(x => x.IdGrupo == preferenciasUsuario.IdGrupo)
                                      .FirstOrDefault();
                var preferencias = new RespuestasUsuariosGrupos 
                {
                    IdUsuario = preferenciasUsuario.IdUsuario,
                    IdGrupo = preferenciasUsuario.IdGrupo,
                    Respuestas = response

                };

                var actualizarContadorDePreferencias = new GuardarPreferenciasDTO
                {
                    ContadorDePreferencias = ++estadoDeLasPreferencias.ContadorPreferenciasElegidas
                };
                var responsePreferencia = new PostResult<GuardarPreferenciasDTO>
                {
                    ObjectResult = preferenciasUsuario,
                };
                context.RespuestasUsuariosGrupos.Add(preferencias);
                estadoDeLasPreferencias.ContadorPreferenciasElegidas = actualizarContadorDePreferencias.ContadorDePreferencias;
                context.SaveChanges();

                return responsePreferencia;
            }
            catch (Exception ex)
            {
                var responsePreferencia = new PostResult<GuardarPreferenciasDTO>
                {
                    MensajePersonalizado = ex.Message,
                };
                return responsePreferencia;
            }
    

        }
    }

}
