using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OL
{
    public class ObjBlogAppUser : BaseEntity
    {
        public int BlogId { get; set; }
        public ObjBlog ObjBlog { get; set; }
        public int AppUserId { get; set; }
        public ObjAppUser ObjAppUser { get; set; }
        public int BlogAppUserStatusId { get; set; }
        public ObjBlogAppUserStatus ObjBlogAppUserStatus { get; set; }
    }
}
