using BoxTI.Challenge.CovidTracking.Services.IRepository;
using BoxTI.Challenge.CovidTracking.Services.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.API
{
	public static class DependencyRegister
	{
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
			services.AddScoped<ICountryRepository, CountryRepository>();
			services.AddScoped<ICovidRepository, CovidRepository>();

		}
    }
}
