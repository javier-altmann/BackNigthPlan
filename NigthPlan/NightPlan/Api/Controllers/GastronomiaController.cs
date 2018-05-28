using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class GastronomiaController : Controller
    {
        IGruposService _grupos;
        public GastronomiaController(IGruposService grupos)
        {
            _grupos = grupos;
        }

        /// <summary>
        /// Trae todas las opciones de gastronomia
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