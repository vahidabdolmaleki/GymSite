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
    public class PersonPictureRepository : GenericRepository<PersonPicture>, IPersonPictureRepository
    {
        private readonly GymDbContext _gymDbContext;

        public PersonPictureRepository(GymDbContext gymDbContext) : base(gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public List<PersonPicture> GetByPersonId(int personId)
        {
            return _gymDbContext.PersonPictures
                .Where(p => p.PersonId == personId)
                .ToList();
        }

        public async Task<List<PersonPicture>> GetByPersonIdAsync(int personId)
        {
            return await _gymDbContext.PersonPictures
                .Where(p => p.PersonId == personId)
                .ToListAsync();
        }

        public PersonPicture? GetPrimaryPicture(int personId)
        {
            return _gymDbContext.PersonPictures
                .FirstOrDefault(p => p.PersonId == personId && p.IsPrimary);
        }

        public async Task<PersonPicture?> GetPrimaryPictureAsync(int personId)
        {
            return await _gymDbContext.PersonPictures
                .FirstOrDefaultAsync(p => p.PersonId == personId && p.IsPrimary);
        }

        public void SetPrimaryPicture(int personId, int pictureId)
        {
            var allPictures = _gymDbContext.PersonPictures.Where(p => p.PersonId == personId).ToList();
            foreach (var pic in allPictures)
                pic.IsPrimary = pic.Id == pictureId;

            _gymDbContext.SaveChanges();
        }

        public async Task SetPrimaryPictureAsync(int personId, int pictureId)
        {
            var allPictures = await _gymDbContext.PersonPictures.Where(p => p.PersonId == personId).ToListAsync();
            foreach (var pic in allPictures)
                pic.IsPrimary = pic.Id == pictureId;

            await _gymDbContext.SaveChangesAsync();
        }
    }
}
