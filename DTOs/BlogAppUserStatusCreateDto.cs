using OL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class BlogAppUserStatusCreateDto : IDto
    {
        public string Definition { get; set; }
        public List<ObjBlogAppUser> BlogAppUsers { get; set; }
    }
}
