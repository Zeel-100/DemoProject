using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestCaseDemo.Models.DataModels;

[Table("Film")]
public partial class Film
{
    [Key]
    [Column("film_id")]
    public int FilmId { get; set; }

    [Column("title", TypeName = "character varying")]
    public string Title { get; set; } = null!;

    [Column("description")]
    public string? Description { get; set; }

    [Column("release_year")]
    public int? ReleaseYear { get; set; }

    [Column("language_id")]
    public int LanguageId { get; set; }

    [Column("rental_duration")]
    public int? RentalDuration { get; set; }

    [Column("rental_rate")]
    public decimal? RentalRate { get; set; }

    [Column("length")]
    public int? Length { get; set; }

    [Column("updated_date", TypeName = "timestamp without time zone")]
    public DateTime UpdatedDate { get; set; }

    [InverseProperty("Film")]
    public virtual ICollection<FilmActor> FilmActors { get; set; } = new List<FilmActor>();
}
