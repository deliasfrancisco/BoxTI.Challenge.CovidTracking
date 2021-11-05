using System;
using System.Collections.Generic;
using System.Text;

namespace BoxTI.Challenge.CovidTracking.Models.Dtos
{
	public class CovidDto
	{
		public int Id { get; set; }
		public int Infected { get; set; }
		public int Dead { get; set; }
		public int Recovered { get; set; }
		public int CountryId { get; set; }
	}
}
