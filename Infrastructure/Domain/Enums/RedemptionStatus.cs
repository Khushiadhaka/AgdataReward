namespace agdata.Domain.Enums
{
    // Represents the current status of a redemption request
    public enum RedemptionStatus
    {
        Pending = 1,    // Redemption created but not yet approved
        Approved = 2,   // Redemption request approved by admin
        Completed = 3,  // Reward successfully delivered or fulfilled
        Cancelled = 4   // Redemption cancelled by user or system
    }
}



