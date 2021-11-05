using BoxTI.Challenge.CovidTracking.Data.Context;
using BoxTI.Challenge.CovidTracking.Models.Entities;
using BoxTI.Challenge.CovidTracking.Services.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.Services.Repository
{
	public class CountryRepository : ICountryRepository
	{
		private readonly BoxTIContext _context;

		public CountryRepository(BoxTIContext context)
		{
			_context = context;
		}

		public async Task<List<Country>> GetAll()
		{
			return await _context.Set<Country>()
				.ToListAsync();
		}

		public async Task<Country> GetByCountryName(string name)
		{
			return await _context.Set<Country>().FirstOrDefaultAsync(x => x.Name == name);
		}

		public async Task<Country> GetById(int id)
		{
			return await _context.Set<Country>().FirstOrDefaultAsync(x => x.Id == id);
		}

		public void Add<T>(T entity) where T : class
		{
			_context.Add(entity);
		}

		public void Update<T>(T entity) where T : class
		{
			_context.Update(entity);
		}

		public void Delete<T>(T entity) where T : class
		{
			_context.Remove(entity);
		}

		public void DeleteRange<T>(T[] entity) where T : class
		{
			_context.RemoveRange(entity);
		}

		public async Task<bool> SaveChangesAsync()
		{
			return (await _context.SaveChangesAsync()) > 0;
		}
	}
}
