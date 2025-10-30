using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserRewardSystem.Domain.Entities.Redemption;
using UserRewardSystem.Domain.Enums;

namespace UserRewardSystem.Application.Interfaces
{
    // Defines business operations for managing redemption logic
    public interface IRedemptionService
    {
        Task<RedemptionRecord> RedeemAsync(Guid userId, Guid productId, int pointsUsed);
        Task<RedemptionRecord> GetByIdAsync(Guid id);
        Task<IEnumerable<RedemptionRecord>> GetAllByUserIdAsync(Guid userId);
        Task<bool> DeleteAsync(Guid id);
    }
}

