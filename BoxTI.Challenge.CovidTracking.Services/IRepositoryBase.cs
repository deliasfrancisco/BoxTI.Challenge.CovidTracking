using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.Services
{
	public interface IRepositoryBase
	{
		void Add<T>(T entity) where T : class;
		void Update<T>(T entity) where T : class;
		void Delete<T>(T entity) where T : class;
		void DeleteRange<T>(T[] entity) where T : class;
		Task<bool> SaveChangesAsync();

	}
}
