using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OL
{
    public class ObjAppUserRole : BaseEntity
    {
        public int AppUserId { get; set; }
        public ObjAppUser ObjAppUser { get; set; }
        public int AppRoleId { get; set; }
        public ObjAppRole ObjAppRole { get; set; }
    }
}
