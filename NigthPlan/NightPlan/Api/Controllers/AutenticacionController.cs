using Core.DTO;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class AutenticacionController : Controller
    {
        IUsuariosService _usuarios;
        public AutenticacionController(IUsuariosService usuarios)
        {
            _usuarios = usuarios;
        }

        /// <summary>
        /// Devuelve un true o false dependiendo de si el usuario y contraseña estan correctos
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        // POST api/autenticacion
        [HttpPost]
        public IActionResult Post([FromBody]LoginDTO user)
        {
            var usuario = _usuarios.AutenticarUsuario(user);
        
            if(usuario == null){
                return NotFound(usuario);
            }else if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }else{
            return Ok(usuario);
            }
        }

       
    }
}