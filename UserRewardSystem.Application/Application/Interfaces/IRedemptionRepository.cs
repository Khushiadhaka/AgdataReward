using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserRewardSystem.Domain.Entities.Redemption;

namespace UserRewardSystem.Application.Interfaces
{
    // Handles data persistence operations for redemptions
    public interface IRedemptionRepository
    {
        Task AddAsync(RedemptionRecord record);
        Task<RedemptionRecord> GetByIdAsync(Guid id);
        Task<IEnumerable<RedemptionRecord>> GetAllByUserIdAsync(Guid userId);
        Task UpdateAsync(RedemptionRecord record);
        Task<bool> DeleteAsync(Guid id);
    }
}

