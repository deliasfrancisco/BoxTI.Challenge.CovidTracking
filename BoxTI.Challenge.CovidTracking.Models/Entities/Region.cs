using BoxTI.Challenge.CovidTracking.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoxTI.Challenge.CovidTracking.Models.Entities
{
	public class Region : BaseEntity
	{
		public string Name { get; private set; }
		public string Initials { get; private set; }

		public Region(string name, string initials)
		{
			DomainException.ToThrow(!string.IsNullOrEmpty(Name), "Country name invalid");
			DomainException.ToThrow(!string.IsNullOrEmpty(Initials), "Initials invalid");

			Name = name;
			Initials = initials;
		}
	}
}
