using System.Collections.Generic;
using Core.DTO;
using Core.DTO.Votacion;
using Core.Services.ResponseModels;

namespace Core.Interfaces
{
    public interface IVotacionService
    {
         PostResult<VotacionDTO> GuardarVotacion(VotacionDTO votacion);
         OperationResult<List<SugerenciaDTO>> GetResultadoDeLaVotacion(int id_grupo);

    }
}