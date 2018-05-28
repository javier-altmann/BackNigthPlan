using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class CaracteristicasController : Controller
    {
        IGruposService _grupos;
        public CaracteristicasController(IGruposService grupos)
        {
            _grupos = grupos;
        }

        /// <summary>
        /// Trae todas las caracteristicas
        /// </summary>
        /// <param></param>
        /// <returns></returns>    
        [HttpGet]
        public IActionResult Get()
        {
          
            return null;
        } 
    }
}