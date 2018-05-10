namespace Core.Interfaces
{
    public interface IUsuariosService
    {
          bool autenticarUsuario(string username, string password);
    }
}