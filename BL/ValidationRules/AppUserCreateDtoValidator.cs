using DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ValidationRules
{
    public class AppUserCreateDtoValidator : AbstractValidator<AppUserCreateDto>
    {
        public AppUserCreateDtoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.SurName).NotEmpty();
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();
        }
    }
}
