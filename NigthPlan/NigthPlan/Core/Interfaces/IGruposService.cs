using System;
using System.Collections.Generic;
using DAL.Model;
using Core.DTO;

namespace Core.Interfaces
{
    public interface IGruposService
    {
         GruposDelUsuarioDTO GruposDelUsuario { get; set; }
         UsuarioDelGrupoDTO UsuariosDelGrupo { get; set; }
        //Obtiene los grupos que pertenecen al usuario
         List<String> GetGruposDelUsuario(int id_usuario);

         //Obtiene los usuario de cada grupo que tiene el usuario que hace la petición
         List<String> GetUsuariosDelGrupos(int id_usuario);

        // Filtra los grupos del usuario según lo que se ingrese en el buscador
         List<String> GetSearchGroups(int id_usuario, string search);
    }
}