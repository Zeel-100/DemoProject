using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseDemo.Models.Dtos
{
	public class FilmUpdateDto
	{
		public int Id { get; set; }
		[Required]
		public string Title { get; set; } = string.Empty;
		public string? Description { get; set; }

		public int ReleaseYear { get; set; }
		[Required]
		public string? Language { get; set; }

		public int RentalDuration { get; set; }

		public int Length { get; set; }
		public decimal RentalRate { get; set; }
	}
}
