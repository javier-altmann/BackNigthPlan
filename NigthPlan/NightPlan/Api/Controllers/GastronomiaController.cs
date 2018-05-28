using System.Collections.Generic;
using Core.DTO;
using Core.Interfaces;
using Core.Services.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class GastronomiaController : Controller
    {
        IEstablecimientosService _establecimientos;
        public GastronomiaController(IEstablecimientosService establecimientos)
        {
            _establecimientos = establecimientos;
        }

        
        /// <summary>
        /// Trae todas las opciones de gastronomia
        /// </summary>
        /// <param></param>
        /// <returns></returns>    
        //api/gastronomia
        [HttpGet]
        [Produces("application/json", Type = typeof(OperationResult<IEnumerable<GastronomiaDTO>>))]
        public IActionResult Get()
        {
          var gastronomia = _establecimientos.GetGastronomia();
            return Ok(gastronomia);
        } 
        

    }
}