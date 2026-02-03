using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JediOrderRegistry.Api.Models;

namespace JediOrderRegistry.Api.Repositories
{
    public class InMemoryHomeworldRepository : IHomeworldRepository
    {
        private readonly List<Homeworld> _store = new();
        private readonly object _lock = new();

        public InMemoryHomeworldRepository() { }

        public InMemoryHomeworldRepository(bool seed)
        {
            if (!seed) return;

            // Seed using shared SeedData for consistent cross-references
            foreach (var hw in SeedData.Homeworlds)
            {
                // add a copy to avoid shared instance issues
                _store.Add(new Homeworld
                {
                    Id = hw.Id,
                    Name = hw.Name,
                    System = hw.System,
                    Sector = hw.Sector,
                    Population = hw.Population,
                    Climate = hw.Climate,
                    PrimarySpecies = hw.PrimarySpecies,
                    Gravity = hw.Gravity
                });
            }
        }

        public Task<Homeworld?> GetOneAsync(Guid id)
        {
            lock (_lock)
            {
                var hw = _store.FirstOrDefault(h => h.Id == id);
                return Task.FromResult<Homeworld?>(hw);
            }
        }

        public Task<IEnumerable<Homeworld>> GetAllAsync()
        {
            lock (_lock)
            {
                return Task.FromResult<IEnumerable<Homeworld>>(_store.ToList());
            }
        }

        public Task<Homeworld> AddAsync(Homeworld homeworld)
        {
            lock (_lock)
            {
                if (homeworld.Id == Guid.Empty) homeworld.Id = Guid.NewGuid();
                _store.Add(homeworld);
                return Task.FromResult(homeworld);
            }
        }

        public Task<Homeworld?> UpdateAsync(Homeworld homeworld)
        {
            lock (_lock)
            {
                if (homeworld.Id == Guid.Empty) return Task.FromResult<Homeworld?>(null);
                var idx = _store.FindIndex(h => h.Id == homeworld.Id);
                if (idx == -1) return Task.FromResult<Homeworld?>(null);
                _store[idx] = homeworld;
                return Task.FromResult<Homeworld?>(homeworld);
            }
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            lock (_lock)
            {
                var removed = _store.RemoveAll(h => h.Id == id) > 0;
                return Task.FromResult(removed);
            }
        }
    }
}
