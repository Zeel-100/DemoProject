using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseDemo.Models.Dtos
{
	public class FilmDto
	{
		public int Id { get; set; }
		public string Title { get; set; } 
		public string Description { get; set; }

		public int ReleaseYear { get; set; }
		public string Language { get; set;}
		
		public int RentalDuration { get; set;}

		public int Length { get; set;}
		public decimal RentalRate { get; set; }	
		public List<ActorDto> Actors { get; set; } = new List<ActorDto>();

	}
	public class ActorDto
	{
		public string Name { get; set; } = string.Empty;
		public string? Gender { get; set; }
	}

}
