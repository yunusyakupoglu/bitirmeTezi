using DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ValidationRules
{
    public class AppUserLoginDtoValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginDtoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola boş geçilemez.");
        }
    }
}
