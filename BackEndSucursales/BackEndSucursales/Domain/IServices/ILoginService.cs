using BackEndSucursales.Domain.Models;
using System.Threading.Tasks;

namespace BackEndSucursales.Domain.IServices
{
    public interface ILoginService
    {
        Task<Usuario> ValidateUser(Usuario usuario);
    }
}
