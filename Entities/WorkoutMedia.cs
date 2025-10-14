using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class WorkoutMedia : BaseEntity
    {
        public int WorkoutId { get; set; }              // تمرینی که فایل بهش تعلق داره
        public Workout Workout { get; set; } = null!;

        public string FileUrl { get; set; } = null!;    // مسیر فایل (روی سرور یا CDN)
        public string? ThumbnailUrl { get; set; }       // تصویر بندانگشتی برای ویدیوها
        public MediaType Type { get; set; }             // نوع فایل (عکس یا ویدیو)
        public string? Description { get; set; }        // توضیح یا عنوان فایل (مثلاً "حرکت پرس سینه با دمبل")

        public enum MediaType
        {
            Image = 0,
            Video = 1
        }
    }
}
