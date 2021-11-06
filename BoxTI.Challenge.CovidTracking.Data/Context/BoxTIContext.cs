using BoxTI.Challenge.CovidTracking.Models.Entities;
using BoxTI.Challenge.CovidTracking.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoxTI.Challenge.CovidTracking.Data.Context
{
	public class BoxTIContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
	{
		public BoxTIContext(DbContextOptions<BoxTIContext> options) : base(options)
		{

		}
		public DbSet<Region> Regions { get; set; }
		public DbSet<Covid> Covid { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<Covid>().HasKey(c => new { c.Id, c.RegionId });
		}
	}
}
