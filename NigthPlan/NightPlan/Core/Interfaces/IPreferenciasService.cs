using Core.DTO;
using Core.Services.ResponseModels;

namespace Core.Interfaces
{
    public interface IPreferenciasService
    {
        PostResult<GuardarPreferenciasDTO> GuardarPreferencias(GuardarPreferenciasDTO preferencias);
    }
}