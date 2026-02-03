using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JediOrderRegistry.Api.Models;

namespace JediOrderRegistry.Api.Repositories
{
    public interface ILightSaberRepository
    {
        Task<LightSaber?> GetOneAsync(Guid id);
        Task<IEnumerable<LightSaber>> GetAllAsync();
        Task<LightSaber> AddAsync(LightSaber lightSaber);
        Task<LightSaber?> UpdateAsync(LightSaber lightSaber);
        Task<bool> DeleteAsync(Guid id);
    }
}
