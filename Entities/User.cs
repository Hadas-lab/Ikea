using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities;

public partial class User
{
    public int Id { get; set; }

    [EmailAddress]
    public string Email { get; set; } = null!;

    [StringLength(20, ErrorMessage = "first name length must be bigger than 2", MinimumLength = 2)]
    public string FirstName { get; set; } = null!;
   
    [StringLength(20, ErrorMessage = "last name length must be bigger than 2", MinimumLength = 2)]
    public string LastName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
