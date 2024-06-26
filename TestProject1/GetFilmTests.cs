using Moq;
using System.Linq.Expressions;
using TestCaseDemo.Models.DataContext;
using TestCaseDemo.Models.DataModels;
using TestCaseDemo.Models.Dtos;
using TestCaseDemo.Services.Services;
using Xunit;
using FluentAssertions;

namespace TestProject1
{
	[TestFixture]
	public class GetFilmTests
	{
		
		private GetFilmService _getfilm;
		private readonly ApplicationDbContext _context;
		[SetUp]
		public void Setup()
		{
			_getfilm = new GetFilmService(_context);
		}

		[Test]
		public void GetFilmById_Test()
		{
			int Id = 0;
			Assert.Fail("Id not provided");
		}
		
		[Fact]
		public async Task GetFilmByIDTest()
		{
			var filmTask = _getfilm.GetFilmById(1);
			var film = await filmTask;
			film?.Title.Should().NotBeNullOrEmpty();
		}
	}
}