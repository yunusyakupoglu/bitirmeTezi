﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class AdvertisementCreateDto : IDto
    {
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public bool Status { get; set; }
        public IFormFile FileDoc { get; set; }
    }
}
