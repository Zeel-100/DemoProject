using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDemo.Models.Dtos;

namespace TestCaseDemo.Services.Interface
{
	public interface IUpdateFilmService
	{
		public Task<bool> UpdateFilmAsync(FilmDto filmDto);
		public Task<bool> UpdateFilmPartialAsync(FilmUpdateDto filmDto);
	}
}
