using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OL
{
    public class ObjBlogAppUserStatus : BaseEntity
    {
        public string Definition { get; set; }
        public List<ObjBlogAppUser> BlogAppUsers { get; set; }
    }
}
