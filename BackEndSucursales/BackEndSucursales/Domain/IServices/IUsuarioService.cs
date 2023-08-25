﻿using BackEndSucursales.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndSucursales.Domain.IServices
{
    public interface IUsuarioService
    {
        Task SavedUser(Usuario usuario);
        Task<bool> ValidateExistence(Usuario usuario);
        Task<Usuario> ValidatePassword(int idUsuario, string passwordAnterior);
        Task<List<Usuario>> GetListUsuarios();
        Task<Usuario> GetUsuario(int id);
    }
}
