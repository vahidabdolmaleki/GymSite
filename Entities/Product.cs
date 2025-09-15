namespace Entities
{
    public class Product : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int? CategoryId { get; set; } // محصولات هم ممکنه دسته داشته باشن
    }
}






