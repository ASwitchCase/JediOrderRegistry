using System;

namespace JediOrderRegistry.Api.Models
{
    public class JediModel
    {
        public Guid Id { get; set; }
        required public string Name { get; set; }
        required public string? Rank { get; set; }
        public Guid? Lightsaber { get; set; }
        public int MidichlorianCount { get; set; }
        public string? Species { get; set; }
        public Guid? Homeworld { get; set; }
        public int Age { get; set; }
        public int YearsOfService { get; set; }
        public Guid? Master { get; set; }
        public Guid? Padawan { get; set; }
        public string? CurrentAssignment { get; set; }
        public bool IsActive { get; set; }

        public JediModel() { }

    }
}
