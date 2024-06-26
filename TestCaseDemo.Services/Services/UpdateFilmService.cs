using Microsoft.EntityFrameworkCore;
using TestCaseDemo.Models.DataContext;
using TestCaseDemo.Models.DataModels;
using TestCaseDemo.Models.Dtos;
using TestCaseDemo.Services.Interface;
using static TestCaseDemo.Services.LanguageEnum;

namespace TestCaseDemo.Services.Services
{
	public class UpdateFilmService : IUpdateFilmService
	{
		private readonly ApplicationDbContext _context;

		public UpdateFilmService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<bool> UpdateFilmAsync(FilmDto filmDto)
		{
			try
			{
				var model = await _context.Films.FindAsync(filmDto.Id);

				if (model == null)
					return false; 

				model.Title = filmDto.Title;
				model.Description = filmDto.Description;
				model.ReleaseYear = filmDto.ReleaseYear;
				model.LanguageId = LanguageValues.GetIdFromLanguageName(filmDto.Language);
				model.RentalDuration = filmDto.RentalDuration;
				model.RentalRate = filmDto.RentalRate;
				model.Length = filmDto.Length;
				model.UpdatedDate = DateTime.Now;

				_context.Films.Update(model);
				await _context.SaveChangesAsync();

				await SaveFilmActors(model.FilmId, filmDto.Actors);

				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		private async Task SaveFilmActors(int filmId, List<ActorDto> actorDtos)
		{
			var filmActors = new List<FilmActor>();

			foreach (var actorDto in actorDtos)
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

				var filmActor = new FilmActor { FilmId = filmId, ActorId = actorId };
				filmActors.Add(filmActor);
			}

			_context.FilmActors.AddRange(filmActors);
			await _context.SaveChangesAsync();
		}
		public async Task<bool> UpdateFilmPartialAsync(FilmUpdateDto filmDto)
		{
			try
			{
				Film model = new()
				{
					FilmId = filmDto.Id,
					Title = filmDto.Title,
					Description = filmDto.Description,
					ReleaseYear = filmDto.ReleaseYear,
					LanguageId = LanguageValues.GetIdFromLanguageName(filmDto.Language),
					RentalDuration = filmDto.RentalDuration,
					RentalRate = filmDto.RentalRate,
					Length = filmDto.Length,
					UpdatedDate = DateTime.Now
				};
				_context.Films.Update(model);
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
