using Core.Interfaces;
using DAL.Model;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Core.Services.ResponseModels;
using Core.DTO;

namespace Core.Services
{
    public class UsuariosService : IUsuariosService
    {
        private nightPlanContext context;
        public UsuariosService(nightPlanContext context)
        {
            this.context = context;
        }


        public LoginResponseApi AutenticarUsuario(string username, string password)
        {
            bool autenticacionResponse = context.UsuariosAdministradores.Any(x => x.Username == username && x.Password == password);

            return autenticacionResponse ? new LoginResponseApi(true) :
                new LoginResponseApi(false, "El usuario o contraseña es incorrecto");

        }
        //Trae los datos del usuario para que después pueda editarlo
        public OperationResult<UsuarioDTO> GetUsuarioFacebook(int id_usuario)
        {
            var datosDelUsuario = context.Usuarios.Where(x => x.IdUsuario == id_usuario)
                                         .Select(user => new UsuarioDTO()
                                         {
                                             IdUsuario = user.IdUsuario,
                                             Nombre = user.Nombre,
                                             Apellido = user.Apellido,
                                             Mail = user.Mail,
                                             FechaNacimiento = user.FechaNacimiento
                                         }).
                                         FirstOrDefault();
            OperationResult<UsuarioDTO> operation = new OperationResult<UsuarioDTO>();
            if (datosDelUsuario != null)
            {
                operation.ObjectResult = datosDelUsuario;
                return operation;
            }

            return operation;
        }

        public void SaveUsuarioRegistrado(UsuarioDTO user)
        {
            var datosDelUsuario = new Usuarios()
            {
                IdUsuario = user.IdUsuario,
                Nombre = user.Nombre,
                Apellido = user.Apellido,
                Mail = user.Mail,
                ImagenPerfil = user.ImagenPerfil,
                FechaNacimiento = user.FechaNacimiento
            };
            context.Usuarios.Add(datosDelUsuario);
            context.SaveChanges();
        }

        public void UpdateUser(UsuarioDTO user)
        {
            var usuario = context.Usuarios.FirstOrDefault();
            usuario.Nombre = user.Nombre;
            usuario.Apellido = user.Apellido;
            usuario.Mail = user.Mail;
            usuario.FechaNacimiento = user.FechaNacimiento;
            context.SaveChanges();
        }

    }
}