using DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ValidationRules
{
    public class CounterUpdateDtoValidator : AbstractValidator<CounterUpdateDto>
    {
        public CounterUpdateDtoValidator()
        {
            RuleFor(x=>x.Id).NotEmpty();
            RuleFor(x=>x.Title).NotEmpty();
            RuleFor(x=>x.Count).NotEmpty();
        }
    }
}
