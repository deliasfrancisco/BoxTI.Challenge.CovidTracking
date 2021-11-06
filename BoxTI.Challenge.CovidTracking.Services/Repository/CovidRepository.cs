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
	public class CovidRepository : ICovidRepository
	{
		private readonly BoxTIContext _context;

		public CovidRepository(BoxTIContext context)
		{
			_context = context;
		}

		public async Task<List<Covid>> GetAll()
		{
			return await _context.Set<Covid>()
				.Include(x => x.Region)
				.OrderByDescending(o => o.Infected)
				.ToListAsync();
		}

		public async Task<Covid> GetById(int id)
		{
			return await _context.Set<Covid>()
				.Include(x => x.Region)
				.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<Covid> GetByCountry(string name)
		{
			return await _context.Set<Covid>()
				.Include(x => x.Region)
				.FirstOrDefaultAsync(x => x.Region.Name == name);
		}

		public async Task<bool> SaveChangesAsync()
		{
			return (await _context.SaveChangesAsync()) > 0;
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

	}
}
