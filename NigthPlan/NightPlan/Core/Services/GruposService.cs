using System.Collections.Generic;
using DAL.Interfaces;
using DAL.Model;
using Core.DTO;
using Core.Interfaces;
using System.Linq;
using Core.Services.ResponseModels;
using Microsoft.EntityFrameworkCore;

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
            var usuariosDelGrupo = context.Grupos.Where(x => x.IdGrupo == id_grupo)
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
        // Habría que ver como hacer un metodo para que a medida que escriba le sugiera distintos usuarios
        public OperationResult<IEnumerable<UsuarioDTO>> getUsuarios(string email)
        {
            var listaDeUsuarios = context.Usuarios.Where(x=> x.Mail == email)
                                                  .Select(user=> new UsuarioDTO(){
                                                      Mail = user.Mail
                                                  }).ToList();
            OperationResult<IEnumerable<UsuarioDTO>> operationResult = new OperationResult<IEnumerable<UsuarioDTO>>();                                     
            if (listaDeUsuarios.Any())
            {
                operationResult.ObjectResult = listaDeUsuarios;
                return operationResult;
            }

            return operationResult;
            
        }
    }

}