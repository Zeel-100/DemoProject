using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestCaseDemo.Models.DataModels;

[Table("store")]
[Index("ManagerStaffId", Name = "idx_unq_manager_staff_id", IsUnique = true)]
public partial class Store
{
    [Key]
    [Column("store_id")]
    public int StoreId { get; set; }

    [Column("manager_staff_id")]
    public int ManagerStaffId { get; set; }

    [Column("address_id")]
    public int AddressId { get; set; }

    [Column("last_update", TypeName = "timestamp without time zone")]
    public DateTime LastUpdate { get; set; }

    [ForeignKey("AddressId")]
    [InverseProperty("Stores")]
    public virtual Address Address { get; set; } = null!;

    [ForeignKey("ManagerStaffId")]
    [InverseProperty("Store")]
    public virtual Staff ManagerStaff { get; set; } = null!;
}
