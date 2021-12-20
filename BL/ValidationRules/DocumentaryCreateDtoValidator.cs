using DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ValidationRules
{
    public class DocumentaryCreateDtoValidator : AbstractValidator<DocumentaryCreateDto>
    {
        public DocumentaryCreateDtoValidator()
        {
            RuleFor(x=>x.Title).NotEmpty();
        }
    }
}
