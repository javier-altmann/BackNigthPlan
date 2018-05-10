using DAL.Interfaces;
using DAL.Model;
using Core.DTO;
using Core.Interfaces;
using Core.Services.Mock;
using System.Collections.Generic;
using Core.Services.ResponseModels;
using System.Linq;
namespace Core.Services
{
    public class EstablecimientosService //: IEstablecimientosService
    {
       // private IBaseDAO<Establecimientos> establecimientosDAO;
        public EstablecimientoDTO Establecimiento { get; set; }

        List<EstablecimientosMock> establecimientos = new List<EstablecimientosMock>(){
            new EstablecimientosMock(){
                IdEstablecimiento = 1,
                Nombre = "Heisemburger",
                Imagen = "hes.png",
                Direccion = "Palermo 23",
                Destacado = 1,
            },
            new EstablecimientosMock(){
                IdEstablecimiento = 2,
                Nombre = "Junior",
                Imagen = "junior.png",
                Direccion = "Malabia",
                Destacado = 1,
            },
            new EstablecimientosMock(){
                IdEstablecimiento = 3,
                Nombre = "Share",
                Imagen = "share.png",
                Direccion = "Araoz",
                Destacado = 0,
            },
        };

      //  public EstablecimientosService(IBaseDAO<Establecimientos> establecimientosDAO)
        public EstablecimientosService()
        {
            //this.establecimientosDAO = establecimientosDAO;
            Establecimiento = null;
        }

        public List<EstablecimientoDTO> getEstablecimientosDestacados(int offset, int limit){
            
            var establecimientosDestacados = establecimientos.Where(x=> x.Destacado == 1)
                                            .Select(y=> new EstablecimientoDTO{
                                                IdEstablecimiento = y.IdEstablecimiento,
                                                Nombre = y.Nombre,
                                                Imagen = y.Imagen,
                                                Direccion = y.Direccion,
                                                Destacado = y.Destacado
                                            }).OrderBy(ordenar=>ordenar.IdEstablecimiento)
                                            .Take(limit).Skip(offset).ToList();
            //Cambiar el harcode de Take y Skip. Hacer una clase paginacion
           
          
            if(!establecimientosDestacados.Any()){
               // return establecimientosDestacados;
           
            }
            
            return establecimientosDestacados;
        }
        
        
        
    }
}