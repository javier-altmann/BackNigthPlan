using Core.DTO;

namespace Core.Interfaces
{
    public interface IRecomendadosService
    {
        EstablecimientoDTO getLugaresRecomendados(int id_grupo);   

    }
}