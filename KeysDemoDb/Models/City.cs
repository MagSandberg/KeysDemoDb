using System;
using System.Collections.Generic;

namespace KeysDemoDb.Models;

public partial class City
{
    public int Id { get; set; }

    public int? CountryId { get; set; }

    public string? Name { get; set; }

    public int? Population { get; set; }

    public virtual Country? Country { get; set; }
}
