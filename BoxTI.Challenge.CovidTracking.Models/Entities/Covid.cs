using BoxTI.Challenge.CovidTracking.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BoxTI.Challenge.CovidTracking.Models.Entities
{
	public class Covid : BaseEntity
	{
		public int Infected { get; private set; }
		public int Dead { get; private set; }
		public int Recovered { get; private set; }
		public int Vaccinated { get; private set; }
		public int CountryId { get; private set; }
		public Country Country { get; private set; }

		public Covid(int infected, int dead, int recovered, int vaccinated, int countryId)
		{
			DomainException.ToThrow(infected >= 0, "Infected amount invalid");
			DomainException.ToThrow(dead >= 0, "Dead amount invalid");
			DomainException.ToThrow(recovered >= 0, "Recovered amount invalid");
			DomainException.ToThrow(vaccinated >= 0, "Vaccinated amount invalid");
			DomainException.ToThrow(CountryId > 0, "GuiaId invalid");

			Infected = infected;
			Dead = dead;
			Recovered = recovered;
			Vaccinated = vaccinated;
			CountryId = countryId;
		}
	}
}
