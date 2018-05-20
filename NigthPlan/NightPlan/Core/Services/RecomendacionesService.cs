using System.Linq;
using Core.DTO;
using Core.Interfaces;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

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
            //parsePreferenciasEstablecimientos(1);
            throw new System.NotImplementedException();
        }
        //El método devuelve los usuarios que respondieron para darle el check al mobile.
        public void getUsuariosQueRespondieron()
        {
            throw new System.NotImplementedException();
        }

        private bool validarSiRespondieronTodosLosUsuariosDelGrupo(int id_grupo)
        {
            //Hacer query para revisar si todos los usuarios del grupo respondieron sus preferencias

            //1. Hacer count de cuántos usuarios pertenecen al grupo. var cantidadDeUsuariosEnElGrupo

           var cantidadDeUsuariosEnElGrupo =  context.Grupos.Where(x => x.IdGrupo == id_grupo)
                                                     .Include(x => x.GruposUsuarios)
                                                     .SelectMany(x => x.GruposUsuarios)
                                                     .Include(x => x.IdUsuariosNavigation).ToList();
                                                     

            //2. hacer count de cuántos usuarios respondieron ->  Tabla.Where(x=> x.id_grupo). var cantidadDeUsuariosQueRespondieron
            //3. Hacer if(cantidadDeUsuariosEnElGrupo == cantidadDeUsuariosQueRespondieron){true }else{false}
            // 
            return true;
        }
        //En este metodo agarro las respuestas de todos los usuarios del grupo y agarro la intersección para después hacer la query de establecimientos sugeridos
      /*  private RespuestasPreferenciasDTO parsePreferenciasEstablecimientos(int id_grupo){
            //EN CASO DE QUE SEA VERDADERO(todos respondieron) busco la intersección entre los ids de las respuestas
            if(validarSiRespondieronTodosLosUsuariosDelGrupo(1))
            {
                //Hago el parseo de datos para hacer la query 
            }
            
            //Sino devolver un message 
         return null;
     }
     */
    }
}
 