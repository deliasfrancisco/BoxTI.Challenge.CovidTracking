using BoxTI.Challenge.CovidTracking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.Services.IRepository
{
	public interface ICountryRepository : IRepositoryBase
	{
		Task<List<Country>> GetAll();
		Task<Country> GetById(int id);
		Task<Country> GetByCountryName(string name);
	}
}
