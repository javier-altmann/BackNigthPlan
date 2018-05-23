using System.Linq;
using Core.DTO;
using Core.Interfaces;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Core.Services
{
    public class RecomendacionesService : IRecomendadosService
    {

        /* Guardar un atributo en la tabla que contenga la cantidad de usuarios que responden la preferencia
         en el grupo. Hacer una query que agarre ese atributo y le sume 1 cuando el nuevo usuario responde.
         EJ: Atributo tiene 1. El método busca que hay 1, le suma 1 y inserta 2. 
         Esto se hace cada vez que un usuario elige sus preferencias. 
         ---id_grupo contador_preferencias_elegidas  cantidad_usuarios_por_grupo---
         También cuando se crea un grupo guardo la cantidad de persona que hay en la misma tabla. 
        */
        private nightPlanContext context;
        public RecomendacionesService(nightPlanContext context)
        {

            this.context = context;
        }

        public EstablecimientoDTO getLugaresRecomendados()
        {
            //Guardo las intersecciones
            //var test = GetIntersecciones(); 

            // Hago la query en base a las intersecciones    
            throw new System.NotImplementedException();
        }
        //El método devuelve los usuarios que respondieron para darle el check al mobile.
        public void getUsuariosQueRespondieron()
        {
            throw new System.NotImplementedException();
        }

        private bool validarSiRespondieronTodosLosUsuariosDelGrupo(int id_grupo)
        {

            //1.Hago query para obtener cuántos usuarios pertenecen al grupo y cuántos respondieron sus preferencias. 

            var EstadoDePreferencias = context.EstadoDePreferencias.Where(x => x.IdGrupo == id_grupo)
                                                     .Select(x => new EstadoDePreferenciasDTO
                                                     {
                                                         CantidadDeUsuariosPorGrupo = x.CantidadUsuariosPorGrupo,
                                                         ContadorDePreferenciasElegidas = x.ContadorPreferenciasElegidas
                                                     }).FirstOrDefault();
            if (EstadoDePreferencias.CantidadDeUsuariosPorGrupo == EstadoDePreferencias.ContadorDePreferenciasElegidas)
            {
                return true;
            }

            return false;
        }
        //En este metodo agarro las respuestas de todos los usuarios del grupo y agarro la intersección para después hacer la query de establecimientos sugeridos
        private PreferenciasDTO DeserializarPreferenciasDelUsuario(int id_grupo)
        {
            //EN CASO DE QUE SEA VERDADERO(todos respondieron) parseo las respuestas de los usuarios
            //if (validarSiRespondieronTodosLosUsuariosDelGrupo(1))
            //{
            var respuestasUsuarios = context.RespuestasUsuariosGrupos.Where(x => x.IdGrupo == id_grupo)
                                        .Select(x => x.Respuestas).ToList();

            PreferenciasDTO preferencias = new PreferenciasDTO
            {
                IdsBarrios = new List<int>(),
                IdsCaracteristicas = new List<int>(),
                IdsGastronomia = new List<int>()
            };

            foreach (var respuestas in respuestasUsuarios)
            {
                var respuestaDeserializada = JsonConvert.DeserializeObject<PreferenciasDTO>(respuestas);
                
                preferencias.IdsCaracteristicas.AddRange(respuestaDeserializada.IdsCaracteristicas);
                preferencias.IdsGastronomia.AddRange(respuestaDeserializada.IdsGastronomia);

            }

            //}
            // PreferenciasDTO preferenciasResponse = new PreferenciasDTO();
            //preferenciasResponse.Response = false;

            //return preferenciasResponse;
            return preferencias;
        }
      
        public int GetIntersecciones()
        {
            //Agarro en una nueva lista las intersecciones de cada lista de preferencias. 
            var listasDeserializadas = DeserializarPreferenciasDelUsuario(1);
            //var listaOrdenadaIdBarrios = listasDeserializadas.IdsBarrios.OrderBy(x => x).ToList();


            var test = Test.GetDefault(DeserializarPreferenciasDelUsuario(1).IdsBarrios);
            
/*  
              PreferenciasDTO preferencias = new PreferenciasDTO
            {
                IdsBarrios = new List<int>(),
                IdsCaracteristicas = new List<int>(),
                IdsGastronomia = new List<int>()
            };


            for (int i = 1; i < listaOrdenadaIdBarrios.Count; i++)
            {

                if (listaOrdenadaIdBarrios[i-1] == listaOrdenadaIdBarrios[i])
                {
                    if (!preferencias.IdsBarrios.Contains(listaOrdenadaIdBarrios[i]))
                    {
                        preferencias.IdsBarrios.Add(listaOrdenadaIdBarrios[i]);
                    }
                }

            }

            var listaOrdenadaCaracteristicas = listasDeserializadas.IdsCaracteristicas.OrderBy(x => x).ToList();


            for (int i = 1; i < listaOrdenadaCaracteristicas.Count; i++)
            {

                if (listaOrdenadaCaracteristicas[i-1] == listaOrdenadaCaracteristicas[i])
                {
                    if (!preferencias.IdsCaracteristicas.Contains(listaOrdenadaCaracteristicas[i]))
                    {
                        preferencias.IdsCaracteristicas.Add(listaOrdenadaCaracteristicas[i]);
                    }
                }

            }

            var listaOrdenadaGastronomia = listasDeserializadas.IdsGastronomia.OrderBy(x => x).ToList();

            for (int i = 1; i < listaOrdenadaGastronomia.Count; i++)
            {

                if (listaOrdenadaGastronomia[i-1] == listaOrdenadaGastronomia[i])
                {
                    if (!preferencias.IdsGastronomia.Contains(listaOrdenadaGastronomia[i]))
                    {
                        preferencias.IdsGastronomia.Add(listaOrdenadaGastronomia[i]);
                    }
                }

            }

            return preferencias;
            */
            return 1;
        }

    }

}



