namespace Entities
{
    public class AddressDetail : BaseEntity
    {
        public int? UnitId { get; set; } // استان یا مرجع
        public int? CityId { get; set; } // شهرستان (اختیاری)
        public string? Street { get; set; }
        public string? Alley { get; set; }
        public string? Number { get; set; }
        public string? PostalCode { get; set; }

        // Navigation (در صورت نیاز)
        public UnitCity? Unit { get; set; }
        public UnitCity? City { get; set; }
    }
}






