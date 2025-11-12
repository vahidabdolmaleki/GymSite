namespace ApplicationService.DTOs.Common
{
    public class PagedResultDto<T> where T : class
    {
        public int CurrentPage { get; set; }         // صفحه فعلی
        public int TotalPages { get; set; }          // تعداد کل صفحات
        public int PageSize { get; set; }            // اندازه هر صفحه
        public int TotalCount { get; set; }          // تعداد کل رکوردها
        public IEnumerable<T> Items { get; set; } = new List<T>(); // داده‌ها
    }
}
