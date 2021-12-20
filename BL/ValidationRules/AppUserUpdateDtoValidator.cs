using DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ValidationRules
{
    public class AppUserUpdateDtoValidator : AbstractValidator<AppUserUpdateDto>
    {
        public AppUserUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.SurName).NotEmpty();
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
        }
    }
}
