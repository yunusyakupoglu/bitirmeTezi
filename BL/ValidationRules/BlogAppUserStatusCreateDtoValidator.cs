﻿using DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ValidationRules
{
    public class BlogAppUserStatusCreateDtoValidator : AbstractValidator<BlogAppUserStatusCreateDto>
    {
        public BlogAppUserStatusCreateDtoValidator()
        {
            RuleFor(x => x.Definition).NotEmpty();
        }
    }
}
