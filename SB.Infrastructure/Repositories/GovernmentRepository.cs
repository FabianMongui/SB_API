using SB.Application.Interfaces;
using SB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Infrastructure.Repositories
{
    public class GovernmentRepository : IGovernmentRepository
    {
        private readonly List<GovernmentEntity> _entities = new();

        public Task<IEnumerable<GovernmentEntity>> GetAllAsync() =>
            Task.FromResult(_entities.AsEnumerable());

        public Task<GovernmentEntity> GetByIdAsync(int id) =>
            Task.FromResult(_entities.FirstOrDefault(e => e.Id == id));

        public Task AddAsync(GovernmentEntity entity)
        {
            entity.Id = _entities.Count + 1;
            _entities.Add(entity);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(GovernmentEntity entity)
        {
            var existing = _entities.FirstOrDefault(e => e.Id == entity.Id);
            if (existing != null)
            {
                existing.Name = entity.Name;
                existing.Type = entity.Type;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var entity = _entities.FirstOrDefault(e => e.Id == id);
            if (entity != null) _entities.Remove(entity);
            return Task.CompletedTask;
        }
    }
}
