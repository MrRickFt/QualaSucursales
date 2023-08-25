using BackEndSucursales.Domain.IRepositories;
using BackEndSucursales.Domain.IServices;
using BackEndSucursales.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndSucursales.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<List<Usuario>> GetListUsuarios()
        {
            return await _usuarioRepository.GetListUsuarios();
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            return await _usuarioRepository.GetUsuario(id);
        }

        public async Task SavedUser(Usuario usuario)
        {
            await _usuarioRepository.SavedUser(usuario);
        }

        public async Task<bool> ValidateExistence(Usuario usuario)
        {
            return await _usuarioRepository.ValidateExistence(usuario);
        }

        public async Task<Usuario> ValidatePassword(int idUsuario, string passwordAnterior)
        {
            return await _usuarioRepository.ValidatePassword(idUsuario, passwordAnterior);
        }
    }
}
