using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRewardSystem.Domain.Entities.Redemption;
using UserRewardSystem.Domain.Enums;

namespace Test
{
    public class RedemptionTests
    {
        [Fact]
        public void RedemptionProcess_ShouldStartAsPending()
        {
            var redemption = new RedemptionProcess(Guid.NewGuid(), 100);
            Assert.Equal(RedemptionStatus.Pending, redemption.Status);
        }

        [Fact]
        public void Approve_ShouldChangeStatusToApproved()
        {
            var redemption = new RedemptionProcess(Guid.NewGuid(), 200);
            redemption.Approve();
            Assert.Equal(RedemptionStatus.Approved, redemption.Status);
        }

        [Fact]
        public void Reject_ShouldChangeStatusToRejected()
        {
            var redemption = new RedemptionProcess(Guid.NewGuid(), 150);
            redemption.Reject();
            Assert.Equal(RedemptionStatus.Rejected, redemption.Status);
        }

        [Fact]
        public void Cancel_ShouldChangeStatusToCancelled()
        {
            var redemption = new RedemptionProcess(Guid.NewGuid(), 90);
            redemption.Cancel();
            Assert.Equal(RedemptionStatus.Cancelled, redemption.Status);
        }

        [Fact]
        public void RedemptionRecord_ShouldStoreIdsProperly()
        {
            var id = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var productId = Guid.NewGuid();

            var record = new RedemptionRecord(id, userId, productId);

            Assert.Equal(id, record.Id);
            Assert.Equal(userId, record.UserId);
            Assert.Equal(productId, record.ProductId);
        }
    }
}
