using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.WorkoutRepository
{
    public interface IWorkoutRepository:IGenericRepository<Workout>
    {
        //همه تمرین های یک SubCategory
        List<Workout> GetBySubCategory(int subCategoryId);
        Task<List<Workout>> GetBySubcategoryAsync(int subCategoryId);

        //جستجو با نام
        List<Workout> SerachByName(string Keyword);
        Task<List<Workout>> SerachByNameAsync(string Keyword);

        //تمرینات با سختی یا زمان خاص (مثلاض بالای 30دقیقه)،ر
        List<Workout> GetByDuration(int minMinutes);
        Task<List<Workout>> GetByDurationAsync(int minMinutes);

        //تمرینات به همراه لاگ های انجام شده
        Workout? GetWithLog(int workoutId);
        Task<Workout?> GetWithLogAsync(int workoutId);
    }
}
