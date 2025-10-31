using System;
using Xunit;
using UserRewardSystem.Domain.Entities.Redemption;
using UserRewardSystem.Domain.Common;
using UserRewardSystem.Domain.Enums;

namespace UserRewardSystem.Tests.Domain
{
    public class RedemptionDomainTests
    {
        //RedemptionProcess Tests

        [Fact]
        public void CreateRedemptionProcess_ShouldInitialize_WithPendingStatus()
        {
            var process = new RedemptionProcess(Guid.NewGuid(), 100);
            Assert.Equal(RedemptionStatus.Pending, process.Status);
            Assert.Equal(100, process.PointsUsed);
        }

        [Fact]
        public void CreateRedemptionProcess_ShouldThrow_WhenInvalidId()
        {
            Assert.Throws<ValidationException>(() => new RedemptionProcess(Guid.Empty, 50));
        }

        [Fact]
        public void CreateRedemptionProcess_ShouldThrow_WhenInvalidPoints()
        {
            Assert.Throws<ValidationException>(() => new RedemptionProcess(Guid.NewGuid(), 0));
        }

        [Fact]
        public void Approve_ShouldChangeStatus_ToApproved()
        {
            var process = new RedemptionProcess(Guid.NewGuid(), 100);
            process.Approve();

            Assert.Equal(RedemptionStatus.Approved, process.Status);
        }

        [Fact]
        public void Approve_ShouldThrow_WhenNotPending()
        {
            var process = new RedemptionProcess(Guid.NewGuid(), 100);
            process.Approve();

            Assert.Throws<InvalidOperationException>(() => process.Approve());
        }

        [Fact]
        public void Reject_ShouldChangeStatus_ToRejected()
        {
            var process = new RedemptionProcess(Guid.NewGuid(), 100);
            process.Reject();

            Assert.Equal(RedemptionStatus.Rejected, process.Status);
        }

        [Fact]
        public void Reject_ShouldThrow_WhenNotPending()
        {
            var process = new RedemptionProcess(Guid.NewGuid(), 100);
            process.Approve();

            Assert.Throws<InvalidOperationException>(() => process.Reject());
        }

        [Fact]
        public void MarkCompleted_ShouldChangeStatus_ToCompleted()
        {
            var process = new RedemptionProcess(Guid.NewGuid(), 100);
            process.Approve();
            process.MarkCompleted();

            Assert.Equal(RedemptionStatus.Completed, process.Status);
        }

        [Fact]
        public void MarkCompleted_ShouldThrow_IfNotApproved()
        {
            var process = new RedemptionProcess(Guid.NewGuid(), 100);
            Assert.Throws<InvalidOperationException>(() => process.MarkCompleted());
        }

        [Fact]
        public void Cancel_ShouldChangeStatus_ToCancelled()
        {
            var process = new RedemptionProcess(Guid.NewGuid(), 100);
            process.Cancel();

            Assert.Equal(RedemptionStatus.Cancelled, process.Status);
        }

        [Fact]
        public void Cancel_ShouldThrow_IfAlreadyCompleted()
        {
            var process = new RedemptionProcess(Guid.NewGuid(), 100);
            process.Approve();
            process.MarkCompleted();

            Assert.Throws<InvalidOperationException>(() => process.Cancel());
        }

        //RedemptionRecord Tests

        [Fact]
        public void CreateRedemptionRecord_ShouldInitializeProperly()
        {
            var record = new RedemptionRecord(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());
            Assert.NotEqual(Guid.Empty, record.Id);
            Assert.NotEqual(Guid.Empty, record.UserId);
            Assert.NotEqual(Guid.Empty, record.ProductId);
        }

        [Fact]
        public void CreateRedemptionRecord_ShouldThrow_WhenIdEmpty()
        {
            Assert.Throws<ValidationException>(() =>
                new RedemptionRecord(Guid.Empty, Guid.NewGuid(), Guid.NewGuid()));
        }

        [Fact]
        public void CreateRedemptionRecord_ShouldThrow_WhenUserIdEmpty()
        {
            Assert.Throws<ValidationException>(() =>
                new RedemptionRecord(Guid.NewGuid(), Guid.Empty, Guid.NewGuid()));
        }

        [Fact]
        public void CreateRedemptionRecord_ShouldThrow_WhenProductIdEmpty()
        {
            Assert.Throws<ValidationException>(() =>
                new RedemptionRecord(Guid.NewGuid(), Guid.NewGuid(), Guid.Empty));
        }
    }
}
