using Core.Services.ResponseModels;

namespace Core.Interfaces
{
    public interface IUsuariosService
    {
          LoginResponseApi autenticarUsuario(string username, string password);
    }
}