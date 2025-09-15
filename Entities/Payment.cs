namespace Entities
{
    public class Payment : BaseEntity
    {
        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime PaidAt { get; set; } = DateTime.UtcNow;
        public string Gateway { get; set; } = "ZarinPal";
        public string Status { get; set; } = "Pending"; // Success/Failed
        public string? TransactionId { get; set; }
        public int? OrderId { get; set; }
        public Order? Order { get; set; }
    }
}






