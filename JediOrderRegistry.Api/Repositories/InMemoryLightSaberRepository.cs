using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JediOrderRegistry.Api.Models;

namespace JediOrderRegistry.Api.Repositories
{
    public class InMemoryLightSaberRepository : ILightSaberRepository
    {
        private readonly List<LightSaber> _store = new();
        private readonly object _lock = new();

        public InMemoryLightSaberRepository() { }

        public InMemoryLightSaberRepository(bool seed)
        {
            if (!seed) return;

            // Seed using shared SeedData so OwnerId aligns with seeded Jedi
            foreach (var ls in SeedData.LightSabers)
            {
                _store.Add(new LightSaber
                {
                    Id = ls.Id,
                    Name = ls.Name,
                    Color = ls.Color,
                    CrystalType = ls.CrystalType,
                    Length = ls.Length,
                    Weight = ls.Weight,
                    HiltMaterial = ls.HiltMaterial,
                    Manufacturer = ls.Manufacturer,
                    YearsInUse = ls.YearsInUse,
                    OwnerId = ls.OwnerId
                });
            }
        }

        public Task<LightSaber?> GetOneAsync(Guid id)
        {
            lock (_lock)
            {
                var ls = _store.FirstOrDefault(l => l.Id == id);
                return Task.FromResult<LightSaber?>(ls);
            }
        }

        public Task<IEnumerable<LightSaber>> GetAllAsync()
        {
            lock (_lock)
            {
                return Task.FromResult<IEnumerable<LightSaber>>(_store.ToList());
            }
        }

        public Task<LightSaber> AddAsync(LightSaber lightSaber)
        {
            lock (_lock)
            {
                if (lightSaber.Id == Guid.Empty) lightSaber.Id = Guid.NewGuid();
                _store.Add(lightSaber);
                return Task.FromResult(lightSaber);
            }
        }

        public Task<LightSaber?> UpdateAsync(LightSaber lightSaber)
        {
            lock (_lock)
            {
                if (lightSaber.Id == Guid.Empty) return Task.FromResult<LightSaber?>(null);
                var idx = _store.FindIndex(l => l.Id == lightSaber.Id);
                if (idx == -1) return Task.FromResult<LightSaber?>(null);
                _store[idx] = lightSaber;
                return Task.FromResult<LightSaber?>(lightSaber);
            }
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            lock (_lock)
            {
                var removed = _store.RemoveAll(l => l.Id == id) > 0;
                return Task.FromResult(removed);
            }
        }
    }
}
