using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JediOrderRegistry.Api.Models;

namespace JediOrderRegistry.Api.Repositories
{
    public interface IHomeworldRepository
    {
        Task<Homeworld?> GetOneAsync(Guid id);
        Task<IEnumerable<Homeworld>> GetAllAsync();
        Task<Homeworld> AddAsync(Homeworld homeworld);
        Task<Homeworld?> UpdateAsync(Homeworld homeworld);
        Task<bool> DeleteAsync(Guid id);
    }
}
