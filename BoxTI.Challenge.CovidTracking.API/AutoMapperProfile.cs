using AutoMapper;
using BoxTI.Challenge.CovidTracking.Models.Dtos;
using BoxTI.Challenge.CovidTracking.Models.Entities;
using BoxTI.Challenge.CovidTracking.Models.Identity;
using BoxTI.Challenge.CovidTracking.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.API
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<User, UserDto>().ReverseMap();
			CreateMap<User, UserLoginDto>().ReverseMap();
			CreateMap<Region, RegionViewModel>().ReverseMap();
			CreateMap<Covid, CovidViewModel>().ReverseMap();
		}
	}
}
