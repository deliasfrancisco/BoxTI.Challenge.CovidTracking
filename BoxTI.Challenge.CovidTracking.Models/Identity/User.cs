using Microsoft.AspNetCore.Identity;
using BoxTI.Challenge.CovidTracking.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BoxTI.Challenge.CovidTracking.Models.Identity
{
	public class User : IdentityUser<int>
	{
		[Column(TypeName = "varchar(150)")]
		public string FullName { get; set; }
		public List<UserRole> UserRoles { get; set; }

	}
}
