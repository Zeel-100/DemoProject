using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDemo.Models.Dtos;
using TestCaseDemo.Models.Validation;

namespace TestProject2
{
	public class ValidatorTests
	{
		private readonly FilmDtoValidator _filmvalidator = new();
		private readonly ActorDtoValidator _actorvalidator = new();


		[Fact]
		public void TitleNullTest()
		{
			var filmDto = new FilmDto { Title = null };

			var result = _filmvalidator.TestValidate(filmDto);

			result.ShouldHaveValidationErrorFor(film => film.Title)
				  .WithErrorMessage("Title is required.");
		}

		[Fact]
		public void LanguageNullTest()
		{
			var filmDto = new FilmDto { Language = null };

			var result = _filmvalidator.TestValidate(filmDto);

			result.ShouldHaveValidationErrorFor(film => film.Language)
				  .WithErrorMessage("Language is required.");
		}
		[Fact]
		public void ActorNullTest()
		{
			var actorDto = new ActorDto { Name = null };

			var result = _actorvalidator.TestValidate(actorDto);

			result.ShouldHaveValidationErrorFor(x => x.Name)
				  .WithErrorMessage("'Name' must not be empty.");
		}
		[Fact]
		public void GenderNullTest()
		{
			var actorDto = new ActorDto { Gender = null };

			var result = _actorvalidator.TestValidate(actorDto);

			result.ShouldHaveValidationErrorFor(x => x.Gender)
				  .WithErrorMessage("Actor gender is required.");
		}

		[Fact]
		public void DescriptionNullTest()
		{
			var filmDto = new FilmDto { Description = null };

			var result = _filmvalidator.TestValidate(filmDto);

			result.ShouldHaveValidationErrorFor(film => film.Description)
				  .WithErrorMessage("Description is required.");
		}
		[Fact]
		public void DescriptionEmptyTest()
		{
			var filmDto = new FilmDto { Description = string.Empty };

			var result = _filmvalidator.TestValidate(filmDto);

			result.ShouldHaveValidationErrorFor(film => film.Description)
				  .WithErrorMessage("Description is required.");
		}
		[Fact]
		public void RentalRateZeroTest()
		{
			var filmDto = new FilmDto { RentalRate = 0 };

			var result = _filmvalidator.TestValidate(filmDto);

			result.ShouldHaveValidationErrorFor(film => film.RentalRate)
				  .WithErrorMessage("Rental rate must be greater than zero.");
		}

		[Fact]
		public void RentalRateGreaterThanZeroTest()
		{
			var filmDto = new FilmDto { RentalRate = 10 };

			var result = _filmvalidator.TestValidate(filmDto);

			result.ShouldNotHaveValidationErrorFor(film => film.RentalRate);
		}

	}
}

