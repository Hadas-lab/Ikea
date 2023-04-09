using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entities;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Password { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
