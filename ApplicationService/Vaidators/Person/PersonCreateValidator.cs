using ApplicationService.DTOs.Person;
using Core;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Vaidators
{
    public class PersonCreateValidator:AbstractValidator<PersonCreateDto>
    {
        public PersonCreateValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(ExceptionMessage.FirstNameRequired);
            RuleFor(x => x.LastName).NotEmpty().WithMessage(ExceptionMessage.LastNameRequired);
            RuleFor(x => x.Password).NotEmpty().WithMessage(ExceptionMessage.PasswordRequired);
            RuleFor(x => x.Password).MaximumLength(6).WithMessage(ExceptionMessage.PasswordMinimumRequired);
            RuleFor(x => x.Username).MinimumLength(3).WithMessage(ExceptionMessage.UserNameMinimumRequired);
            RuleFor(x => x.Email).EmailAddress().When(x=> !string.IsNullOrEmpty(x.Email));
        }
    }
}
