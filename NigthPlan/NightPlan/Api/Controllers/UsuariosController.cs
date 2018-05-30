using System.Collections.Generic;
using Core.DTO;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class UsuariosController : Controller
    {
        IUsuariosService _usuarios;
        IGruposService _grupos;
        public UsuariosController(IUsuariosService usuarios, IGruposService grupos)
        {
            _usuarios = usuarios;
            _grupos = grupos;
        }

        /// <summary>
        /// Devuelve los usuarios que coincidan con el email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        // GET api/usuarios
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(404, Type = typeof(string))]
        public IActionResult Get(string email)
        {
            var usuarios = _grupos.getUsuarios(email);
            if(usuarios.ObjectResult == null){
                return NotFound(usuarios);
            }
            return Ok(usuarios.ObjectResult);
        }


        /// <summary>
        /// Devuelve los grupos del usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        // GET api/usuarios/5/grupos
        [HttpGet("{id}/grupos")]
        public IActionResult Get(int id,int limit, int offset)
        {
            var gruposDelUsuario = _grupos.GetGruposDelUsuario(id,limit,offset);
            if(gruposDelUsuario == null){
                return NotFound();
            }
            return Ok(gruposDelUsuario);
        }


        /// <summary>
        /// Guardar los datos del usuario 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        // POST api/usuarios
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(UsuarioDTO))]
        [ProducesResponseType(404, Type = typeof(UsuarioDTO))]
        [ProducesResponseType(400, Type = typeof(UsuarioDTO))]
        public IActionResult Post([FromBody]UsuarioDTO user)
        {
            var usuario = _usuarios.SaveUsuarioRegistrado(user);
            if(user == null){
                return NotFound(user);
            }else if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }else{
                return Created("",user);
            }
        }

        /// <summary>
        /// Actualizar los datos del usuario
        /// </summary>
        /// <param name="user"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        // PUT api/usuarios/5
        [HttpPut("{id}")]
        [ProducesResponseType(204, Type = typeof(UsuarioDTO))]
        [ProducesResponseType(404, Type = typeof(UsuarioDTO))]
        [ProducesResponseType(400, Type = typeof(UsuarioDTO))]
        public IActionResult Put(int id, [FromBody]UsuarioDTO user)
        {
            var usuario = _usuarios.UpdateUser(id,user);
            if(user == null){
                return NotFound(user);
            }else if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }else{
                return NoContent();
            }
        }

    }
}