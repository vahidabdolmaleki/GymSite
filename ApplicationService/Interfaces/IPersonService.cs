using ApplicationService.DTOs.Person;
using ApplicationService.DTOs.Token;
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
        Task<ServiceResult<TokenResponseDto>> LoginAsync(LoginRequestDto dto);
        Task<ServiceResult<bool>> UpdateAsync(PersonUpdateDto dto);
        Task<ServiceResult<bool>> DeleteAsync(int id);
        Task<ServiceResult<string>> RegisterAsync(PersonRegisterDto dto);

        // Password service's
        Task<ServiceResult<bool>> ForgotPasswordAsync(ForgotPasswordDto dto);
        Task<ServiceResult<bool>> ResetPasswordAsync(ResetPasswordDto dto);
        // Verify Service's
        Task<ServiceResult<bool>> VerifyCodeAsync(VerifyCodeDto dto);
        // Token
        Task<ServiceResult<TokenResponseDto>> RefreshTokenAsync(RefreshTokenDto dto);

    }
}
