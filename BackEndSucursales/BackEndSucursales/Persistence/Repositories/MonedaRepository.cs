using BackEndSucursales.Domain.IRepositories;
using BackEndSucursales.Domain.Models;
using BackEndSucursales.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndSucursales.Persistence.Repositories
{
    public class MonedaRepository : IMonedaRepository
    {

        private readonly AplicationDbContext _context;

        public MonedaRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Moneda> GetMonedaAsync(int idMoneda)
        {
            var moneda = await _context.Monedas_Quala.Where(x => x.Id == idMoneda).FirstOrDefaultAsync();
            return moneda;
        }

        public async Task<List<Moneda>> GetListMonedasAsync()
        {
            var listaMoneda = await _context.Monedas_Quala.Where(x => x.CodigoMoneda != null).ToListAsync();
            return listaMoneda;
        }

        public async Task SavedMonedaAsync(Moneda moneda)
        {
            _context.Add(moneda);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateExistenceAsync(Moneda moneda)
        {
            var validateExistence = await _context.Monedas_Quala.AnyAsync(x => x.CodigoMoneda == moneda.CodigoMoneda);
            return validateExistence;
        }
    }
}
