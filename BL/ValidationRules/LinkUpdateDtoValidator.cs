using DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ValidationRules
{
    public class LinkUpdateDtoValidator : AbstractValidator<LinkUpdateDto>
    {
        public LinkUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Url).NotEmpty();
        }
    }
}
