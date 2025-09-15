namespace Entities
{
    public class PersonPicture : BaseEntity
    {
        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;
        public string PictureAddress { get; set; } = null!; // آدرس در Blob یا path
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
        public bool IsPrimary { get; set; } = false; // اگر بخوای نشان بدی کدوم عکس فعلیه
    }
}






