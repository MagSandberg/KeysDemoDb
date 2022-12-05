using System;
using System.Collections.Generic;

namespace KeysDemoDb.Models;

public partial class Country
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Population { get; set; }

    public virtual ICollection<City> Cities { get; } = new List<City>();
}
