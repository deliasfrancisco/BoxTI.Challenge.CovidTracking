using BoxTI.Challenge.CovidTracking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.Services.IRepository
{
	public interface IRegionRepository : IRepositoryBase
	{
		Task<List<Region>> GetAll();
		Task<Region> GetById(int id);
		Task<Region> GetByCountryName(string name);
	}
}
