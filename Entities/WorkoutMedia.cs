using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class WorkoutMedia : BaseEntity
    {
        public int WorkoutId { get; set; }
        public Workout Workout { get; set; } = null!;

        // لینک فایل اصلی (تصویر یا ویدیو)
        public string FileUrl { get; set; } = null!;

        // اگر ویدیو باشد → thumbnail
        public string? ThumbnailUrl { get; set; }

        // نوع فایل: عکس / ویدیو
        public MediaType Type { get; set; }

        // فرمت فایل (image/jpeg یا video/mp4)
        public string? MimeType { get; set; }

        // آیا عکس اصلی تمرین است؟
        public bool IsPrimary { get; set; } = false;

        // اگر ویدیو باشد مدت زمان آن
        public int? DurationSeconds { get; set; }

        // توضیح برای فایل
        public string? Caption { get; set; }

        public enum MediaType
        {
            Image = 0,
            Video = 1
        }
    }

}
