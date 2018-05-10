using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTO;
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
        

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            
            using (var context = new nigthPlanContext())
            {
                var gruposDelUsuario = context.Usuarios
                   .Where(x => x.IdUsuario == 1)
                   .Include(x => x.GruposUsuarios)
                   .SelectMany(x => x.GruposUsuarios)
                   .Include(x => x.IdGrupoNavigation)
                   .Select(x => new GruposDelUsuarioDTO(){
                       IdGrupo = x.IdGrupoNavigation.IdGrupo,
                       FechaCreacion = x.IdGrupoNavigation.FechaCreacion,
                       Nombre = x.IdGrupoNavigation.Nombre,
                       ImagenPerfil = x.IdGrupoNavigation.Imagen

                   }).ToList();
             }
            
            /* 
        
            GruposService grupos = new GruposService();
            
            
            var resultado =  grupos.GetSearchGroups(1,"bo",10,0);
           */

            
            /* 
           UsuariosService test = new UsuariosService();
           var validacionUsuario =  test.autenticarUsuario("avier.altmann","javier");
           */
         /*   EstablecimientosService establecimiento = new EstablecimientosService();
            var test = establecimiento.getEstablecimientosDestacados(10,5);
            */
            
            //var test = grupos.GetGruposDelUsuario(2,10,0);
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
