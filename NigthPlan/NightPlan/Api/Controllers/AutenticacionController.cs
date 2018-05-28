using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class AutenticacionController
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
        public IActionResult Post([FromBody]string username,string password)
        {
            return null;
        }
    }
}