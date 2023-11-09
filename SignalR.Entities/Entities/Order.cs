﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SignalR.Entities.Entities;

public class Order
{
    public int Id { get; set; }
    public string? TableNumber { get; set; }
    public string? Description { get; set; }

    [Column(TypeName = "Date")]
    public DateTime OrderDate { get; set; }
    public decimal TotalPrice { get; set; }
    public List<OrderDetail>? OrderDetails { get; set; }

}