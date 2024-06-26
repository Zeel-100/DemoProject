using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestCaseDemo.Models.DataModels;

[Table("Language")]
public partial class Language
{
    [Key]
    [Column("language_id")]
    public int LanguageId { get; set; }

    [Column("language_name", TypeName = "character varying")]
    public string LanguageName { get; set; } = null!;
}
