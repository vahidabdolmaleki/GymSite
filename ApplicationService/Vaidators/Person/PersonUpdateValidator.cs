using ApplicationService.DTOs.Person;
using FluentValidation;

namespace ApplicationService.Vaidators
{
    public class PersonUpdateValidator : AbstractValidator<PersonUpdateDto>
    {
        public PersonUpdateValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Email).EmailAddress().When(x => !string.IsNullOrEmpty(x.Email));
        }
    }
}
