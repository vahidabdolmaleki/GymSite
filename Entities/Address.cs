namespace Entities
{
    public class Address : BaseEntity
    {
        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;
        public int AddressDetailId { get; set; }
        public AddressDetail AddressDetail { get; set; } = null!;
        public string? Label { get; set; } // مثلا "خانه" یا "محل کار"
        public bool IsPrimary { get; set; } = false;
    }
}






