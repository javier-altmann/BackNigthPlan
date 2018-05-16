using System.Collections.Generic;
using Core.DTO;
using Core.Services.ResponseModels;

namespace Core.Interfaces
{
    public interface IUsuariosService
    {
          LoginResponseApi AutenticarUsuario(string username, string password);
          OperationResult<UsuarioDTO> GetUsuarioFacebook(int id_usuario);

          void SaveUsuarioRegistrado(UsuarioDTO user);

          void UpdateUser(UsuarioDTO user);



          
    }
}