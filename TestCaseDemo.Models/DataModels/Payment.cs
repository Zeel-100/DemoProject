using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestCaseDemo.Models.DataModels;

[Table("payment")]
[Index("CustomerId", Name = "idx_fk_customer_id")]
[Index("RentalId", Name = "idx_fk_rental_id")]
[Index("StaffId", Name = "idx_fk_staff_id")]
public partial class Payment
{
    [Key]
    [Column("payment_id")]
    public int PaymentId { get; set; }

    [Column("customer_id")]
    public int CustomerId { get; set; }

    [Column("staff_id")]
    public int StaffId { get; set; }

    [Column("rental_id")]
    public int RentalId { get; set; }

    [Column("amount")]
    [Precision(5, 2)]
    public decimal Amount { get; set; }

    [Column("payment_date", TypeName = "timestamp without time zone")]
    public DateTime PaymentDate { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Payments")]
    public virtual Customer Customer { get; set; } = null!;

    [ForeignKey("RentalId")]
    [InverseProperty("Payments")]
    public virtual Rental Rental { get; set; } = null!;

    [ForeignKey("StaffId")]
    [InverseProperty("Payments")]
    public virtual Staff Staff { get; set; } = null!;
}
