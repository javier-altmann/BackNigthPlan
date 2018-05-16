using Core.DTO;

namespace Core.Interfaces
{
    public interface IRecomendadosService
    {
        EstablecimientoDTO getLugaresRecomendados();   
        void getUsuariosQueRespondieron();
    }
}