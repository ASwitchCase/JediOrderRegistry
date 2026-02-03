using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JediOrderRegistry.Api.Models;

namespace JediOrderRegistry.Api.Repositories
{
    public class InMemoryJediRepository : IJediRepository
    {
        private readonly ConcurrentDictionary<Guid, JediModel> _store = new();

        public Task<JediModel?> GetOneAsync(Guid id)
        {
            _store.TryGetValue(id, out var jedi);
            return Task.FromResult<JediModel?>(jedi);
        }

        public Task<IEnumerable<JediModel>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<JediModel>>(_store.Values.ToList());
        }

        public Task<JediModel> AddAsync(JediModel jedi)
        {
            if (jedi.Id == Guid.Empty) jedi.Id = Guid.NewGuid();
            _store[jedi.Id] = jedi;
            return Task.FromResult(jedi);
        }

        public Task<JediModel?> UpdateAsync(JediModel jedi)
        {
            if (jedi.Id == Guid.Empty) return Task.FromResult<JediModel?>(null);
            if (!_store.ContainsKey(jedi.Id)) return Task.FromResult<JediModel?>(null);
            _store[jedi.Id] = jedi;
            return Task.FromResult<JediModel?>(jedi);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            return Task.FromResult(_store.TryRemove(id, out _));
        }
    }
}
