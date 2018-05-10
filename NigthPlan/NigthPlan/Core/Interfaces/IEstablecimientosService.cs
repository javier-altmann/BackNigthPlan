using DAL.Interfaces;
using Core.DTO;
using Core.Services.ResponseModels;

namespace Core.Interfaces
{
    public interface IEstablecimientosService
    {
        EstablecimientoDTO Establecimiento { get; set; }    

        EstablecimientoDTO getEstablecimientosDestacados();
    }
}