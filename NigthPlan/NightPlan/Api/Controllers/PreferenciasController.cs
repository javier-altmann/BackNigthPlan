using System.Collections.Generic;
using Core.DTO;
using Core.DTO.CrearGrupo;
using Core.Interfaces;
using Core.Services.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class PreferenciasController : Controller
    {

        IPreferenciasService _preferencias;
        public PreferenciasController(IPreferenciasService preferencias)
        {
            _preferencias = preferencias;
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
            var preferencias = _preferencias.GuardarPreferencias(preferenciasUsuario);
            if (preferencias.ObjectResult == null)
            {
                return NotFound();
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Created("", preferencias);
        }



    }

}


