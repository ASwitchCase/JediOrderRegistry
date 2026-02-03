using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JediOrderRegistry.Api.Models;

namespace JediOrderRegistry.Api.Repositories
{
    public class InMemoryJediRepository : IJediRepository
    {
        private readonly List<JediModel> _store = new();
        private readonly object _lock = new();

        public InMemoryJediRepository() { }

        public InMemoryJediRepository(bool seed)
        {
            if (!seed) return;

            // Seed using shared SeedData so Homeworld and Lightsaber fields align
            foreach (var j in SeedData.Jedi)
            {
                _store.Add(new JediModel
                {
                    Id = j.Id,
                    Name = j.Name,
                    Rank = j.Rank,
                    MidichlorianCount = j.MidichlorianCount,
                    Species = j.Species,
                    Age = j.Age,
                    YearsOfService = j.YearsOfService,
                    IsActive = j.IsActive,
                    Homeworld = j.Homeworld,
                    Lightsaber = j.Lightsaber,
                    Master = j.Master,
                    Padawan = j.Padawan,
                    CurrentAssignment = j.CurrentAssignment
                });
            }
        }

        public Task<JediModel?> GetOneAsync(Guid id)
        {
            lock (_lock)
            {
                var jedi = _store.FirstOrDefault(j => j.Id == id);
                return Task.FromResult<JediModel?>(jedi);
            }
        }

        public Task<IEnumerable<JediModel>> GetAllAsync()
        {
            lock (_lock)
            {
                return Task.FromResult<IEnumerable<JediModel>>(_store.ToList());
            }
        }

        public Task<JediModel> AddAsync(JediModel jedi)
        {
            lock (_lock)
            {
                if (jedi.Id == Guid.Empty) jedi.Id = Guid.NewGuid();
                _store.Add(jedi);
                return Task.FromResult(jedi);
            }
        }

        public Task<JediModel?> UpdateAsync(JediModel jedi)
        {
            lock (_lock)
            {
                if (jedi.Id == Guid.Empty) return Task.FromResult<JediModel?>(null);
                var idx = _store.FindIndex(j => j.Id == jedi.Id);
                if (idx == -1) return Task.FromResult<JediModel?>(null);
                _store[idx] = jedi;
                return Task.FromResult<JediModel?>(jedi);
            }
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            lock (_lock)
            {
                var removed = _store.RemoveAll(j => j.Id == id) > 0;
                return Task.FromResult(removed);
            }
        }
    }
}
