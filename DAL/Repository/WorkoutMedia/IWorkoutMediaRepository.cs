using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IWorkoutMediaRepository : IGenericRepository<WorkoutMedia>
    {
        // دریافت فایل‌های مربوط به یک تمرین
        List<WorkoutMedia> GetByWorkoutId(int workoutId);
        Task<List<WorkoutMedia>> GetByWorkoutIdAsync(int workoutId);

        // فقط ویدیوها
        List<WorkoutMedia> GetVideos(int workoutId);
        Task<List<WorkoutMedia>> GetVideosAsync(int workoutId);

        // فقط تصاویر
        List<WorkoutMedia> GetImages(int workoutId);
        Task<List<WorkoutMedia>> GetImagesAsync(int workoutId);
    }
}
