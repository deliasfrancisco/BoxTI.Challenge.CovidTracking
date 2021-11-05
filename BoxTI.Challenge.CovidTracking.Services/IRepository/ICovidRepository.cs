using BoxTI.Challenge.CovidTracking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.Services.IRepository
{
	public interface ICovidRepository : IRepositoryBase
	{
		Task<List<Covid>> GetAll();
		Task<Covid> GetById(int id);
		Task<Covid> GetByCountry(string name);
	}
}
