using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using TestCaseDemo.Models.Dtos;
using TestCaseDemo.Models.Validation;
using TestCaseDemo.Services;
using TestCaseDemo.Services.Interface;
using TestCaseDemo.Services.Services;
using TestCasesDemo.Controllers;

namespace TestProject2
{
	public class ControllerTestCases
	{
		private readonly Mock<IGetFilmService> filmDetails;
		private readonly Mock<ICreateFilmService> createFilmService;
		private readonly Mock<IUpdateFilmService> updateFilmService;
		private readonly Mock<IDeleteFilmService> deleteFilmService;
		private readonly FilmController filmController;
		
		public ControllerTestCases()
		{
			filmDetails = new Mock<IGetFilmService>();
			createFilmService = new Mock<ICreateFilmService>();
			updateFilmService = new Mock<IUpdateFilmService>();
			deleteFilmService = new Mock<IDeleteFilmService>();
			var filmValidator = new FilmDtoValidator();
			var filmUpdateValidator = new FilmUpdateDtoValidator();

			filmController = new FilmController(
				filmDetails.Object,
				createFilmService.Object,
				updateFilmService.Object,
				deleteFilmService.Object,
				filmValidator,
				filmUpdateValidator
			);
		}
		[Fact]
		public async Task GetFilmDetailsTest() {
			
			var filmDetailsList = new List<FilmDto?>
			{
				new FilmDto { Id = 1, Title = "Film 1" , Language= "English"},
				new FilmDto { Id = 2, Title = "Film 2" ,Language= "English"},
			};
			this.filmDetails.Setup(x => x.GetFilms()).Returns(Task.FromResult(filmDetailsList));

			var result = await filmController.GetFilmDetails();

			var okResult = Assert.IsType<OkObjectResult>(result);
			var response = Assert.IsType<List<FilmDto?>>(okResult.Value);
			Assert.Equal(filmDetailsList, response);
			this.filmDetails.Verify(s => s.GetFilms(), Times.Once());
		}
		[Fact]
		public async Task GetFilmById()
		{
			var Id = 1;
			FilmDto? dto = new()
			{
				Id = 1,
				Title = "Title",
				Description = "Description",
			};
			this.filmDetails.Setup(x => x.GetFilmById(Id)).Returns(Task.FromResult(dto));

			var result = await this.filmController.GetFilmDetailById(Id);

			var okResult = Assert.IsType<OkObjectResult>(result);
			var response = Assert.IsType<FilmDto?>(okResult.Value);
			this.filmDetails.Verify(s => s.GetFilmById(Id), Times.Once());
			Assert.Same(dto, okResult.Value);
		}
		[Fact]
		public async Task AddFilmWithValidFilmDto()
		{
			var filmDto = new FilmDto
			{
				Id = 1,
				Title = "Sample Film",
				Description = "This is a sample film description.",
				ReleaseYear = 2023,
				Language = "English",
				RentalDuration = 7,
				Length = 120,
				RentalRate = 9.99m, 
				Actors = new List<ActorDto>
				{
					new ActorDto { Name = "John Doe", Gender = "Male" },
					new ActorDto { Name = "Jane Smith", Gender = "Female" }
				}
			};


			var result = await filmController.AddFilm(filmDto);

			var okResult = Assert.IsType<OkObjectResult>(result);
			Assert.Same(filmDto, okResult.Value);

		}

		[Fact]
		public async Task AddFilmWithNullFilmDto()
		{
			var result = await filmController.AddFilm(null);

			Assert.IsType<BadRequestResult>(result);
		}
		

		[Fact]
		public async Task UpdateFilmWithValidFilmDto()
		{
			var filmId = 1;
			var filmDto = new FilmUpdateDto
			{
				Id = 1,
				Title = "Updated Title",
				Language = "English",
				Description = "Updated Description",
				RentalRate = 10,
			};
			filmDetails.Setup(x => x.CheckIfFilmExists(filmId)).ReturnsAsync(true);

			this.updateFilmService.Setup(x => x.UpdateFilmPartialAsync(filmDto)).ReturnsAsync(true);

			var result = await filmController.UpdatePartialFilm(filmId, filmDto);

			var okResult = Assert.IsType<OkObjectResult>(result);
			var response = Assert.IsType<FilmUpdateDto>(okResult.Value);
			Assert.Equal(filmDto, response);
			this.updateFilmService.Verify(s => s.UpdateFilmPartialAsync(filmDto), Times.Once());

		}

		[Fact]
		public async Task UpdateFilmWithNullFilmDto()
		{
			var filmId = 1;
			FilmUpdateDto? filmDto = null;

			var result = await filmController.UpdatePartialFilm(filmId, filmDto);

			var badRequestResult = Assert.IsType<BadRequestResult>(result);
			Assert.Equal(400, badRequestResult?.StatusCode);
		}
		[Fact]
		public async Task UpdateFilmWithMismatchedFilmId()
		{
			var filmDto = new FilmUpdateDto { 
				Id = 2, 
				Title = "Test Film", 
				ReleaseYear = 2022 
			};
			var filmId = 1;

			var result = await filmController.UpdatePartialFilm(filmId, filmDto);

			Assert.IsType<BadRequestResult>(result);
		}
		[Fact]
		public async Task DeleteFilmWithValidFilmId()
		{
			var filmId = 1;
			filmDetails.Setup(x => x.CheckIfFilmExists(filmId)).ReturnsAsync(true);

			var result = await filmController.DeleteFilm(filmId);

			Assert.IsType<OkResult>(result);
			deleteFilmService.Verify(x => x.DeleteFilm(filmId), Times.Once());
		}

		[Fact]
		public async Task DeleteFilmWithZeroFilmId()
		{
			var filmId = 0;

			var result = await filmController.DeleteFilm(filmId);

			Assert.IsType<BadRequestResult>(result);
		}
		

		
	}
}