using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDemo.Models.DataContext;
using TestCaseDemo.Models.DataModels;
using TestCaseDemo.Models.Dtos;
using TestCaseDemo.Models.Validation;
using TestCaseDemo.Services.Interface;
using static TestCaseDemo.Services.LanguageEnum;

namespace TestCaseDemo.Services.Services
{
	public class CreateFilmService : ICreateFilmService
	{
		private readonly ApplicationDbContext _context;
		public CreateFilmService(ApplicationDbContext context) { 
			_context = context;
		}

		public async Task<bool> CreateFilm(FilmDto filmDto)
		{
			try
			{
				Film model = new()
				{
					Title = filmDto.Title,
					Description = filmDto.Description,
					ReleaseYear = filmDto.ReleaseYear,
					LanguageId = LanguageValues.GetIdFromLanguageName(filmDto.Language),
					RentalDuration = filmDto.RentalDuration,
					RentalRate = filmDto.RentalRate,
					Length = filmDto.Length,
					UpdatedDate = DateTime.Now
				};

				_context.Films.Add(model);
				await _context.SaveChangesAsync(); 

				var filmActors = new List<FilmActor>();

				foreach (var actorDto in filmDto.Actors)
				{
					var existingActor = await _context.Actors
						.FirstOrDefaultAsync(a => a.ActorName == actorDto.Name && a.Gender == actorDto.Gender);

					int actorId;

					if (existingActor == null)
					{
						Actor newActor = new() { ActorName = actorDto.Name, Gender = actorDto.Gender };
						_context.Actors.Add(newActor);
						await _context.SaveChangesAsync(); 
						actorId = newActor.ActorId;
					}
					else
					{
						actorId = existingActor.ActorId;
					}

					var filmActor = new FilmActor { FilmId = model.FilmId, ActorId = actorId };
					filmActors.Add(filmActor);
				}

				_context.FilmActors.AddRange(filmActors);
				await _context.SaveChangesAsync();

				return true;
			}
			catch (Exception)
			{
				return false;
			}

		}
	}
}
