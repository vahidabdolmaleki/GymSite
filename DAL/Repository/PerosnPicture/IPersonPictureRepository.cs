using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IPersonPictureRepository : IGenericRepository<PersonPicture>
    {
        // عکس‌های یک شخص خاص
        List<PersonPicture> GetByPersonId(int personId);
        Task<List<PersonPicture>> GetByPersonIdAsync(int personId);

        // دریافت عکس اصلی (پروفایل)
        PersonPicture? GetPrimaryPicture(int personId);
        Task<PersonPicture?> GetPrimaryPictureAsync(int personId);

        // تغییر عکس اصلی کاربر
        void SetPrimaryPicture(int personId, int pictureId);
        Task SetPrimaryPictureAsync(int personId, int pictureId);
    }
}
