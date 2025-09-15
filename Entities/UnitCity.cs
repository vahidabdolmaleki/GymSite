namespace Entities
{
    public class UnitCity // نگهداری استان‌ها و شهرستان‌ها
    {
        // می‌تونی از کلید مرکب یا Id واحد استفاده کنی؛ اینجا یک Id تک‌ستونه برای سادگی
        public int Id { get; set; }
        public int? ParentUnitId { get; set; } // اگر NULL => این یک استان است؛ اگر مقدار داشته باشه => شهرستان و ParentUnitId = استان
        public string Name { get; set; } = null!;
        public string? Code { get; set; } // کد استان/شهر (اختیاری)

        public ICollection<UnitCity>? Children { get; set; } = new List<UnitCity>();
    }
}






