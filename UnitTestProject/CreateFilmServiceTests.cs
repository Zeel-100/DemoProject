using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Webinex.Coded;

namespace UnitTestProject
{
	public class CreateFilmServiceTests
	{
		private readonly Mock<ApplicationDbContext> _mockContext;
		private readonly CreateFilmService _service;

		public CreateFilmServiceTests()
		{
			_mockContext = new Mock<ApplicationDbContext>();
			_service = new CreateFilmService(_mockContext.Object);
		}

		[Fact]
		public async Task CreateFilm_ShouldReturnTrue_WhenFilmIsCreated()
		{
			// Arrange
			var filmDto = new FilmDto
			{
				Title = "Test Film",
				Description = "Test Description",
				ReleaseYear = 2022,
				RentalDuration = 5,
				RentalRate = 2.99m,
				Length = 120
			};

			// Act
			var result = await _service.CreateFilm(filmDto);

			// Assert
			Assert.True(result);
			_mockContext.Verify(x => x.Films.AddAsync(It.IsAny<Film>(), default), Times.Once);
			_mockContext.Verify(x => x.SaveChangesAsync(default), Times.Once);
		}
	}

	[Fact]
	public async Task CreateFilm_ShouldReturnFalse_WhenExceptionIsThrown()
	{
		// Arrange
		var filmDto = new FilmDto
		{
			Title = "Test Film",
			Description = "Test Description",
			ReleaseYear = 2022,
			RentalDuration = 5,
			RentalRate = 2.99m,
			Length = 120
		};

		_mockContext.Setup(x => x.Films.AddAsync(It.IsAny<Film>(), default)).ThrowsAsync(new Exception());

		// Act
		var result = await _service.CreateFilm(filmDto);

		// Assert
		Assert.False(result);
		_mockContext.Verify(x => x.SaveChangesAsync(default), Times.Never);
	}
}
}
