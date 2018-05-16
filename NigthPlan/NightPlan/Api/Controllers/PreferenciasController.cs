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
        public IEnumerable<string> Get()
        {
          
            return new  string[] { "value1", "value2" };
        }



        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void GuardarPreferencias([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        
        
    }
}