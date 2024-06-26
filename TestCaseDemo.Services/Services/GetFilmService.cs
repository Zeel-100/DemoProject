using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDemo.Models.DataContext;
using TestCaseDemo.Models.Dtos;
using TestCaseDemo.Services.AutoMapper;
using TestCaseDemo.Services.Interface;

namespace TestCaseDemo.Services.Services
{
	public class GetFilmService : IGetFilmService
	{
		private readonly ApplicationDbContext _context;

		public GetFilmService(ApplicationDbContext context) {
			_context = context;
		}

		public async Task<bool> CheckIfFilmExists(int filmId)
		{
			var result = await _context.Films.AnyAsync(f => f.FilmId == filmId);
			return result;
		}
		public async Task<List<FilmDto?>> GetFilms()
		{
			var mapper = FilmMapper.CreateMapper();

			var films = await _context.Films
				.Include(f => f.FilmActors)
				.ThenInclude(fa => fa.Actor)
				.ToListAsync();

			List<FilmDto?> result = mapper.Map<List<FilmDto?>>(films);

			return result;
		}

		public async Task<FilmDto?> GetFilmById(int filmId)
		{
			var mapper = FilmMapper.CreateMapper();

			var film = await _context.Films
				.Include(f => f.FilmActors)
				.ThenInclude(fa => fa.Actor)
				.FirstOrDefaultAsync(x => x.FilmId == filmId);

			FilmDto? result = mapper.Map<FilmDto?>(film);

			return result;
		}

	}
}
