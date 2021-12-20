using DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ValidationRules
{
    public class AppRoleUpdateDtoValidator : AbstractValidator<AppRoleUpdateDto>
    {
        public AppRoleUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Definition).NotEmpty();
        }
    }
}
