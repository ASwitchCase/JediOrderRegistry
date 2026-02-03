using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JediOrderRegistry.Api.Models;

namespace JediOrderRegistry.Api.Repositories
{
    public interface IJediRepository
    {
        Task<JediModel?> GetOneAsync(Guid id);
        Task<IEnumerable<JediModel>> GetAllAsync();
        Task<JediModel> AddAsync(JediModel jedi);
        Task<JediModel?> UpdateAsync(JediModel jedi);
        Task<bool> DeleteAsync(Guid id);
    }
}
