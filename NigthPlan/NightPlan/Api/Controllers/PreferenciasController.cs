using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class PreferenciasController : Controller
    {
       /*
        IPreferenciasService _prefencias;
        public GruposController(IPreferenciasService preferencias)
        {
            _prefencias = preferencias;
        }
         */

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
          
            return null;
        }



        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return null;
        }

        // POST api/values
        [HttpPost]
        public  IActionResult POST([FromBody]string value)
        {
            return null;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return null;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return null;
        }
        
        
    }
}