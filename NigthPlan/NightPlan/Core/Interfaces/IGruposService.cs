using System;
using System.Collections.Generic;
using DAL.Model;
using Core.DTO;
using Core.Services.ResponseModels;

namespace Core.Interfaces
{
    public interface IGruposService
    {
        //Obtiene los grupos que pertenecen al usuario
         OperationResult<IEnumerable<GruposDelUsuarioDTO>> GetGruposDelUsuario(int id_usuario, int limit, int offset);

         //Obtiene los usuario de cada grupo que tiene el usuario que hace la petición
         OperationResult<IEnumerable<UsuarioDelGrupoDTO>> GetUsuariosDelGrupos(int id_grupo);

        // Filtra los grupos del usuario según lo que se ingrese en el buscador
        OperationResult<IEnumerable<GruposDelUsuarioDTO>> GetSearchGroups(int id_usuario, string search, int limit, int offset);
    
        OperationResult<IEnumerable<UsuarioDTO>> getUsuarios(string email);
    }
}