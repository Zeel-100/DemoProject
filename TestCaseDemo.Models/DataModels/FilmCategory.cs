﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestCaseDemo.Models.DataModels;

[PrimaryKey("FilmId", "CategoryId")]
[Table("film_category")]
public partial class FilmCategory
{
    [Key]
    [Column("film_id")]
    public int FilmId { get; set; }

    [Key]
    [Column("category_id")]
    public int CategoryId { get; set; }

    [Column("last_update", TypeName = "timestamp without time zone")]
    public DateTime LastUpdate { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("FilmCategories")]
    public virtual Category Category { get; set; } = null!;

    [ForeignKey("FilmId")]
    [InverseProperty("FilmCategories")]
    public virtual Film Film { get; set; } = null!;
}
