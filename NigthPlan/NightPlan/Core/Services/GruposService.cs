using System.Collections.Generic;
using DAL.Interfaces;
using DAL.Model;
using Core.DTO;
using Core.DTO.CrearGrupo;
using Core.Interfaces;
using System.Linq;
using Core.Services.ResponseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;

namespace Core.Services
{
    public class GruposService : IGruposService
    {
        private nightPlanContext context;
        public GruposService(nightPlanContext context)
        {
            this.context = context;
        }

        public OperationResult<IEnumerable<GruposDelUsuarioDTO>> GetGruposDelUsuario(int id_usuario, int limit, int offset)
        {
            var gruposDelUsuarioFiltrados = context.Usuarios
               .Where(x => x.IdUsuario == id_usuario)
               .Include(x => x.GruposUsuarios)
               .SelectMany(x => x.GruposUsuarios)
               .Include(x => x.IdGrupoNavigation)
               .Select(x => new GruposDelUsuarioDTO()
               {
                   IdGrupo = x.IdGrupoNavigation.IdGrupo,
                   FechaCreacion = x.IdGrupoNavigation.FechaCreacion,
                   Nombre = x.IdGrupoNavigation.Nombre,
                   ImagenPerfil = x.IdGrupoNavigation.Imagen

               }).OrderBy(x => x.IdGrupo).Take(limit).Skip(offset).ToList();
            var operationResult = new OperationResult<IEnumerable<GruposDelUsuarioDTO>>();


            if (gruposDelUsuarioFiltrados.Any())
            {
                operationResult.ObjectResult = gruposDelUsuarioFiltrados;
                return operationResult;
            }

            return operationResult;

        }

        public OperationResult<IEnumerable<UsuarioDelGrupoDTO>> GetUsuariosDelGrupos(int id_grupo)
        {
            
            List<bool> respondioElUsuario = context.RespuestasUsuariosGrupos.Where(x=>x.IdGrupo == id_grupo).Select(x=>x.Respondio).ToList();
            List<UsuarioDelGrupoDTO> usuariosDelGrupo = context.Grupos.Where(x => x.IdGrupo == id_grupo)
                                          .Include(x => x.GruposUsuarios)
                                          .SelectMany(x => x.GruposUsuarios)
                                          .Include(x => x.IdUsuariosNavigation)
                                          .Select(x => new UsuarioDelGrupoDTO()
                                          {
                                              IdUsuario = x.IdUsuariosNavigation.IdUsuario,
                                              Nombre = x.IdUsuariosNavigation.Nombre,
                                              Apellido = x.IdUsuariosNavigation.Apellido,
                                              ImagenPerfil = x.IdUsuariosNavigation.ImagenPerfil

                                          }).OrderBy(x => x.IdUsuario).ToList();
            

            for(int i=0; i < usuariosDelGrupo.Count();i++){
                //Esta validación la hago por si no llega haber algun dato en la tabla de respuestas_usuarios_grupos
                if(respondioElUsuario.Any()){
                usuariosDelGrupo[i].Resultado = respondioElUsuario[i];
                }else{
                    usuariosDelGrupo[i].Resultado = false;
                }
            }


            var operationResult = new OperationResult<IEnumerable<UsuarioDelGrupoDTO>>();
            if (usuariosDelGrupo.Any())
            {
                operationResult.ObjectResult = usuariosDelGrupo;
                return operationResult;
            }

            return operationResult;

        }

       
        public OperationResult<IEnumerable<GruposDelUsuarioDTO>> GetSearchGroups(int id_usuario, string search, int limit, int offset)
        {
            var gruposDelUsuario = context.Usuarios
                   .Where(x => x.IdUsuario == id_usuario)
                   .Include(x => x.GruposUsuarios)
                   .SelectMany(x => x.GruposUsuarios)
                   .Include(x => x.IdGrupoNavigation)
                   .Select(x => new GruposDelUsuarioDTO()
                   {
                       IdGrupo = x.IdGrupoNavigation.IdGrupo,
                       FechaCreacion = x.IdGrupoNavigation.FechaCreacion,
                       Nombre = x.IdGrupoNavigation.Nombre,
                       ImagenPerfil = x.IdGrupoNavigation.Imagen

                   });

            var resultadoBusqueda = gruposDelUsuario.Where(y => y.Nombre.ToLower().Contains
                                    (search.ToLower()))
                                    .OrderBy(o => o.IdGrupo).Take(limit).Skip(offset)
                                              .ToList();
            var operationResult = new OperationResult<IEnumerable<GruposDelUsuarioDTO>>();

            if (resultadoBusqueda.Any())
            {
                operationResult.ObjectResult = resultadoBusqueda;
                return operationResult;
            }

            return operationResult;

        }
        public OperationResult<IEnumerable<UsuarioDTO>> getUsuarios(string email)
        {
            var listaDeUsuarios = context.Usuarios.Where(x => x.Mail == email)
                                                  .Select(user => new UsuarioDTO()
                                                  {
                                                      Mail = user.Mail,
                                                      IdUsuario = user.IdUsuario

                                                  }).ToList();
            OperationResult<IEnumerable<UsuarioDTO>> operationResult = new OperationResult<IEnumerable<UsuarioDTO>>();
            if (listaDeUsuarios.Any())
            {
                operationResult.ObjectResult = listaDeUsuarios;
                return operationResult;
            }

            return operationResult;

        }

        /*CUANDO CREO UN GRUPO, TENGO QUE INSERTAR EN LA TABLA estado_de_preferencias el id_grupo y 
            cantidad_usuarios_por_grupo(contar la cantidad de usuarios que agrego)
        */
        
        public CrearGrupoResponseApi CrearGrupo(GruposDTO grupo)
        {

            var fechaString = DateTime.Today.ToString();
            //Guardo dentro de fechaSinHora la fecha con formato Dia-Mes-Año
            var fechaSinHora = fechaString.Split(' ').FirstOrDefault().Replace("/", "-");
            try
            {
                Grupos grupos = new Grupos()
                {
                    Nombre = grupo.NombreDelGrupo,
                    Imagen = grupo.Imagen,
                    FechaCreacion = fechaSinHora
                };

                context.Grupos.Add(grupos);

                var usuarios = grupo.usuarios.Select(x => new GruposUsuarios()
                {
                    IdUsuarios = x.IdUsuario,
                    IdGrupo = grupos.IdGrupo,
                });

                context.GruposUsuarios.AddRange(usuarios);

                var cantidadDeUsuarios = grupo.usuarios.Count();

                EstadoDePreferencias estadoDePreferencias = new EstadoDePreferencias
                {
                    CantidadUsuariosPorGrupo = cantidadDeUsuarios,
                    IdGrupo = grupos.IdGrupo,
                    ContadorPreferenciasElegidas = 0
                };
                context.Add(estadoDePreferencias);

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return new CrearGrupoResponseApi(false, "Fallo al guardar los datos del grupo");
            }

            return new CrearGrupoResponseApi(true, "Se guardo el grupo exitosamente");
        }

    }



}

