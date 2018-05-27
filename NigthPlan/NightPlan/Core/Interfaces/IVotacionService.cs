using Core.DTO;
using Core.Services.ResponseModels;

namespace Core.Interfaces
{
    public interface IVotacionService
    {
         PostResult<VotacionDTO> GuardarVotacion(VotacionDTO votacion);
    }
}