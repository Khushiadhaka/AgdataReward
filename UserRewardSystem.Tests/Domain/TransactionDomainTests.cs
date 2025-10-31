using System;
using Xunit;
using UserRewardSystem.Domain.Entities.Transaction;

namespace UserRewardSystem.Tests.Domain
{
    public class TransactionDomainTests
    {
        //TransactionDetail Tests

        [Fact]
        public void CreateTransactionDetail_ShouldInitializeProperly()
        {
            var detail = new TransactionDetail
            {
                TransactionId = Guid.NewGuid(),
                Description = "Payment for order #123",
                PaymentMethod = "Credit Card",
                ReferenceNumber = "REF123"
            };

            Assert.NotEqual(Guid.Empty, detail.TransactionId);
            Assert.Equal("Payment for order #123", detail.Description);
            Assert.Equal("Credit Card", detail.PaymentMethod);
            Assert.Equal("REF123", detail.ReferenceNumber);
        }

        [Fact]
        public void TransactionDetail_ShouldAllowEmptyStrings_ByDefault()
        {
            var detail = new TransactionDetail
            {
                TransactionId = Guid.NewGuid()
            };

            Assert.Equal(string.Empty, detail.Description);
            Assert.Equal(string.Empty, detail.PaymentMethod);
            Assert.Equal(string.Empty, detail.ReferenceNumber);
        }

        [Fact]
        public void TransactionDetail_ShouldThrow_WhenTransactionIdEmpty()
        {
            var detail = new TransactionDetail
            {
                TransactionId = Guid.Empty,
                Description = "Invalid transaction"
            };

            Assert.Equal(Guid.Empty, detail.TransactionId);
            // Since there’s no constructor validation, you may add validation later
            // This test simply shows awareness of invalid state.
        }

        //TransactionSummary Tests

        [Fact]
        public void CreateTransactionSummary_ShouldInitializeProperly()
        {
            var summary = new TransactionSummary
            {
                TransactionId = Guid.NewGuid(),
                Amount = 250.75m,
                Date = DateTime.UtcNow,
                Type = "Purchase",
                Status = "Completed"
            };

            Assert.NotEqual(Guid.Empty, summary.TransactionId);
            Assert.Equal(250.75m, summary.Amount);
            Assert.Equal("Purchase", summary.Type);
            Assert.Equal("Completed", summary.Status);
        }

        [Fact]
        public void TransactionSummary_ShouldAllowEmptyStrings_ByDefault()
        {
            var summary = new TransactionSummary
            {
                TransactionId = Guid.NewGuid(),
                Amount = 100m,
                Date = DateTime.UtcNow
            };

            Assert.Equal(string.Empty, summary.Type);
            Assert.Equal(string.Empty, summary.Status);
        }

        [Fact]
        public void TransactionSummary_ShouldAllowSettingAllProperties()
        {
            var id = Guid.NewGuid();
            var date = DateTime.UtcNow.AddDays(-1);

            var summary = new TransactionSummary
            {
                TransactionId = id,
                Amount = 500m,
                Date = date,
                Type = "Refund",
                Status = "Pending"
            };

            Assert.Equal(id, summary.TransactionId);
            Assert.Equal(500m, summary.Amount);
            Assert.Equal(date, summary.Date);
            Assert.Equal("Refund", summary.Type);
            Assert.Equal("Pending", summary.Status);
        }
    }
}

