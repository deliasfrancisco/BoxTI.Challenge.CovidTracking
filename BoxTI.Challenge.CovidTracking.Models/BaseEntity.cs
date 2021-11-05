using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BoxTI.Challenge.CovidTracking.Models
{
	public class BaseEntity
	{
		[Key]
		public int Id { get; set; }

		//protected BaseEntity()
		//{
		//	Id = new Guid().ToString();
		//}
	}
}
