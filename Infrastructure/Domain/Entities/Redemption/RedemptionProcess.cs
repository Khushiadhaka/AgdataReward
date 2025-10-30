using agdata.Domain.Enums;
using Domain.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.Entities.Redemption
{
    // Handles the lifecycle of a redemption request
    public sealed class RedemptionProcess
    {
        public Guid RedemptionId { get; }
        public int PointsUsed { get; private set; }
        public RedemptionStatus Status { get; private set; }

        public RedemptionProcess(Guid redemptionId, int pointsUsed)
        {
            if (redemptionId == Guid.Empty) throw new ValidationException("Redemption ID cannot be empty.");
            if (pointsUsed <= 0) throw new ValidationException("Points used must be greater than zero.");

            RedemptionId = redemptionId;
            PointsUsed = pointsUsed;
            Status = RedemptionStatus.Pending;
        }

        public void Approve()
        {
            if (Status != RedemptionStatus.Pending) throw new InvalidOperationException("Only pending requests can be approved.");
            Status = RedemptionStatus.Approved;
        }
        public void Reject()
        {
            if (Status != RedemptionStatus.Pending) throw new InvalidOperationException("Only pending requests can be rejected.");
            Status = RedemptionStatus.Rejected;
        }

        public void MarkCompleted()
        {
            if (Status != RedemptionStatus.Approved) throw new InvalidOperationException("Only approved redemptions can be completed.");
            Status = RedemptionStatus.Completed;
        }

        public void Cancel()
        {
            if (Status == RedemptionStatus.Completed) throw new InvalidOperationException("Completed redemptions cannot be cancelled.");
            Status = RedemptionStatus.Cancelled;
        }
    }
}
