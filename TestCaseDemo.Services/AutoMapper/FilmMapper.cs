using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using TestCaseDemo.Models.DataModels;
using TestCaseDemo.Models.Dtos;
using TestCaseDemo.Models.DataModels;
using static TestCaseDemo.Services.LanguageEnum;

namespace TestCaseDemo.Services.AutoMapper
{
	public class FilmMapper
	{
		public static IMapper CreateMapper()
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<Film, FilmDto>()
				   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.FilmId))
				   .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
				   .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
				   .ForMember(dest => dest.ReleaseYear, opt => opt.MapFrom(src => src.ReleaseYear))
				   .ForMember(dest => dest.Language, opt => opt.MapFrom(src => LanguageValues.GetEnumValueFromId<LanguageEnum.Language>(src.LanguageId)))
				   .ForMember(dest => dest.RentalDuration, opt => opt.MapFrom(src => src.RentalDuration))
				   .ForMember(dest => dest.Length, opt => opt.MapFrom(src => src.Length))
				   .ForMember(dest => dest.RentalRate, opt => opt.MapFrom(src => src.RentalRate))
				   .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.FilmActors.Select(fa => fa.Actor)));

				cfg.CreateMap<FilmDto, Film>()
				   .ForMember(dest => dest.FilmId, opt => opt.MapFrom(src => src.Id))
				   .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
				   .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
				   .ForMember(dest => dest.ReleaseYear, opt => opt.MapFrom(src => src.ReleaseYear))
				   .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => LanguageValues.GetIdFromLanguageName(src.Language)))
				   .ForMember(dest => dest.RentalDuration, opt => opt.MapFrom(src => src.RentalDuration))
				   .ForMember(dest => dest.Length, opt => opt.MapFrom(src => src.Length))
				   .ForMember(dest => dest.RentalRate, opt => opt.MapFrom(src => src.RentalRate))
				   .ForMember(dest => dest.FilmActors, opt => opt.Ignore()); 

				cfg.CreateMap<Actor, ActorDto>()
				   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ActorName))
				   .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender));

				cfg.CreateMap<ActorDto, Actor>()
				   .ForMember(dest => dest.ActorName, opt => opt.MapFrom(src => src.Name))
				   .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender));
			});

			return config.CreateMapper();
		}
	}
}
