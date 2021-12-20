using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class CounterCreateDto : IDto
    {
        public string Title { get; set; }
        public string Count { get; set; }
        public bool Status { get; set; }
    }
}
