using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entities;

public partial class Order
{
    public int Id { get; set; }

    public DateTime Data { get; set; }

    public int Sum { get; set; }

    public int UserId { get; set; }
    [JsonIgnore]
    public virtual ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();

    public virtual User User { get; set; } = null!;
}
