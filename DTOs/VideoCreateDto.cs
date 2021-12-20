﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class VideoCreateDto : IDto
    {
        public string Name { get; set; }
        public string VideoPath { get; set; }
        public bool Status { get; set; }
        public IFormFile FileDoc { get; set; }

    }
}
