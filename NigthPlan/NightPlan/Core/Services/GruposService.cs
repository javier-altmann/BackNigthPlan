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
        public void CrearGrupo(CrearGrupoUsuarioDTO participante,CrearGrupoDTO grupo){
         /*
            var fechaString = DateTime.Today.ToString();
            //Guardo dentro de fechaSinHora la fecha con formato Dia-Mes-Año
            var fechaSinHora = fechaString.Split(' ').FirstOrDefault().Replace("/", "-");
          
            Grupos grupos = new Grupos();
            grupos.Nombre = grupo.NombreDelGrupo;
            grupos.Imagen = grupo.Imagen;
            grupos.FechaCreacion = fechaSinHora;
            
            
            context.Grupos.Add(grupos);

            GruposUsuarios usuario = new GruposUsuarios();
            usuario.IdUsuarios = participante.IdUsuario;
            usuario.IdGrupo = grupos.IdGrupo;
            context.GruposUsuarios.Add(usuario);
            */ 
            /*var cantidadDeUsuarios = participante.Count();

            EstadoDePreferencias estadoDePreferencias = new EstadoDePreferencias();
            estadoDePreferencias.CantidadUsuariosPorGrupo = cantidadDeUsuarios; 
            estadoDePreferencias.IdGrupo = grupos.IdGrupo;
            estadoDePreferencias.ContadorPreferenciasElegidas = 0;
            context.Add(estadoDePreferencias);
    */
            context.SaveChanges();
            
            
        }

        
    }

    

}
      
