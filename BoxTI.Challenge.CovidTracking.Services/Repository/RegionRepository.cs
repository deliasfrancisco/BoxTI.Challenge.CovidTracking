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
	public class RegionRepository : IRegionRepository
	{
		private readonly BoxTIContext _context;

		public RegionRepository(BoxTIContext context)
		{
			_context = context;
		}

		public async Task<List<Region>> GetAll()
		{
			return await _context.Set<Region>()
				.ToListAsync();
		}

		public async Task<Region> GetByCountryName(string name)
		{
			return await _context.Set<Region>().FirstOrDefaultAsync(x => x.Name == name);
		}

		public async Task<Region> GetById(int id)
		{
			return await _context.Set<Region>().FirstOrDefaultAsync(x => x.Id == id);
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
