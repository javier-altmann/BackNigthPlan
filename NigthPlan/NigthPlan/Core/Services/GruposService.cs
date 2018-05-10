using System.Collections.Generic;
using DAL.Interfaces;
using DAL.Model;
using Core.DTO;
using Core.Interfaces;
using System.Linq;
using Core.Services.Mock;
using Core.Services.ResponseModels;

namespace Core.Services
{
    public class GruposService //: IGruposService
    {


        // private IBaseDAO<Grupos> gruposDAO;



        /*public GruposService (IBaseDAO<Grupos> gruposDAO)
        {
            this.gruposDAO = gruposDAO;
            GruposDelUsuario = null;
            UsuariosDelGrupo = null;
        }
*/
/* 
        List<GruposDelUsuarioDTO> gruposList = new List<GruposDelUsuarioDTO>(){
            new GruposDelUsuarioDTO(){
                IdGrupo = 1,
                Nombre = "Los Polvorines",
                ImagenPerfil = "polvo.png",
                FechaCreacion = "10/02/2018",
                IdUsuario = 1
            },
            new GruposDelUsuarioDTO(){
                IdGrupo = 2,
                Nombre = "River",
                ImagenPerfil = "river.png",
                FechaCreacion = "11/04/2018",
                IdUsuario = 1
            },
            new GruposDelUsuarioDTO(){
                IdGrupo = 3,
                Nombre = "Boca",
                ImagenPerfil = "boca.png",
                FechaCreacion = "12/03/2018",
                IdUsuario = 1
                },
            new GruposDelUsuarioDTO(){
                IdGrupo = 4,
                Nombre = "Bolsa",
                ImagenPerfil = "bolsa.png",
                FechaCreacion = "11/04/2018",
                IdUsuario = 2
                },

        };

        List<UsuarioDelGrupoDTO> usuariosList = new List<UsuarioDelGrupoDTO>(){
            new UsuarioDelGrupoDTO(){
                IdUsuario = 1,
                Nombre = "Javier",
                Apellido = "Altmann",
                ImagenPerfil = "javier.png",
                IdGrupo = 1,
            },
            new UsuarioDelGrupoDTO(){
                IdUsuario = 2,
                Nombre = "Carlos",
                Apellido = "Gomez",
                ImagenPerfil = "carlos.png",
                IdGrupo = 1
            },
            new UsuarioDelGrupoDTO(){
                IdUsuario = 3,
                Nombre = "Julian",
                Apellido = "Perez",
                ImagenPerfil = "julian.png",
                IdGrupo = 1
            }
        };
        public OperationResult<IEnumerable<GruposDelUsuarioDTO>> GetGruposDelUsuario(int id_usuario, int limit, int offset)
        {
            var gruposDelUsuario = gruposList.Where(x => x.IdUsuario == id_usuario);
            var gruposDelUsuarioFiltrados = gruposDelUsuario.OrderBy(y => y.Nombre)
                                                            .Take(limit).Skip(offset).ToList();
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
            var usuariosDelGrupo = usuariosList.Where(x => x.IdGrupo == id_grupo).ToList();
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
            var gruposDelUsuario = gruposList.Where(x => x.IdUsuario == id_usuario);
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

            //OperationResult<GruposDelUsuarioDTO> op = new OperationResult<GruposDelUsuarioDTO>();

            return operationResult;

        }
        
    }
    */
}}