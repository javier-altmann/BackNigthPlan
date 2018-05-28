using System.Collections.Generic;
using Core.DTO.CrearGrupo;
using Core.Interfaces;
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
        public IActionResult Get(int id_usuario, string search, int limit, int offset)
        {
          
            return null;
        }


        /// <summary>
        /// Devuelve los usuarios que pertenecen al grupo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/grupos/5
        [HttpGet("api/grupos/{id}/usuarios")]
        public IActionResult Get(int id)
        {
            return null;
        }

        /// <summary>
        /// Crea el grupo
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        // POST api/grupos
        [HttpPost]
        public IActionResult Post([FromBody] GruposDTO grupo)
        {
            return null;
        }

    }
}