using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestCaseDemo.Models.DataModels;

[Table("inventory")]
[Index("StoreId", "FilmId", Name = "idx_store_id_film_id")]
public partial class Inventory
{
    [Key]
    [Column("inventory_id")]
    public int InventoryId { get; set; }

    [Column("film_id")]
    public int FilmId { get; set; }

    [Column("store_id")]
    public int StoreId { get; set; }

    [Column("last_update", TypeName = "timestamp without time zone")]
    public DateTime LastUpdate { get; set; }

    [ForeignKey("FilmId")]
    [InverseProperty("Inventories")]
    public virtual Film Film { get; set; } = null!;

    [InverseProperty("Inventory")]
    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}
