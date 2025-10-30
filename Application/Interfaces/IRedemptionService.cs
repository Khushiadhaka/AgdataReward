using Domain.Domain.Entities.Redemption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Product
{
    // Redemption service interface for handling product redemptions
    public interface IRedemptionService
    {
        RedemptionRecord RedeemProduct(Guid userId, Guid productId);
        // Redeem a product

        void ApproveRedemption(Guid redemptionId);
        // Approve redemption

        void RejectRedemption(Guid redemptionId);
        // Reject redemption

        void CompleteRedemption(Guid redemptionId);
        // Complete redemption

        void CancelRedemption(Guid redemptionId);
        // Cancel redemption

        IEnumerable<RedemptionRecord> GetUserRedemptions(Guid userId);
        // Get all redemptions of a user
    }
}
