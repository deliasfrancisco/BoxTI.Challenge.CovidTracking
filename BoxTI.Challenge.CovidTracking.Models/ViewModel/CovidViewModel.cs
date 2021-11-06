using System;
using System.Collections.Generic;
using System.Text;

namespace BoxTI.Challenge.CovidTracking.Models.ViewModel
{
	public class CovidViewModel
	{
		public int Infected { get; set; }
		public int Dead { get; set; }
		public int Recovered { get; set; }
		public RegionViewModel Region { get; set; }
	}
}
