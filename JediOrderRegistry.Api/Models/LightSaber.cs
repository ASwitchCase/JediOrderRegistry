using System;

namespace JediOrderRegistry.Api.Models
{
    public class LightSaber
    {
        public Guid Id { get; set; }
        required public string Name { get; set; }
        required public string Color { get; set; }
        required public string CrystalType { get; set; }
        public double Length { get; set; }
        public double Weight { get; set; }
        required public string HiltMaterial { get; set; }
        required public string Manufacturer { get; set; }
        required public int YearsInUse { get; set; }
        public Guid? OwnerId { get; set; }

        public LightSaber() { }
    }
}
