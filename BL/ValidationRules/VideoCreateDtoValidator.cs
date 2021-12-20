using DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ValidationRules
{
    public class VideoCreateDtoValidator : AbstractValidator<VideoCreateDto>
    {
        public VideoCreateDtoValidator()
        {
            RuleFor(x=>x.Name).NotEmpty();
        }
    }
}
