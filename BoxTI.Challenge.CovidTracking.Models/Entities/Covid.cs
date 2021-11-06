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
		public int RegionId { get; private set; }
		public Region Region { get; private set; }

		public Covid(int infected, int dead, int recovered, int regionId)
		{
			DomainException.ToThrow(infected < 0, "Infected amount invalid");
			DomainException.ToThrow(dead < 0, "Dead amount invalid");
			DomainException.ToThrow(recovered < 0, "Recovered amount invalid");
			DomainException.ToThrow(regionId <= 0, " region id is invalid");

			Infected = infected;
			Dead = dead;
			Recovered = recovered;
			RegionId = regionId;
		}
	}
}
