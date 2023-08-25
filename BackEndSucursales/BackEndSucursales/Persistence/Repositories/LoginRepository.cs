using BackEndSucursales.Domain.IRepositories;
using BackEndSucursales.Domain.Models;
using BackEndSucursales.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndSucursales.Persistence.Repositories
{
    public class LoginRepository : ILoginRepository
    {

        private readonly AplicationDbContext _context;

        public LoginRepository(AplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<Usuario> ValidateUser(Usuario usuario)
        {
            var user = await _context.Usuarios_Quala.Where(x => x.NombreUsuario == usuario.NombreUsuario 
                                                && x.Password == usuario.Password).FirstOrDefaultAsync();
            return user;
        }
    }
}
