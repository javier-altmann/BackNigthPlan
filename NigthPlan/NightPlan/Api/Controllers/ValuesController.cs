using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTO;
using Core.Interfaces;
using Core.Services;
using Core.Services.ResponseModels;
using DAL.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        IGruposService _grupos;
        public ValuesController(IGruposService grupos)
        {
            _grupos = grupos;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
          var gruposDelUsuario =  _grupos.GetGruposDelUsuario(1,10,0);
          var buscador = _grupos.GetSearchGroups(1,"ra",10,0);
          var usuariosDelGrupo = _grupos.GetUsuariosDelGrupos(1);
            
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
