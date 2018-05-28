using Core.DTO;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class VotacionController
    {
        IVotacionService _votacion;
        public VotacionController(IVotacionService votacion)
        {
            _votacion = votacion;
        }

        /// <summary>
        /// Devuelve el resultado de la votacion
        /// </summary>
        /// <param name="idGrupo"></param>
        /// <returns></returns>
        // GET api/votacion/5
        [HttpGet("{id}")]
        public IActionResult Get(int idGrupo)
        {
            return null;
        }

        /// <summary>
        /// Guarda el voto de cada usuario 
        /// </summary>
        /// <param name="votacion"></param>
        /// <returns></returns>
        // POST api/votacion
        [HttpPost]
        public IActionResult Post([FromBody] VotacionDTO votacion)
        {
            return null;
        }



    }
}