using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDemo.Models.Dtos;

namespace TestCaseDemo.Models.Validation
{
	public class FilmDtoValidator : AbstractValidator<FilmDto>
	{
		public FilmDtoValidator()
		{
			RuleFor(film => film.Title).NotNull().NotEmpty().WithMessage("Title is required.");
			RuleFor(film => film.Language).NotNull().NotEmpty().WithMessage("Language is required.");
			RuleFor(film => film.Description).NotNull().NotEmpty().WithMessage("Description is required.");
			RuleFor(film => film.RentalRate).GreaterThan(0).WithMessage("Rental rate must be greater than zero.");
			RuleForEach(film => film.Actors).SetValidator(new ActorDtoValidator());
		}
	}

	public class ActorDtoValidator : AbstractValidator<ActorDto>
	{
		public ActorDtoValidator()
		{
			RuleFor(actor => actor.Name).NotNull().NotEmpty().WithMessage("Actor name is required.");
			RuleFor(actor => actor.Gender).NotNull().NotEmpty().WithMessage("Actor gender is required.");
		}
	}
}

