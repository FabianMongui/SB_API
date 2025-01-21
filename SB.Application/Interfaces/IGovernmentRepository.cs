using SB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Application.Interfaces
{
    public interface IGovernmentRepository
    {
        Task<IEnumerable<GovernmentEntity>> GetAllAsync();
        Task<GovernmentEntity> GetByIdAsync(int id);
        Task AddAsync(GovernmentEntity entity);
        Task UpdateAsync(GovernmentEntity entity);
        Task DeleteAsync(int id);
    }
}
