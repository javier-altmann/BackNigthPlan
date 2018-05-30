using System.Collections.Generic;
using Core.DTO;
using Core.DTO.CrearGrupo;
using Core.Interfaces;
using Core.Services.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class GruposController : Controller
    {
        IGruposService _grupos;
        public GruposController(IGruposService grupos)
        {
            _grupos = grupos;
        }
        
        /// <summary>
        /// Devuelve los grupos que cumplan con el filtro que puso el usuario
        /// </summary>
        /// <param name="id_usuario"></param>
        /// <param name="search"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        // GET api/grupos
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(OperationResult<IEnumerable<GruposDelUsuarioDTO>>))]
        [ProducesResponseType(404, Type = typeof(OperationResult<IEnumerable<GruposDelUsuarioDTO>>))]

        public IActionResult Get(int id_usuario, string search, int limit, int offset)
        {
            var resultadoDeBuscador = _grupos.GetSearchGroups(id_usuario,search,limit,offset);

            if(resultadoDeBuscador.ObjectResult == null){
                return NotFound(resultadoDeBuscador);
            }else if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }else{
            return Ok(resultadoDeBuscador);
            }
        }


        /// <summary>
        /// Devuelve los usuarios que pertenecen al grupo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/grupos/5/usuarios
        [HttpGet("{id}/usuarios")]
        [ProducesResponseType(200, Type = typeof(OperationResult<IEnumerable<UsuarioDelGrupoDTO>>))]
        [ProducesResponseType(404, Type = typeof(OperationResult<IEnumerable<UsuarioDelGrupoDTO>>))]
        public IActionResult Get(int id)
        {
            var usuariosDelGrupo = _grupos.GetUsuariosDelGrupos(id);
            if(usuariosDelGrupo.ObjectResult == null){
                return NotFound(usuariosDelGrupo);
            }else if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }else{
            return Ok(usuariosDelGrupo);
            }
        }

        /// <summary>
        /// Crea el grupo
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        // POST api/grupos
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ResponseCrearGrupoDTO))]
        [ProducesResponseType(404, Type = typeof(ResponseCrearGrupoDTO))]
        public IActionResult Post([FromBody] GruposDTO grupo)
        {
            var nuevoGrupo = _grupos.CrearGrupo(grupo);
            if(!ModelState.IsValid){
                return BadRequest(ModelState);                
            }else if(nuevoGrupo.Succes){
                return Ok(nuevoGrupo);
            }else{
                return NotFound(nuevoGrupo);
            }
            
        }

    }
}