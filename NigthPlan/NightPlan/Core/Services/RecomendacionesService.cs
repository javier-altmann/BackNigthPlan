using System.Linq;
using Core.DTO;
using Core.Interfaces;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.SqlClient;

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
            //1. Traigo las intersecciones
            //var test = GetIntersecciones();
            //2. Validar si la Response fue false 
            //3. En caso de que si responder que todavía no se puede
            //4. En caso de que traiga datos: Hacer algoritmo para recomendar lugares 
/* 
            SELECT establecimientos.id_establecimiento,establecimientos.nombre,establecimientos.direccion,establecimientos.imagen
            FROM establecimientos
            LEFT JOIN establecimiento_barrios
            ON establecimiento_barrios.id_establecimiento = establecimientos.id_establecimiento
            LEFT JOIN barrios
            ON barrios.id_barrio = establecimiento_barrios.id_barrio
            LEFT JOIN establecimiento_caracteristicas
            ON establecimiento_caracteristicas.id_establecimiento = establecimientos.id_establecimiento
            LEFT JOIN caracteristicas
            ON caracteristicas.id_caracteristica = establecimiento_caracteristicas.id_caracteristica
            WHERE barrios.id_barrio in (1, 2, 3)
            AND
            caracteristicas.id_caracteristica in (1, 2, 3);
*/
            return null;
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
            if (validarSiRespondieronTodosLosUsuariosDelGrupo(id_grupo))
            {
                var respuestasUsuarios = context.RespuestasUsuariosGrupos.Where(x => x.IdGrupo == id_grupo)
                                            .Select(x => x.Respuestas).ToList();

                PreferenciasDTO preferencias = new PreferenciasDTO
                {
                    IdsBarrios = new List<int>(),
                    IdsCaracteristicas = new List<int>(),
                    IdsGastronomia = new List<int>(),
                    Response = true
                };

                foreach (var respuestas in respuestasUsuarios)
                {
                    var respuestaDeserializada = JsonConvert.DeserializeObject<PreferenciasDTO>(respuestas);
                    preferencias.IdsBarrios.AddRange(respuestaDeserializada.IdsBarrios);
                    preferencias.IdsCaracteristicas.AddRange(respuestaDeserializada.IdsCaracteristicas);
                    preferencias.IdsGastronomia.AddRange(respuestaDeserializada.IdsGastronomia);

                }
                return preferencias;
            }
            else
            {
                PreferenciasDTO preferenciasResponse = new PreferenciasDTO
                {
                    Response = false
                };

                return preferenciasResponse;
            }
        }

        private PreferenciasDTO GetIntersecciones(int id_grupo)
        {
            //Agarro en una nueva lista las intersecciones de cada lista de preferencias. 
            var listasDeserializadas = DeserializarPreferenciasDelUsuario(id_grupo);
            if (listasDeserializadas.Response)
            {
                var barrios = Utilities.GetElementosRepetidosDeUnaLista(DeserializarPreferenciasDelUsuario(id_grupo).IdsBarrios);
                var caracteristicas = Utilities.GetElementosRepetidosDeUnaLista(DeserializarPreferenciasDelUsuario(id_grupo).IdsCaracteristicas);
                var gastronomia = Utilities.GetElementosRepetidosDeUnaLista(DeserializarPreferenciasDelUsuario(id_grupo).IdsGastronomia);

                PreferenciasDTO preferencias = new PreferenciasDTO
                {
                    IdsBarrios = barrios,
                    IdsCaracteristicas = caracteristicas,
                    IdsGastronomia = gastronomia,
                    Response = true
                };
                return preferencias;
            }
            else
            {
                PreferenciasDTO preferenciasFlag = new PreferenciasDTO
                {
                    Response = false
                };


                return preferenciasFlag;
            }
        }

    }

}



