using System.Collections.Generic;
using Core.DTO;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class PreferenciasController : Controller
    {
        IPreferenciasService _prefencias;
        public PreferenciasController(IPreferenciasService preferencias)
        {
            _prefencias = preferencias;
        }
         
        /// <summary>
        /// Guarda las preferencias del usuario
        /// </summary>
        /// <param name="preferenciasUsuario"></param>
        /// <returns></returns>
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]GuardarPreferenciasDTO preferenciasUsuario)
        {
            return null;
        }
        
    }
}