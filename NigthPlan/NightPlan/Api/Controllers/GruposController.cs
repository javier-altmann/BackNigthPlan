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
        /// Esto es un test
        /// </summary>
        /// <param name="Grupos"></param>
        /// <returns></returns>
        // GET api/grupos
        [HttpGet]
        public IActionResult Get()
        {
          
            return null;
        }


        /// <summary>
        /// Esto es un test
        /// </summary>
        /// <param name="Grupos"></param>
        /// <returns></returns>
        // GET api/grupos/5
        [HttpGet("{id}")]
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