﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class BreadCrumbUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string MiniHeader { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
