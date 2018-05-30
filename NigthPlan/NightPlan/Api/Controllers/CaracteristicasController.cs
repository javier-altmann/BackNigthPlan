using System.Collections.Generic;
using Core.DTO;
using Core.Interfaces;
using Core.Services.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class CaracteristicasController : Controller
    {
        IEstablecimientosService _establecimientos;
        public CaracteristicasController(IEstablecimientosService establecimientos)
        {
            _establecimientos = establecimientos;
        }

        /// <summary>
        /// Trae todas las caracteristicas
        /// </summary>
        /// <param></param>
        /// <returns></returns>    
        [HttpGet]
        [Produces("application/json", Type = typeof(OperationResult<IEnumerable<CaracteristicasDTO>>))]

        public IActionResult Get()
        {
            var caracteristicas = _establecimientos.GetCaracteristicas();
            if(caracteristicas == null){
                return NotFound(caracteristicas);
            }
            return Ok(caracteristicas);
            
        }

    }
}