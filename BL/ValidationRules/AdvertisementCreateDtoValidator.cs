﻿using DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ValidationRules
{
    public class AdvertisementCreateDtoValidator : AbstractValidator<AdvertisementCreateDto>
    {
        public AdvertisementCreateDtoValidator()
        {
            RuleFor(x=>x.Title).NotEmpty();
        }
    }
}
