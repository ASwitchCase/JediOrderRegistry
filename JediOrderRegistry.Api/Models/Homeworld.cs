using System;

namespace JediOrderRegistry.Api.Models
{
    public class Homeworld
    {
        public Guid Id { get; set; }
        required public string Name { get; set; }
        required public string System { get; set; }
        required public string Sector { get; set; }
        public long Population { get; set; }
        public string? Climate { get; set; }
        public string? PrimarySpecies { get; set; }
        public double Gravity { get; set; }

        public Homeworld() { }
    }
}
