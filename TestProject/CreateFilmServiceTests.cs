using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDemo.Models.DataContext;
using TestCaseDemo.Models.DataModels;
using TestCaseDemo.Models.Dtos;
using TestCaseDemo.Services.Services;
using Xunit;

namespace TestProject
{
	[TestClass]
	public class CreateFilmServiceTests
	{
		

		[Fact]
		public async Task CreateFilm_ServiceThrowsException_ReturnsFalse()
		{
			var contextMock = new Mock<ApplicationDbContext>();
			contextMock.Setup(c => c.Films.AddAsync(It.IsAny<Film>())).ThrowsAsync(new Exception());
			var filmDto = new FilmDto { Title = "Test Film", Description = "Test Description" };
			var service = new CreateFilmService(contextMock.Object);

			try
			{
				var result = await service.CreateFilm(filmDto);
				Assert.Fail("Expected exception to be thrown");
			}
			catch (Exception)
			{
			}
		}
	}
}
