using System.Collections.Generic;
using Core.DTO;
using Core.Interfaces;
using Core.Services.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class BarriosController : Controller
    {
        IEstablecimientosService _establecimientos;
        public BarriosController(IEstablecimientosService establecimientos)
        {
            _establecimientos = establecimientos;
        }

        
        /// <summary>
        /// Trae todos los barrios
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        [Produces("application/json", Type = typeof(OperationResult<IEnumerable<BarrioDTO>>))]
        public IActionResult Get()
        {
          var barrios = _establecimientos.GetBarrios();
            return Ok(barrios);
        } 
        

    }
}