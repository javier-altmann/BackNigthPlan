using System.Collections.Generic;
using Core.DTO;
using Core.Services.ResponseModels;

namespace Core.Interfaces
{
    public interface IUsuariosService
    {
          LoginResponseApi AutenticarUsuario(LoginDTO usuario);
          OperationResult<UsuarioDTO> GetUsuarioFacebook(int id_usuario);

          PostResult<UsuarioDTO> SaveUsuarioRegistrado(UsuarioDTO user);

          PostResult<UsuarioDTO> UpdateUser(int id,UsuarioDTO user);



          
    }
}