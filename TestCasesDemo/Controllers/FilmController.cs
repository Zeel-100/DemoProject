using FluentValidation;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestCaseDemo.Models.DataModels;
using TestCaseDemo.Models.Dtos;
using TestCaseDemo.Models.Validation;
using TestCaseDemo.Services.Interface;

namespace TestCasesDemo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FilmController : ControllerBase
	{
		private readonly IGetFilmService _filmDetails;
		private readonly ICreateFilmService _createFilmService;
		private readonly IUpdateFilmService _updateFilmService;
		private readonly IDeleteFilmService _deleteFilmService;
		private readonly FilmDtoValidator _filmvalidator = new();
		private readonly FilmUpdateDtoValidator _filmupdatevalidator = new();

		public FilmController(IGetFilmService filmDetails, ICreateFilmService createFilmService, IUpdateFilmService updateFilmService, IDeleteFilmService deleteFilmService , FilmDtoValidator filmvalidator,FilmUpdateDtoValidator filmupdatevalidator)
		{
			_filmDetails = filmDetails;
			_createFilmService = createFilmService;
			_updateFilmService = updateFilmService;
			_deleteFilmService = deleteFilmService;
			_filmvalidator = filmvalidator;
			_filmupdatevalidator = filmupdatevalidator;
		}
		[HttpGet]
		public async Task<IActionResult> GetFilmDetails()
		{
			var result = await _filmDetails.GetFilms();
			return Ok(result);
		}

		[HttpGet("{filmId:int}")]
		public async Task<IActionResult> GetFilmDetailById(int filmId)
		{
			if (filmId == 0)
			{
				return BadRequest();
			}
			FilmDto? result = await _filmDetails.GetFilmById(filmId);
			return Ok(result);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> AddFilm([FromBody] FilmDto? film)
		{
			if (film == null)
			{
				return BadRequest();
			}

			var x = _filmvalidator.Validate(film);
			if (!x.IsValid)
			{
				return BadRequest(x.Errors); 
			}
			await _createFilmService.CreateFilm(film);
			return Ok(film);
		}
		
		[HttpPut]
		public async Task<IActionResult> UpdatePartialFilm(int filmId, [FromBody] FilmUpdateDto? film)
		{
			if (film == null || filmId != film.Id)
			{
				return BadRequest();
			}
			if (!(await _filmDetails.CheckIfFilmExists(filmId)))
			{
				return NotFound();
			}
			var x = _filmupdatevalidator.Validate(film);
			if (!x.IsValid)
			{
				return BadRequest(x.Errors);
			}
			await _updateFilmService.UpdateFilmPartialAsync(film);
			return Ok(film);

		}
		[HttpDelete]
		public async Task<IActionResult> DeleteFilm(int filmId)
		{
			if (filmId == 0)
			{
				return BadRequest();
			}
			var result = await _filmDetails.CheckIfFilmExists(filmId);
			if (!result)
			{
				return NotFound();
			}
			await _deleteFilmService.DeleteFilm(filmId);
			return Ok();
		}
	}
}
