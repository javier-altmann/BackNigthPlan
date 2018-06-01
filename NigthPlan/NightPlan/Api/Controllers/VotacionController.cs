using Core.DTO;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class VotacionController : Controller
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
            var resultadoDeLaVotacion = _votacion.GetResultadoDeLaVotacion(idGrupo);
            if(resultadoDeLaVotacion.ObjectResult == null){
                return NotFound();
            }else if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            return Ok(resultadoDeLaVotacion);
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
            var voto = _votacion.GuardarVotacion(votacion);
            if(voto.ObjectResult == null){
                return NotFound();
            }else if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            return Created("",voto);
        }



    }
}