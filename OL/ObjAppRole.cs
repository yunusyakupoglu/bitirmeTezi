﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OL
{
    public class ObjAppRole : BaseEntity
    {
        public string Definition { get; set; }
        public List<ObjAppUserRole> AppUserRoles { get; set; }
        public bool Status { get; set; }

    }
}
