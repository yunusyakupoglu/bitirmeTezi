using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DocumentaryListDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string VideoPath { get; set; }
        public bool Status { get; set; }
    }
}
