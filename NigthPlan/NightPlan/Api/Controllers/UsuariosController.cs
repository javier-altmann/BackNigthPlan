using System.Collections.Generic;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class UsuariosController : Controller
    {
        IUsuariosService _usuarios;
        public UsuariosController(IUsuariosService usuarios)
        {
            _usuarios = usuarios;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new  string[] { "value1", "value2" };
        }



        // GET api/values/5
        [HttpGet("{id}")]
        public string GetUsuariosDelGrupos(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
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