using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestCaseDemo.Models.DataModels;

[Table("country")]
public partial class Country
{
    [Key]
    [Column("country_id")]
    public int CountryId { get; set; }

    [Column("country")]
    [StringLength(50)]
    public string Country1 { get; set; } = null!;

    [Column("last_update", TypeName = "timestamp without time zone")]
    public DateTime LastUpdate { get; set; }

    [InverseProperty("Country")]
    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}
