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
        public IActionResult Post([FromBody]string username,string password)
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