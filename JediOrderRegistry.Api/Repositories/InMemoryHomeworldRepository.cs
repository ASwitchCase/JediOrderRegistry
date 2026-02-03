using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JediOrderRegistry.Api.Models;

namespace JediOrderRegistry.Api.Repositories
{
    public class InMemoryHomeworldRepository : IHomeworldRepository
    {
        private readonly ConcurrentDictionary<Guid, Homeworld> _store = new();

        public Task<Homeworld?> GetOneAsync(Guid id)
        {
            _store.TryGetValue(id, out var hw);
            return Task.FromResult<Homeworld?>(hw);
        }

        public Task<IEnumerable<Homeworld>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Homeworld>>(_store.Values.ToList());
        }

        public Task<Homeworld> AddAsync(Homeworld homeworld)
        {
            if (homeworld.Id == Guid.Empty) homeworld.Id = Guid.NewGuid();
            _store[homeworld.Id] = homeworld;
            return Task.FromResult(homeworld);
        }

        public Task<Homeworld?> UpdateAsync(Homeworld homeworld)
        {
            if (homeworld.Id == Guid.Empty) return Task.FromResult<Homeworld?>(null);
            if (!_store.ContainsKey(homeworld.Id)) return Task.FromResult<Homeworld?>(null);
            _store[homeworld.Id] = homeworld;
            return Task.FromResult<Homeworld?>(homeworld);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            return Task.FromResult(_store.TryRemove(id, out _));
        }
    }
}
