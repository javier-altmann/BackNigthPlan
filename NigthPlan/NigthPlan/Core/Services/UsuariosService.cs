using Core.Interfaces;
using DAL.Model;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Core.Services.ResponseModels;

namespace Core.Services
{
    public class UsuariosService : IUsuariosService
    {
        private nigthPlanContext context;
        public UsuariosService(nigthPlanContext context)
        {

            this.context = context;
        }


        public LoginResponseApi autenticarUsuario(string username, string password)
        {
            bool autenticacionResponse = context.UsuariosAdministradores.Any(x => x.Username == username && x.Password == password);

            return autenticacionResponse ? new LoginResponseApi(true) :
                new LoginResponseApi(false, "El usuario o contraseña es incorrecto");

        }




    }
}