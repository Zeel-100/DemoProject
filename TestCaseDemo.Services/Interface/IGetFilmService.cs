using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDemo.Models.Dtos;

namespace TestCaseDemo.Services.Interface
{
	public interface IGetFilmService
	{
		public Task<bool> CheckIfFilmExists(int filmId);
		public Task<List<FilmDto?>> GetFilms();

		public Task<FilmDto?> GetFilmById(int filmId);

	}
}
