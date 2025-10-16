using ApplicationService.DTOs.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonDto>> GetAllAsync();
        Task<PersonDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(PersonCreateDto dto);
        Task UpdateAsync(PersonUpdateDto dto);
        Task DeleteAsync(int Id);
        Task<string?> LoginAsync(PersonLoginDto Dto);
        Task ChangePasswordAsync(int personId,string currentPassword,string newPassword);
        Task SetPrimaryPictureAsync(int personId, int pictureId);
    }
}
