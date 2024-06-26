using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDemo.Models.DataContext;
using TestCaseDemo.Models.DataModels;
using TestCaseDemo.Services.Interface;

namespace TestCaseDemo.Services.Services
{
	public class DeleteFilmService : IDeleteFilmService
	{
		private readonly ApplicationDbContext _context;

		public DeleteFilmService(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<bool> DeleteFilm(int filmId)
		{
			try
			{
				var film = await _context.Films.FirstOrDefaultAsync(x => x.FilmId == filmId);
				List<FilmActor> filmActors = await _context.FilmActors.Where(x => x.FilmId == filmId).ToListAsync();
				if (filmActors.Any())
				{
					foreach (var actor in filmActors)
					{
						_context.FilmActors.Remove(actor);

					}
				}
				
				_context.Films.Remove(film);
				
				_context.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				
				return false;
			}
		}
	}
}
