using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestCaseDemo.Models.DataModels;

[Table("FilmActor")]
public partial class FilmActor
{
    [Key]
    public int Id { get; set; }

    public int FilmId { get; set; }

    public int ActorId { get; set; }

    [ForeignKey("ActorId")]
    [InverseProperty("FilmActors")]
    public virtual Actor Actor { get; set; } = null!;

    [ForeignKey("FilmId")]
    [InverseProperty("FilmActors")]
    public virtual Film Film { get; set; } = null!;
}
