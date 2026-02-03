using System;

namespace JediOrderRegistry.Api.Models
{
    public class Homeworld
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string System { get; set; }
        public string Sector { get; set; }
        public long Population { get; set; }
        public string Climate { get; set; }
        public string PrimarySpecies { get; set; }
        public double Gravity { get; set; }

        public Homeworld() { }
    }
}
