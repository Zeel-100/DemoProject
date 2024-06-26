using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseDemo.Services.Interface
{
	public interface IDeleteFilmService
	{
		public Task<bool> DeleteFilm(int filmId);
	}
}
