using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JediOrderRegistry.Api.Models;

namespace JediOrderRegistry.Api.Repositories
{
    public class InMemoryLightSaberRepository : ILightSaberRepository
    {
        private readonly ConcurrentDictionary<Guid, LightSaber> _store = new();

        public Task<LightSaber?> GetOneAsync(Guid id)
        {
            _store.TryGetValue(id, out var ls);
            return Task.FromResult<LightSaber?>(ls);
        }

        public Task<IEnumerable<LightSaber>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<LightSaber>>(_store.Values.ToList());
        }

        public Task<LightSaber> AddAsync(LightSaber lightSaber)
        {
            if (lightSaber.Id == Guid.Empty) lightSaber.Id = Guid.NewGuid();
            _store[lightSaber.Id] = lightSaber;
            return Task.FromResult(lightSaber);
        }

        public Task<LightSaber?> UpdateAsync(LightSaber lightSaber)
        {
            if (lightSaber.Id == Guid.Empty) return Task.FromResult<LightSaber?>(null);
            if (!_store.ContainsKey(lightSaber.Id)) return Task.FromResult<LightSaber?>(null);
            _store[lightSaber.Id] = lightSaber;
            return Task.FromResult<LightSaber?>(lightSaber);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            return Task.FromResult(_store.TryRemove(id, out _));
        }
    }
}
