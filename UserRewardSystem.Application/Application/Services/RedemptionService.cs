using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserRewardSystem.Application.Interfaces;
using UserRewardSystem.Domain.Common;
using UserRewardSystem.Domain.Entities.Redemption;
using UserRewardSystem.Domain.Enums;

namespace UserRewardSystem.Application.Services
{
   
    public class RedemptionService : IRedemptionService
    {
        private readonly IRedemptionRepository _repository;

        public RedemptionService(IRedemptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<RedemptionRecord> RedeemAsync(Guid userId, Guid productId, int pointsUsed)
        {
            if (pointsUsed <= 0)
                throw new ValidationException("Points used must be greater than zero.");

            var record = new RedemptionRecord(Guid.NewGuid(), userId, productId);
            await _repository.AddAsync(record);
            return record;
        }

        public async Task<RedemptionRecord> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<RedemptionRecord>> GetAllByUserIdAsync(Guid userId)
        {
            return await _repository.GetAllByUserIdAsync(userId);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}

