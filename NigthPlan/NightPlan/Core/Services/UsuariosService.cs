using Core.Interfaces;
using DAL.Model;
using System.Collections.Generic;
using System.Linq;
using Core.Services.ResponseModels;
using Core.DTO;
using System;

namespace Core.Services
{
    public class UsuariosService : IUsuariosService
    {
         
        private nightPlanContext context;
        public UsuariosService(nightPlanContext context)
        {
            this.context = context;
        }


        public LoginResponseApi AutenticarUsuario(LoginDTO usuario)
        {
            bool autenticacionResponse = context.UsuariosAdministradores.Any(x => x.Username == usuario.Username && x.Password == usuario.Password);

            return autenticacionResponse ? new LoginResponseApi(true,"El usuario es correcto") :
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

        public PostResult<UsuarioDTO> SaveUsuarioRegistrado(UsuarioDTO user)
        {
            try
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

                var responseUsuarios = new PostResult<UsuarioDTO>
                {
                    ObjectResult = user,
                };

                return responseUsuarios;

            }
            catch (Exception ex)
            {
                var responseUsuario = new PostResult<UsuarioDTO>
                {
                   MensajePersonalizado = ex.Message,
                };
                return responseUsuario;
            }

        }

        public PostResult<UsuarioDTO> UpdateUser(int id,UsuarioDTO user)
        {
            try
            {
                var usuario = context.Usuarios.Find(id);
                usuario.Nombre = user.Nombre;
                usuario.Apellido = user.Apellido;
                usuario.Mail = user.Mail;
                usuario.FechaNacimiento = user.FechaNacimiento;
                context.SaveChanges();
                var responseUpdateUsuario = new PostResult<UsuarioDTO>
                {
                    ObjectResult = user,
                };

                return responseUpdateUsuario;
    
            }
            catch (Exception ex)
            {
                var responseUpdateUsuario = new PostResult<UsuarioDTO>
                {
                    MensajePersonalizado = ex.Message
                };
                return responseUpdateUsuario;
            }
            

        }

    }
}
