﻿using BackEndSucursales.Domain.IRepositories;
using BackEndSucursales.Domain.IServices;
using BackEndSucursales.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndSucursales.Services
{
    public class MonedaService : IMonedaService
    {
        private readonly IMonedaRepository _repository;

        public MonedaService(IMonedaRepository monedaRepository)
        {
			_repository = monedaRepository;
        }

		public async Task SavedMonedaAsync(Moneda moneda)
		{
			await _repository.SavedMonedaAsync(moneda);
		}

		public async Task<bool> ValidateExistenceAsync(Moneda moneda)
		{
			return await _repository.ValidateExistenceAsync(moneda);
		}

        public async Task<List<Moneda>> GetListMonedasAsync()
		{
			return await _repository.GetListMonedasAsync();
		}

        public async Task<Moneda> GetMonedaAsync(int idMoneda)
		{
			return await _repository.GetMonedaAsync(idMoneda);
		}
	}
}
