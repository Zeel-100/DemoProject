using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDemo.Models.Dtos;

namespace TestCaseDemo.Services.Interface
{
	public interface ICreateFilmService
	{
		public Task<bool> CreateFilm(FilmDto filmDto);
	}
}
