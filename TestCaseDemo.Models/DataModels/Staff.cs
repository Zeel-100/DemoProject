using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestCaseDemo.Models.DataModels;

[Table("staff")]
public partial class Staff
{
    [Key]
    [Column("staff_id")]
    public int StaffId { get; set; }

    [Column("first_name")]
    [StringLength(45)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(45)]
    public string LastName { get; set; } = null!;

    [Column("address_id")]
    public int AddressId { get; set; }

    [Column("email")]
    [StringLength(50)]
    public string? Email { get; set; }

    [Column("store_id")]
    public int StoreId { get; set; }

    [Required]
    [Column("active")]
    public bool? Active { get; set; }

    [Column("username")]
    [StringLength(16)]
    public string Username { get; set; } = null!;

    [Column("password")]
    [StringLength(40)]
    public string? Password { get; set; }

    [Column("last_update", TypeName = "timestamp without time zone")]
    public DateTime LastUpdate { get; set; }

    [Column("picture")]
    public byte[]? Picture { get; set; }

    [ForeignKey("AddressId")]
    [InverseProperty("Staff")]
    public virtual Address Address { get; set; } = null!;

    [InverseProperty("Staff")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    [InverseProperty("Staff")]
    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();

    [InverseProperty("ManagerStaff")]
    public virtual Store? Store { get; set; }
}
