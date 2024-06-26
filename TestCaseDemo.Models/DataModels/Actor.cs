using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestCaseDemo.Models.DataModels;

[Table("Actor")]
public partial class Actor
{
    [Key]
    public int ActorId { get; set; }

    [Column(TypeName = "character varying")]
    public string ActorName { get; set; } = null!;

    [Column(TypeName = "character varying")]
    public string? Gender { get; set; }

    [InverseProperty("Actor")]
    public virtual ICollection<FilmActor> FilmActors { get; set; } = new List<FilmActor>();
}
