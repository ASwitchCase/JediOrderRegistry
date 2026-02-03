using System;

namespace JediOrderRegistry.Api.Models
{
    public class LightSaber
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string CrystalType { get; set; }
        public double Length { get; set; }
        public double Weight { get; set; }
        public string HiltMaterial { get; set; }
        public string Manufacturer { get; set; }
        public bool IsActivated { get; set; }
        public Guid? OwnerId { get; set; }

        public LightSaber() { }
    }
}
