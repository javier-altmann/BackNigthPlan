using Core.Interfaces;
using DAL.Model;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Core.Services.Mock;
using Core.Services.ResponseModels;

namespace Core.Services
{
    public class UsuariosService //: IUsuariosService
    {
        List<UsuariosMock> usuarios = new List<UsuariosMock>(){
            new UsuariosMock(){
                IdUsuario = 1,
                Nombre = "Javier",
                Apellido = "Altmann",
                Username = "javier.altmann",
                Password = "javier",
                Email = "javier.altmann@hotmail.com"


            },
            new UsuariosMock(){
                IdUsuario = 2,
                Nombre = "Carolina",
                Apellido = "Altmann",
                Username = "carolina.altmann",
                Password = "carolina",
                Email = "carolina.altmann@hotmail.com"

            }
        };
        
         private IBaseDAO<Usuarios> usuarioDAO;
    /* 
        public UsuariosService(IBaseDAO<Usuarios> usuarioDAO)
        {
            this.usuarioDAO = usuarioDAO;
        }
*/
        public LoginResponseApi autenticarUsuario(string username, string password)
        {
            bool autenticacionResponse = usuarios.Any(x=>x.Username == username && x.Password == password);
         
            return autenticacionResponse ? new LoginResponseApi(true):
                new LoginResponseApi(false,"El usuario o contraseña es incorrecto");
         
        }

        

        
    }
}