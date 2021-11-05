using Microsoft.AspNetCore.Identity;
using BoxTI.Challenge.CovidTracking.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoxTI.Challenge.CovidTracking.Models.Identity
{
	public class Role : IdentityRole<int>
	{
		public List<UserRole> UserRoles { get; set; }
	}
}
