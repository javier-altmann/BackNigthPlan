using Core.DTO;

namespace Core.Interfaces
{
    public interface IRecomendadosService
    {
        EstablecimientoDTO getLugaresRecomendados();   
        void getUsuariosQueRespondieron();

        PreferenciasDTO parsePreferenciasEstablecimientos(int id_grupo);
    }
}