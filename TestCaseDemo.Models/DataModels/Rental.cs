using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestCaseDemo.Models.DataModels;

[Table("rental")]
[Index("InventoryId", Name = "idx_fk_inventory_id")]
[Index("RentalDate", "InventoryId", "CustomerId", Name = "idx_unq_rental_rental_date_inventory_id_customer_id", IsUnique = true)]
public partial class Rental
{
    [Key]
    [Column("rental_id")]
    public int RentalId { get; set; }

    [Column("rental_date", TypeName = "timestamp without time zone")]
    public DateTime RentalDate { get; set; }

    [Column("inventory_id")]
    public int InventoryId { get; set; }

    [Column("customer_id")]
    public int CustomerId { get; set; }

    [Column("return_date", TypeName = "timestamp without time zone")]
    public DateTime? ReturnDate { get; set; }

    [Column("staff_id")]
    public int StaffId { get; set; }

    [Column("last_update", TypeName = "timestamp without time zone")]
    public DateTime LastUpdate { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Rentals")]
    public virtual Customer Customer { get; set; } = null!;

    [ForeignKey("InventoryId")]
    [InverseProperty("Rentals")]
    public virtual Inventory Inventory { get; set; } = null!;

    [InverseProperty("Rental")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    [ForeignKey("StaffId")]
    [InverseProperty("Rentals")]
    public virtual Staff Staff { get; set; } = null!;
}
