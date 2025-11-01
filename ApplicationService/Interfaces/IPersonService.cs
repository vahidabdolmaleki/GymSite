using ApplicationService.DTOs.Person;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Interfaces
{
    public interface IPersonService
    {
        Task<ServiceResults<PersonDto>> GetAllAsync();
        Task<ServiceResult<PersonDto>> GetByIdAsync(int id);
        Task<ServiceResult<PersonDto>> RegisterAsync(PersonCreateDto dto);
        Task<ServiceResult<string>> LoginAsync(string username, string password, string deviceToken, string deviceType);
        Task<ServiceResult<bool>> UpdateAsync(PersonUpdateDto dto);
        Task<ServiceResult<bool>> DeleteAsync(int id);
        Task<ServiceResult<string>> RegisterAsync(PersonRegisterDto dto);

    }
}
