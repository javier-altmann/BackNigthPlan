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
        public UsuariosController(IUsuariosService usuarios)
        {
            _usuarios = usuarios;
        }

        /// <summary>
        /// Devuelve los usuarios que coincidan con el email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        // GET api/usuarios
        [HttpGet("api/usuarios")]
        public IActionResult Get(string email)
        {
            return null;
        }


        /// <summary>
        /// Devuelve los grupos del usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        // GET api/usuarios/5/grupos
        [HttpGet("api/usuarios/{id}/grupos")]
        public IActionResult Get(int idUsuario,int limit, int offset)
        {
            return null;
        }


        /// <summary>
        /// Guardar los datos del usuario 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        // POST api/usuarios
        [HttpPost]
        public IActionResult Post([FromBody]UsuarioDTO user)
        {
            return null;
        }

        /// <summary>
        /// Actualizar los datos del usuario
        /// </summary>
        /// <param name="user"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        // PUT api/usuarios/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UsuarioDTO user)
        {
            return null;
        }

    }
}