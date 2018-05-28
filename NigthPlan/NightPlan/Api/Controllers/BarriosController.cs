using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class BarriosController : Controller
    {
        IGruposService _grupos;
        public BarriosController(IGruposService grupos)
        {
            _grupos = grupos;
        }

        /// <summary>
        /// Trae todos los barrios
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
          
            return null;
        }    
    }
}