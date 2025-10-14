using DAL.Context;
using DAL.Repository.GenericRepository;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class WorkoutMediaRepository : GenericRepository<WorkoutMedia>, IWorkoutMediaRepository
    {
        private readonly GymDbContext _gymDbContext;

        public WorkoutMediaRepository(GymDbContext gymDbContext) : base(gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public List<WorkoutMedia> GetByWorkoutId(int workoutId)
        {
            return _gymDbContext.WorkoutMedias
                .Where(wm => wm.WorkoutId == workoutId)
                .OrderBy(wm => wm.CreatedDate)
                .ToList();
        }

        public async Task<List<WorkoutMedia>> GetByWorkoutIdAsync(int workoutId)
        {
            return await _gymDbContext.WorkoutMedias
                .Where(wm => wm.WorkoutId == workoutId)
                .OrderBy(wm => wm.CreatedDate)
                .ToListAsync();
        }

        public List<WorkoutMedia> GetVideos(int workoutId)
        {
            return _gymDbContext.WorkoutMedias
                .Where(wm => wm.WorkoutId == workoutId && wm.Type == WorkoutMedia.MediaType.Video)
                .ToList();
        }

        public async Task<List<WorkoutMedia>> GetVideosAsync(int workoutId)
        {
            return await _gymDbContext.WorkoutMedias
                .Where(wm => wm.WorkoutId == workoutId && wm.Type == WorkoutMedia.MediaType.Video)
                .ToListAsync();
        }

        public List<WorkoutMedia> GetImages(int workoutId)
        {
            return _gymDbContext.WorkoutMedias
                .Where(wm => wm.WorkoutId == workoutId && wm.Type == WorkoutMedia.MediaType.Image)
                .ToList();
        }

        public async Task<List<WorkoutMedia>> GetImagesAsync(int workoutId)
        {
            return await _gymDbContext.WorkoutMedias
                .Where(wm => wm.WorkoutId == workoutId && wm.Type == WorkoutMedia.MediaType.Image)
                .ToListAsync();
        }
    }
}
