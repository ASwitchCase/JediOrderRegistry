using System;

namespace JediOrderRegistry.Api.Models
{
    public class JediModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
        public string LightsaberColor { get; set; }
        public int MidichlorianCount { get; set; }
        public string Species { get; set; }
        public string Homeworld { get; set; }
        public int Age { get; set; }
        public int YearsOfService { get; set; }
        public string MasterName { get; set; }
        public string CurrentAssignment { get; set; }
        public bool IsActive { get; set; }
    }
}
