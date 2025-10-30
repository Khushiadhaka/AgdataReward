using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRewardSystem.Application.Interfaces;
using UserRewardSystem.Domain.Entities.Redemption;

namespace UserRewardSystem.Infrastructure
{
    public class InMemoryRedemptionRepository : IRedemptionRepository
    {
        private readonly List<RedemptionRecord> _records = new List<RedemptionRecord>();

        public Task AddAsync(RedemptionRecord record)
        {
            _records.Add(record);
            return Task.CompletedTask;
        }

        public Task<RedemptionRecord> GetByIdAsync(Guid id)
        {
            var record = _records.FirstOrDefault(r => r.Id == id);
            return Task.FromResult(record);
        }

        public Task<IEnumerable<RedemptionRecord>> GetAllByUserIdAsync(Guid userId)
        {
            var userRecords = _records.Where(r => r.UserId == userId);
            return Task.FromResult(userRecords.AsEnumerable());
        }

        public Task UpdateAsync(RedemptionRecord record)
        {
            return Task.CompletedTask;
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            var record = _records.FirstOrDefault(r => r.Id == id);
            if (record != null)
            {
                _records.Remove(record);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
