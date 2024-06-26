using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestCaseDemo.Models.DataModels;

[Table("order_details")]
public partial class OrderDetail
{
    [Key]
    [Column("orderid")]
    public int Orderid { get; set; }

    [Column("customer_first_name")]
    [StringLength(50)]
    public string CustomerFirstName { get; set; } = null!;

    [Column("product_name")]
    [StringLength(50)]
    public string ProductName { get; set; } = null!;

    [Column("ordered_from")]
    [StringLength(50)]
    public string OrderedFrom { get; set; } = null!;

    [Column("order_amount")]
    [Precision(7, 2)]
    public decimal? OrderAmount { get; set; }

    [Column("order_date")]
    public DateOnly OrderDate { get; set; }

    [Column("delievery_date")]
    public DateOnly? DelieveryDate { get; set; }

    [Column("cancel_date")]
    public DateOnly? CancelDate { get; set; }
}
