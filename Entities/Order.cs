namespace Entities
{
    public class Order : BaseEntity
    {
        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
        public decimal TotalAmount { get; set; }
        public string? Status { get; set; } = "Pending";
    }
}






