using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class AppUserCreateDto : IDto
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }

        //public List<ObjAppUserRole> AppUserRoles { get; set; }
        //public List<ObjBlogAppUser> BlogAppUsers { get; set; }
    }
}
