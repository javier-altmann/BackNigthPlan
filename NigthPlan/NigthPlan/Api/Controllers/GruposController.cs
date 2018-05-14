using System.Collections.Generic;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class GruposController : Controller
    {
        IGruposService _grupos;
        public GruposController(IGruposService grupos)
        {
            _grupos = grupos;
        }

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
        public void CrearGrupo([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void ActualizarGrupo(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void EliminarGrupo(int id)
        {
        }
        
    }
}