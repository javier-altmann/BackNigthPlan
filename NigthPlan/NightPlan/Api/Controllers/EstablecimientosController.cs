using System.Collections.Generic;
using Core.DTO.CrearEstablecimientos;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class EstablecimientosController : Controller
    {
        IEstablecimientosService _establecimientos;
        public EstablecimientosController(IEstablecimientosService establecimientos)
        {
            _establecimientos = establecimientos;
        }

        /// <summary>
        /// Devuelve los establecimientos destacados, según el offset y limit que se pase en los parametros
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        public IActionResult Get(int limit, int offset)
        {
            var establecimientosDestacados = _establecimientos.getEstablecimientosDestacados(limit, offset);
            if (establecimientosDestacados.ObjectResult == null)
            {
                NotFound(establecimientosDestacados);
            }
            return Ok(establecimientosDestacados);

        }

        /// <summary>
        /// Crea un establecimiento
        /// </summary>
        /// <param name="establecimiento"></param>
        /// <returns></returns>
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]CrearEstablecimientosDTO establecimiento)
        {

            var establecimientoNuevo = _establecimientos.CrearEstablecimientos(establecimiento);
             
            if (establecimientoNuevo.ObjectResult == null)
            {
                return NotFound(establecimientoNuevo);
            }
            else if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Created("", establecimientoNuevo);
            }
            
            
        }

    }
}