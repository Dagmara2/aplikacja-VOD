using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using VOD.Dtos;
using VOD.Models;

namespace VOD.App_Start
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{

			// Domain to Dto
			
			Mapper.CreateMap<Movie, MovieDto>();
			
			Mapper.CreateMap<Genre, GenreDto>();
			Mapper.CreateMap<Dir, DirDto>();
			

			
			Mapper.CreateMap<MovieDto, Movie>()
				.ForMember(c => c.Id, opt => opt.Ignore());

			Mapper.CreateMap<DirDto, Dir>()
				.ForMember(c => c.Id, opt => opt.Ignore());

		}
	}
}