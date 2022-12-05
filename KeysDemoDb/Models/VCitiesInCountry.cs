using System;
using System.Collections.Generic;

namespace KeysDemoDb.Models;

public partial class VCitiesInCountry
{
    public string? CityName { get; set; }

    public int? CityPopulation { get; set; }

    public string? CountryName { get; set; }

    public int? CountryPopulation { get; set; }

    public string? PartOfTotal { get; set; }
}
