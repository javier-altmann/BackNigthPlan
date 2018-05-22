using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTO;
using Core.DTO.CrearGrupo;
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
        IRecomendadosService _recomendaciones;
        public ValuesController(IGruposService grupos,IRecomendadosService recomendados)
        {
            _grupos = grupos;
            _recomendaciones = recomendados;
        }

        // GET api/values
        [HttpGet]
        [Produces("application/json",Type = typeof(OperationResult<IEnumerable<GruposDelUsuarioDTO>>))]
        public IActionResult Test()
        {
          //var gruposDelUsuario =  _grupos.GetGruposDelUsuario(1,10,0);
         // var buscador = _grupos.GetSearchGroups(1,"ra",10,0);
          //var usuariosDelGrupo = _grupos.GetUsuariosDelGrupos(1);
          var test = _recomendaciones.parsePreferenciasEstablecimientos(1);
            
            return Ok(test);
        }



        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            
            return "value";
        }

        // POST api/values
        /// <summary>
        /// Esto es un test
        /// </summary>
        /// <param name="Grupos"></param>
        /// <returns></returns>
        [HttpPost]
        public void Post([FromBody]GruposDTO Grupos)
        {
            
            
           _grupos.CrearGrupo(Grupos);
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
