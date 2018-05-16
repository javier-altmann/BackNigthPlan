using System.Collections.Generic;
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

        // GET api/values
        [HttpGet]
        public IActionResult GetEstablecimientosDestacados()
        {
            return null;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void CrearEstablecimiento([FromBody]string value)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void ActualizarEstablecimientos(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void EliminarEstablecimientos(int id)
        {
        }
        
    }
}